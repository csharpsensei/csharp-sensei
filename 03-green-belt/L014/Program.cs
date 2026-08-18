using LiskovSubstitution.Auditing;
using LiskovSubstitution.Legacy;
using LiskovSubstitution.Notifications;
using LiskovSubstitution.OverGeneral;

// Composition root. Three passes, one per cycle of the lesson:
//   1. the violation   two subclasses that do not keep the contract
//   2. the refactor    the same caller, subclasses that do
//   3. the boundary    a base class that promises nothing at all
//
// The message below is 177 characters. Nothing in this file measures it, and
// nothing in this file knows that an SMS segment is 160 characters. That is
// the point: the caller is not supposed to know.

const string Recipient = "07700 900142";
const string Message =
    "Your order 4471 has shipped and is due Thursday. Track it in the app. " +
    "Reply STOP to opt out of delivery updates at any time, or call us on " +
    "0800 555 0142 if anything looks wrong.";

// ---------------------------------------------------------------------------
// Pass 1: the violation. DO NOT COPY. One subclass demands more than the base
// does, and one delivers less than the base promises. Both compile.
// ---------------------------------------------------------------------------
Console.WriteLine("Pass 1: the hierarchy that lies (do not copy)");

Notifier[] lying =
{
    new EmailNotifier(),
    new LyingSmsNotifier(),
    new SilentAuditNotifier(),
};

new LegacyAlertRun(lying).SendAll(Recipient, Message);

Console.WriteLine();

// ---------------------------------------------------------------------------
// Pass 2: the refactor. The SMS notifier absorbs the segment limit instead of
// pushing it onto the caller, and the audit log is no longer a Notifier at
// all, because it never sends anything to anybody. AlertService is unchanged.
// ---------------------------------------------------------------------------
Console.WriteLine("Pass 2: subtypes that keep the promise");

Notifier[] honest =
{
    new EmailNotifier(),
    new SmsNotifier(),
};

AlertService alerts = new AlertService(honest);
AuditLog audit = new AuditLog();

foreach (Receipt receipt in alerts.SendAll(Recipient, Message))
{
    string status = receipt.Delivered ? "delivered" : "not delivered";
    Console.WriteLine($"  {receipt.Channel,-10}{status,-14}{receipt.Note}");
    audit.Record(receipt);
}

string auditChannel = "audit.log";
string auditStatus = audit.Count + " entries";
string auditNote = "recorded after sending, not instead of it";
Console.WriteLine($"  {auditChannel,-10}{auditStatus,-14}{auditNote}");

Console.WriteLine();

// ---------------------------------------------------------------------------
// Pass 3: the boundary. DO NOT COPY. Nothing here breaks the principle,
// because nothing here promises anything, and every caller pays for it.
// ---------------------------------------------------------------------------
Console.WriteLine("Pass 3: the contract that promises nothing (do not copy)");

LooseNotifier[] loose =
{
    new LooseEmailNotifier(),
    new LooseSmsNotifier(),
};

new LooseAlertService(loose).SendAll(Recipient, Message);
