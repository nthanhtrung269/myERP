using System.Collections.Generic;
using QrCodeManagementApi.EntityManager.DbEntity;
using QrCodeManagementApi.Models;

namespace QrCodeManagementApi.Services
{
    public interface IVCardDetailService
    {
        bool InsertVCardDetail(VCardDetail vCardDetailModel);

        bool DeleteVCardDetailById(int id);

        bool UpdateVCardDetail(VCardDetail vCardDetailModel);

        VCardDetail GetVCardDetailById(int id);

        VCardDetail GetVCardDetailByQrId(string qrId);
    }
}