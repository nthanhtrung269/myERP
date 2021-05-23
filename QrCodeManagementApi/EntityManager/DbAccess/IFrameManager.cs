using QrCodeManagementApi.EntityManager.DbEntity;
using System.Collections.Generic;

namespace QrCodeManagementApi.EntityManager.DbAccess
{
    public interface IFrameManager
    {
        bool Insert(Frame logo);

        bool Delete(int id);

        IList<Frame> GetAll();

        Frame GetById(int id);

        IList<Frame> GetByUser(string userId);
    }
}