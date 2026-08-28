using FactoryPattern.Exporting;

namespace FactoryPattern.Jobs;

/// <summary>The backup goes somewhere that reads JSON, so this job makes JSON.</summary>
public sealed class BackupExportJob : ExportJob
{
    public BackupExportJob() : base("Backup export") { }

    protected override IExporter CreateExporter() => new JsonExporter();
}
