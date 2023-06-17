using Entities.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiBLL.Interfaces.Sales
{
    public interface ISalesReasonBLL
    {
        List<SalesReason> GetAllSalesReasons();
        Task<SalesReason> GetSalesReasonById(int SalesReasonId);
        Task<int> CreateSalesReason(string name, string reasonType, DateTime modifiedDate);
        Task<int> UpdateSalesReason(int salesReasonId, string name, string reasonType, DateTime modifiedDate);
        Task<int> DeleteSalesReason(int salesReasonId);
    }
}
