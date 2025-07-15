namespace Evento.UI.Generator;

public record ExportRequest
{
    public string[] Columns { get; init; }
    public IEnumerable<IDictionary<string, object>> Data { get; init; }
    public string FileName { get; init; }

    public ExportRequest(string[] columns, IEnumerable<IDictionary<string, object>> data, string fileName)
    {
        Columns = columns;
        Data = data;
        FileName = fileName;
    }

    private ExportRequest()
    {

    }
}