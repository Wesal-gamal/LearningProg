
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Data;
using System.IO;
using System.Linq;

namespace Attendleave.Erp.Core.APIUtilities
{
    public class ExportTable:IExportTable
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        
        public ExportTable(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public virtual string ExportData(DataTable result , string fileName)
        {
            var path = _hostingEnvironment.WebRootPath;
            string filePath = Path.Combine("test\\", fileName+" ( "+ DateTime.Now.ToString().Replace('/', '-').Replace(':', '-') + " ).xlsx");
            string actulePath = Path.Combine(path , filePath);
            using (SpreadsheetDocument ssdocument = SpreadsheetDocument.Create(actulePath, SpreadsheetDocumentType.Workbook))
            {
                CreateExcelDocument(ssdocument,  result);
            }
            return filePath;
        }

        public virtual void CreateExcelDocument(SpreadsheetDocument document, DataTable result)
        {
            WorkbookPart workbookPart = document.AddWorkbookPart();
          
            WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>("export");
            GenerateWorkbookPartContent(workbookPart , document , worksheetPart);
            GenerateWorksheetPartContent(worksheetPart,result);
        }

        public virtual void GenerateWorkbookPartContent(WorkbookPart workbookPart , SpreadsheetDocument document, WorksheetPart worksheetPart)
        {
            Workbook workbook = new Workbook();
            Sheets sheets = new Sheets();
            Sheet sheet = new Sheet() { Name = "sheet 1", SheetId = (UInt32Value)1U, Id = document.WorkbookPart. GetIdOfPart(worksheetPart)
            };
            sheets.Append(sheet);
            workbook.Append(sheets);
            workbookPart.Workbook = workbook;

            workbookPart.Workbook.Save();
        }

        public virtual void GenerateWorksheetPartContent(WorksheetPart worksheetPart, DataTable dataTable)
        {
            Worksheet worksheet = new Worksheet();
            SheetData sheetdata = new SheetData();
            string[] headerColumns = dataTable.Columns.Cast<DataColumn>()
                                 .Select(x => x.ColumnName)
                                 .ToArray();  // GetColumnHeaders(result.Rows[0].GetType());
            Row row = new Row();
            Cell cell = new Cell();
            int RowIndexer = 1;
            int ColumnIndexer = 1;
            row.RowIndex = (UInt32)RowIndexer;
            foreach (var header in headerColumns)
            {
                cell = new Cell();
                cell.CellReference = ColumnAddress(ColumnIndexer) + RowIndexer;
                cell.DataType = CellValues.InlineString;
                cell.InlineString = new InlineString(new Text(header));
               
                row.AppendChild(cell);
                ColumnIndexer++;
            }
            sheetdata.Append(row);
            RowIndexer = 2;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                row = new Row();
                row.RowIndex = (UInt32)RowIndexer;
                ColumnIndexer = 1;
                for (int c = 0; c < dataTable.Columns.Count; c++)
                {
                    cell = new Cell();
                    cell.CellReference = ColumnAddress(ColumnIndexer) + RowIndexer;
                    object value = dataTable.Rows[i][c]; // GenericApiUtility.GetPropertyValue(item, header);
                    cell.DataType = CellValues.InlineString;// GetCellDataType(value);
                    if (value != null)
                    {
                        cell.InlineString = new InlineString(new Text(value.ToString()));
                    }
                    row.AppendChild(cell);
                    ColumnIndexer++;
                }
                RowIndexer++;
                sheetdata.Append(row);
            }
            
            worksheet.Append(sheetdata);
            worksheetPart.Worksheet = worksheet;
        }

        private EnumValue<CellValues> GetCellDataType(object value)
        {
            return CellValues.InlineString;
            
        }

        private string[] GetColumnHeaders(Type type)
        {
            return type.GetProperties().Where(pi => pi.PropertyType.Namespace == "System").Select(pi => pi.Name).ToArray();
        }

        string ColumnAddress(int index)
        {
            index -= 1; //adjust so it matches 0-indexed array rather than 1-indexed column
            int quotient = index / 26;
            if (quotient > 0)
                return ColumnAddress(quotient) + chars[index % 26].ToString();
            else
                return chars[index % 26].ToString();
        }
        private char[] chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        
    }
    
}
