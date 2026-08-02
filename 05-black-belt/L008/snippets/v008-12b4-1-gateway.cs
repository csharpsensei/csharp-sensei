// Three layers down, inside the payment gateway
var evt = http.Event();
evt.Set("payment.gateway", gateway);
evt.Set("payment.attempt", attempt);
evt.Set("payment.approved", approved);
if (declineCode is not null)
    evt.Set("payment.decline_code", declineCode);
