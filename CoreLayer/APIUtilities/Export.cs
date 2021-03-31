using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Attendleave.Erp.Core.APIUtilities
{
    public class Export<TEntity> : IExport<TEntity> where TEntity : class
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public Export(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public virtual  DataTable ConvertToDataTable(IList<TEntity> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(TEntity));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (TEntity item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
        public virtual string ExportData(IList<TEntity> result)
        {
            var path = _hostingEnvironment.WebRootPath;           
            string filePath = Path.Combine(path, "Downloads", typeof(TEntity).Name+".xlsx");

            using (SpreadsheetDocument ssdocument = SpreadsheetDocument.Create(filePath, SpreadsheetDocumentType.Workbook))
            {
                CreateExcelDocument(ssdocument,  result);
            }
            return filePath;
        }

        public virtual void CreateExcelDocument(SpreadsheetDocument document, IList<TEntity> result)
        {
            WorkbookPart workbookPart = document.AddWorkbookPart();
            GenerateWorkbookPartContent(workbookPart);
            WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>(typeof(TEntity).Name);
            GenerateWorksheetPartContent(worksheetPart,result);
        }

        public virtual void GenerateWorkbookPartContent(WorkbookPart workbookPart)
        {
            Workbook workbook = new Workbook();
            Sheets sheets = new Sheets();
            Sheet sheet = new Sheet() { Name = typeof(TEntity).Name, SheetId = (UInt32Value)1U, Id = typeof(TEntity).Name };
            sheets.Append(sheet);
            workbook.Append(sheets);
            workbookPart.Workbook = workbook;
        }

        public virtual void GenerateWorksheetPartContent(WorksheetPart worksheetPart,IList<TEntity> result)
        {
            Worksheet worksheet = new Worksheet();
            SheetData sheetdata = new SheetData();
            string[] headerColumns = GetColumnHeaders(result.ElementAt(0).GetType());
            Row row = new Row();
            Cell cell = new Cell();
            int RowIndexer = 1;
            int ColumnIndexer = 1;
            row.RowIndex = (UInt32)RowIndexer;
            foreach (var header in headerColumns)
            {
                cell = new Cell();
                cell.CellReference = ColumnAddress(ColumnIndexer) + RowIndexer;
                cell.DataType = GetCellDataType(header);
                cell.InlineString = new InlineString(new Text(header));
                // consider using cell.CellValue. Then you don't need to use InlineString.
                // Because it seems you're not using any rich text so you're just bloating up
                // the XML.
                row.AppendChild(cell);
                ColumnIndexer++;
            }
            sheetdata.Append(row);
            RowIndexer = 2;
            foreach (var item in result)
            {
                row = new Row();
                row.RowIndex = (UInt32)RowIndexer;
                // this follows the same starting column index as your column header.
                // I'm assuming you start with column 1. Change as you see fit.
                ColumnIndexer = 1;
                foreach (string header in headerColumns)
                {
                    cell = new Cell();
                    // I moved it here so it's consistent with the above part
                    // Also, the original code was using the row index to calculate
                    // the column name, which is weird.
                    cell.CellReference = ColumnAddress(ColumnIndexer) + RowIndexer;
                    object value = GenericApiUtility.GetPropertyValue(item, header);
                    cell.DataType = GetCellDataType(value);
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
            //if (value is DateTime)
            //{
            //    return CellValues.Date;
            //}
            //else if (value is sbyte || value is byte || value is short || value is ushort || value is int
            //        || value is uint || value is long || value is ulong || value is float || value is double 
            //        || value is decimal)
            //{
            //    return CellValues.Number;
            //}
            //else if (value is Boolean)
            //{
            //    return CellValues.Boolean;
            //}
            //else
            //{
            //    return CellValues.InlineString;
            //}
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
    public class GenericApiUtility
    {
        public static object GetPropertyValue(object entity, string propertyName)
        {
            Type type = entity.GetType();

            PropertyInfo propertyInfo = type.GetProperties().Where(x => x.Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase)).SingleOrDefault();
            if (propertyInfo != null)
            {
                return propertyInfo.GetValue(entity);
            }
            return null;
        }

        public static object GetFieldValue(object entity, string fieldName)
        {
            Type type = entity.GetType();
            FieldInfo fieldInfo = type.GetFields().Where(x => x.Name.Equals(fieldName, StringComparison.OrdinalIgnoreCase)).SingleOrDefault();
            if (fieldInfo != null)
            {
                return fieldInfo.GetValue(entity);
            }
            return null;
        }

        
    }


}
