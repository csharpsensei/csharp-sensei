using System.Diagnostics;

namespace WideEvents.Events;

/// <summary>
/// Creates one <see cref="WideEvent"/> per request, and emits it exactly once
/// when the request finishes.
///
/// Everything the request learns about itself lands here — including the
/// things only the end of a request knows, like duration and status code.
/// Because this wraps the whole pipeline, every request produces an event
/// whether or not anyone remembered to instrument the handler.
/// </summary>
public sealed class WideEventMiddleware(RequestDelegate next, ILogger<WideEventMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext http)
    {
        var evt = new WideEvent();
        http.Items[WideEventExtensions.ItemsKey] = evt;

        var clock = Stopwatch.StartNew();
        try
        {
            await next(http);
        }
        catch (Exception ex)
        {
            // An exception is a fact about the request, so it belongs on the
            // event like any other. Re-thrown: this middleware observes, it
            // does not handle.
            evt.Set("error.type", ex.GetType().Name);
            evt.Set("error.message", ex.Message);
            throw;
        }
        finally
        {
            clock.Stop();

            // NOT http.method / http.route / http.status_code. The `http.*`
            // namespace belongs to the OpenTelemetry semantic conventions, and
            // writing into it breaks the export: Azure Monitor decides which
            // convention version an activity uses by looking at the method tag,
            // so a legacy `http.method` sitting next to the instrumentation's
            // `http.request.method` downgrades the whole activity to the old
            // schema — after which it looks for `http.status_code`, does not
            // find it, and files every request as resultCode 0, success false.
            //
            // Your fields go in your own namespace. Theirs is theirs.
            evt.Set("request.route", http.Request.Path.Value);
            evt.Set("request.method", http.Request.Method);
            evt.Set("request.status", http.Response.StatusCode);
            evt.Set("duration.ms", Math.Round(clock.Elapsed.TotalMilliseconds, 1));

            evt.CopyToActivity();

            // One structured log line, once per request. The Activity tags are
            // what Azure queries; this is what you read locally.
            logger.LogInformation("wide-event {Fields}", evt.Fields);
        }
    }
}
