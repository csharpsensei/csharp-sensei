Notifier[] honest =
{
    new EmailNotifier(),
    new SmsNotifier(),
};

AlertService alerts = new AlertService(honest);
AuditLog audit = new AuditLog();
