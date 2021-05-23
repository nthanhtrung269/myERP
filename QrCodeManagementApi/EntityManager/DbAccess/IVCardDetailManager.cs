using QrCodeManagementApi.EntityManager.DbEntity;
using System.Collections.Generic;

namespace QrCodeManagementApi.EntityManager.DbAccess
{
    public interface IVCardDetailManager
    {
        bool Insert(VCardDetail vCardDetail);

        bool Delete(int id);

        bool Delete(VCardDetail vCardDetail);

        bool Update(VCardDetail vCardDetail);

        IList<VCardDetail> GetAll();

        VCardDetail GetById(int id);

        VCardDetail GetByQrId(string qrId);
    }
}