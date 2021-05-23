using System.Collections.Generic;
using QrCodeManagementApi.EntityManager.DbEntity;
using QrCodeManagementApi.Models;

namespace QrCodeManagementApi.Services
{
    public interface ILogoService
    {
        Logo InsertLogo(LogoModel logoModel);

        bool DeleteLogo(int id);
        
        IList<Logo> GetAllLogoes();

        Logo GetLogoById(int id);
        
        IList<Logo> GetLogoByUser(string userId);

        bool LogoIsInUsed(string logoName);
    }
}