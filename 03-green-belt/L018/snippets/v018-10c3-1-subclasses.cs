public sealed class AuditExportJob : ExportJob
{
    public AuditExportJob() : base("Audit export") { }

    protected override IExporter CreateExporter() => new CsvExporter();
}
public sealed class BackupExportJob : ExportJob
{
    public BackupExportJob() : base("Backup export") { }

    protected override IExporter CreateExporter() => new JsonExporter();
}
