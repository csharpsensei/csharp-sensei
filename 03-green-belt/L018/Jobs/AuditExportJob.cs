using FactoryPattern.Exporting;

namespace FactoryPattern.Jobs;

/// <summary>The auditor wants a spreadsheet, so this job makes a CSV.</summary>
public sealed class AuditExportJob : ExportJob
{
    public AuditExportJob() : base("Audit export") { }

    protected override IExporter CreateExporter() => new CsvExporter();
}
