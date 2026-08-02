public static WideEvent Event(this HttpContext http)
{
    if (http.Items[ItemsKey] is WideEvent evt) return evt;

    throw new InvalidOperationException(
        "No WideEvent on this request. Add the middleware.");
}
