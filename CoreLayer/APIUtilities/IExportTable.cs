using System.Data;

namespace Attendleave.Erp.Core.APIUtilities
{
    public interface IExportTable
    {
         string ExportData(DataTable result , string fileName);
    }


}
