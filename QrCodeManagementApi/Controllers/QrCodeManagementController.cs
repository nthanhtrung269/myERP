using QrCodeManagementApi.Constants;
using QrCodeManagementApi.EntityManager.DbEntity;
using QrCodeManagementApi.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace QrCodeManagementApi.Controllers
{
    public class QrCodeManagementController : ApiController
    {
        private readonly IQrCodeService _qrManagementService;

        public QrCodeManagementController() : this(null)
        {
        }

        public QrCodeManagementController(
            IQrCodeService qrManagementService)
        {
            _qrManagementService = qrManagementService ?? new QrCodeService();
        }

        /// <summary>
        /// Gets the list of QrCode.
        /// Example: https://localhost:44360/api/QrCodeManagement/Manage/?userId=12a429e6-f384-4d62-a381-435147711926
        /// </summary>
        /// <param name="userId">The userId. Example: 12a429e6-f384-4d62-a381-435147711926.</param>
        /// <param name="page">The page.</param>
        /// <param name="keyword">The keyword.</param>
        /// <param name="archived">The archived.</param>
        /// <returns>PagedList{QRCode}.</returns>
        [HttpGet]
        public List<QRCode> Manage(string userId = "", int page = 1, string keyword = "", bool? archived = null)
        {
            var qrCodes = (archived == null || archived == false)
                ? _qrManagementService.GetQrCodeByUser(userId).AsEnumerable()
                : _qrManagementService.GetArchivedQrCodesByUser(userId).AsEnumerable();
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                qrCodes = qrCodes.Where(column => column.Title.ToLower().Contains(keyword.ToLower()));
            }

            var model = qrCodes.Skip((page - 1) * AppConstants.NUMBER_QR_PER_PAGE).Take(AppConstants.NUMBER_QR_PER_PAGE).ToList();
            return model;
        }
    }
}
