using QrCodeManagementApi.EntityManager.DbEntity;
using System.Collections.Generic;

namespace QrCodeManagementApi.EntityManager.DbAccess
{
    public interface IStaticticsManager
    {
        bool Insert(Statictic statictics);

        bool Delete(int id);

        bool Delete(Statictic statictics);

        bool Update(Statictic statictics);

        IList<Statictic> GetAll();

        Statictic GetById(int id);

        IList<Statictic> GetByQrCode(string qrCode);
    }
}