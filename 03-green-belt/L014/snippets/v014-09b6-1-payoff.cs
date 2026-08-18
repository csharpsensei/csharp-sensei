// What the fix was:
//
//   SmsNotifier   changed to accept what the base accepts
//   AuditLog      taken out of the hierarchy entirely
//
// What the fix was not: no new interface, no factory,
// and not one line changed in AlertService.
