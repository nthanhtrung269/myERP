using QrCodeManagementApi.EntityManager.DbEntity;
using System.Collections.Generic;

namespace QrCodeManagementApi.EntityManager.DbAccess
{
    public interface ITemplateManager
    {
        bool Insert(Template template);

        bool Delete(int id);

        bool Delete(Template template);

        bool Update(Template template);

        IList<Template> GetAll();

        Template GetById(int id);

        IList<Template> GetByUser(string userId);

    }
}