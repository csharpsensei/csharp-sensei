var evt = http.Event();
evt.Set("user.id", request.UserId);
evt.Set("user.tier", request.Tier);
evt.Set("cart.value", request.Total);
evt.Set("cart.items", request.Items);
