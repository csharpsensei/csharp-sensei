using WhatsNew.Payments;

namespace WhatsNew.Regression;

/// <summary>The same union with a fourth case added.</summary>
public union PaymentResultWithRefund(Approved, Declined, Challenged, Refunded);
