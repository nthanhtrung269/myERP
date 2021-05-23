using System.Collections.Generic;
using QrCodeManagementApi.EntityManager.DbEntity;
using QrCodeManagementApi.Models;

namespace QrCodeManagementApi.Services
{
    public interface ITemplateService
    {
        Template InsertQrTemplate(TemplateModel templateModel);

        bool DeleteQrTemplate(int id);

        bool DeleteQrTemplate(Template template);

        bool UpdateQrTemplate(TemplateModel templateModel);

        IList<Template> GetAllQrTemplate();

        Template GetQrTemplateById(int id);
        
        IList<Template> GetQrTemplateByUser(string userId);

    }
}