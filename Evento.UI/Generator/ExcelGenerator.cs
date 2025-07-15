namespace Evento.UI.Generator;

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

public class ExcelGenerator
{
    public static MemoryStream Generate(IEnumerable<IDictionary<string, object>> data, string[] columns)
    {
        var stream = new MemoryStream();
        using (var document = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook))
        {
            var workbookPart = document.AddWorkbookPart();
            workbookPart.Workbook = new Workbook();
            var worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
            worksheetPart.Worksheet = new Worksheet(new SheetData());

            var sheets = workbookPart.Workbook.AppendChild(new Sheets());
            var sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Sheet1" };
            sheets.Append(sheet);

            var sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();

            // Cabeçalho das colunas
            var headerRow = new Row();
            foreach (var column in columns)
            {
                headerRow.Append(new Cell
                {
                    CellValue = new CellValue(column),
                    DataType = CellValues.String
                });
            }
            sheetData.AppendChild(headerRow);

            // Dados das linhas
            foreach (var item in data)
            {
                var row = new Row();
                foreach (var column in columns)
                {
                    var cellValue = item.ContainsKey(column) ? item[column]?.ToString() ?? "" : "";
                    row.Append(new Cell
                    {
                        CellValue = new CellValue(cellValue),
                        DataType = CellValues.String
                    });
                }
                sheetData.AppendChild(row);
            }
        }

        stream.Seek(0, SeekOrigin.Begin);
        return stream;
    }
}