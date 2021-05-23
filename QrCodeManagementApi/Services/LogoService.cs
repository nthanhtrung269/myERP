using System;
using System.Collections.Generic;
using System.Linq;
using QrCodeManagementApi.EntityManager.DbAccess;
using QrCodeManagementApi.EntityManager.DbEntity;
using QrCodeManagementApi.Models;

namespace QrCodeManagementApi.Services
{
    public class LogoService : ILogoService
    {
        private readonly ILogoManager _logoManager;
        /// <summary>
        /// The constructor is used for the production environment.
        /// </summary>
        public LogoService()
            : this(null)
        {
        }

        /// <summary>
        /// The constructor is used for Unit Testing & DI Container.
        /// </summary>
        /// <param name="logoManager"></param>
        public LogoService(ILogoManager logoManager)
        {
            _logoManager = logoManager ?? new LogoManager();
        }

        public Logo InsertLogo(LogoModel logoModel)
        {
            Logo logo = new Logo
            {
                FileName = logoModel.FileName,
                UserId = logoModel.UserId
            };

            if (_logoManager.Insert(logo))
            {
                return logo;
            }

            return null;
        }

        public bool DeleteLogo(int id)
        {
            return _logoManager.Delete(id);
        }

        public IList<Logo> GetAllLogoes()
        {
            return _logoManager.GetAll();
        }

        public Logo GetLogoById(int id)
        {
            return _logoManager.GetById(id);
        }

        public IList<Logo> GetLogoByUser(string userId)
        {
            return _logoManager.GetByUser(userId);
        }

        public bool LogoIsInUsed(string logoName)
        {
            if (logoName.ToLower().Equals("default_logo.png") || logoName.ToLower().Equals("no_logo.png"))
            {
                return true;
            }
            //Check logo in QR table
            if (new QrCodeManager().GetLogoByLogoName(logoName).Count > 0)
            {
                return true;
            }
            //Check logo in logo table or template
            if (new LogoService().GetAllLogoes().Any(x => x.FileName == logoName))
            {
                return true;
            }
            //Check logo in template table
            if (new TemplateService().GetAllQrTemplate().Any(x => x.EmbedLogo == logoName))
            {
                return true;
            }

            return false;
        }
    }
}