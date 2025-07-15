namespace Evento.UI.Generator;

using System.Text;

public class CsvGenerator
{
    public static string Generate(IEnumerable<IDictionary<string, object>> data, string[] columns)
    {
        var sb = new StringBuilder();

        sb.AppendLine(string.Join(",", columns));

        Dictionary<string, object> caseInsensitiveItem;
        foreach (var item in data)
        {
            caseInsensitiveItem = new Dictionary<string, object>(item, StringComparer.OrdinalIgnoreCase);

            var row = columns
                .Select(col => caseInsensitiveItem.TryGetValue(col, out var value) ? value?.ToString() : "")
                .ToArray();

            sb.AppendLine(string.Join(",", row));
        }

        return sb.ToString();
    }
}