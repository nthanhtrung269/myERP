using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using QrCodeManagementApi.Constants;
using QrCodeManagementApi.EntityManager;
using QrCodeManagementApi.EntityManager.DbEntity;
using QrCodeManagementApi.Models;

namespace QrCodeManagementApi.Services
{
    public interface IQrCodeService
    {
        bool InsertQrCode(QrCodeModel qrCodeModel);

        bool DeleteQrCode(string id);

        bool DeleteQrCode(QRCode qrCode);

        bool UpdateQrCode(QrCodeModel qrCodeModel);

        IList<QRCode> GetAllQrCode();

        QRCode GetQrCodeById(string id);
        
        IList<QRCode> GetQrCodeByUser(string userId);
        
        IList<QRCode> GetQrCodeByQrType(QrType type);

        IList<string> GetPhotoListByUser(string userId);

        bool ArchiveQrCode(string qrId);

        bool RestoreQrCode(string qrId);

        IList<QRCode> GetAllArchivedQrCodes();

        IList<QRCode> GetArchivedQrCodesByUser(string userId);
    }
}