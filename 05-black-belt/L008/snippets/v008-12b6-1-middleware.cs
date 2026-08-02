var evt = new WideEvent();
http.Items[WideEventExtensions.ItemsKey] = evt;
var clock = Stopwatch.StartNew();
try     { await next(http); }
finally
{
    evt.Set("request.route", http.Request.Path.Value);
    evt.Set("request.status", http.Response.StatusCode);
    evt.Set("duration.ms", clock.Elapsed.TotalMilliseconds);
    evt.CopyToActivity();
}
