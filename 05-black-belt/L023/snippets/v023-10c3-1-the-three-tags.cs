        activity?.SetTag("http.route", "/checkout/{id}");
        activity?.SetTag("http.response.status_code", order.Failed ? 500 : 200);

        // Nothing in ASP.NET Core and nothing in OpenTelemetry puts these on
        // the span. They are the only reason the policy can say anything
        // more interesting than "it failed" or "it was slow".
        activity?.SetTag("customer.tier", order.Tier);
        activity?.SetTag("cart.value", order.Id % 400);
        activity?.SetTag("order.id", order.Id);

    private bool IsWatched(Activity trace)
        => _businessTagsVisible
        && (trace.GetTagItem("customer.tier") as string) == "vip";
