using Entities.Sales;
using Microsoft.AspNetCore.Mvc;
using WebApiBLL.Interfaces.Sales;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesReasonController : Controller
    {
        private readonly ISalesReasonBLL _bll;
        public SalesReasonController(ISalesReasonBLL bll)
        {
            this._bll = bll;
        }

        /// <summary>
        /// Retorna una lista de sales reasons.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<SalesReason> GetAllSalesReason()
        {
            return this._bll.GetAllSalesReasons();
        }

        /// <summary>
        /// Obtener un sales reason por su id.
        /// </summary>
        /// <param name="salesReasonId"></param>
        /// <returns><see cref="SalesReason"/></returns>
        [HttpGet("{salesReasonId}")]
        public async Task<SalesReason> GetSalesReasonById(int salesReasonId)
        {
            return await this._bll.GetSalesReasonById(salesReasonId);
        }

        /// <summary>
        /// Crea un nuevo sales reason
        /// </summary>
        /// <param name="salesReason"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<int> CreateSalesReason(SalesReason salesReason)
        {
            return await this._bll.CreateSalesReason(salesReason.Name, salesReason.ReasonType, salesReason.ModifiedDate);
        }

        /// <summary>
        /// Modifica un sales reason
        /// </summary>
        /// <param name="salesReason"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<int> UpdateSalesReason(SalesReason salesReason)
        {
            return await this._bll.UpdateSalesReason(salesReason.SalesReasonId, salesReason.Name, salesReason.ReasonType, salesReason.ModifiedDate);
        }

        /// <summary>
        /// Eliminar un sales reason
        /// </summary>
        /// <param name="salesReasonId"></param>
        /// <returns></returns>
        [HttpDelete("{salesReasonId}")]
        public async Task<int> DeleteSalesReason(int salesReasonId)
        {
            return await this._bll.DeleteSalesReason(salesReasonId);
        }
    }
}
