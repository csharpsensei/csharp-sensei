var file = new FileDestination();
file.Send(report);          // does not compile

IReportDestination d = file;
d.Send(report);             // fine

// The member belongs to the contract,
// not to the class. That is the feature.
