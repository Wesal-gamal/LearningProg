using System.Collections.Generic;
using System.Data;

namespace Attendleave.Erp.Core.APIUtilities
{
    public interface IExport<TEntity> where TEntity : class
    {
         string ExportData(IList<TEntity> result);
        DataTable ConvertToDataTable(IList<TEntity> data);
    }


}
