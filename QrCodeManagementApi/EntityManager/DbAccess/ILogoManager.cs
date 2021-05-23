using QrCodeManagementApi.EntityManager.DbEntity;
using System.Collections.Generic;

namespace QrCodeManagementApi.EntityManager.DbAccess
{
    public interface ILogoManager
    {
        bool Insert(Logo logo);

        bool Delete(int id);

        IList<Logo> GetAll();

        Logo GetById(int id);

        IList<Logo> GetByUser(string userId);

    }
}