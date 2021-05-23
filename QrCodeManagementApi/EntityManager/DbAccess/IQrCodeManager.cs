using QrCodeManagementApi.Constants;
using QrCodeManagementApi.EntityManager.DbEntity;
using System.Collections.Generic;

namespace QrCodeManagementApi.EntityManager.DbAccess
{
    public interface IQrCodeManager
    {
        bool Insert(QRCode webLinks);

        bool Delete(string id);

        bool Delete(QRCode qrCode);

        bool Update(QRCode qrCode);

        IList<QRCode> GetAll();

        QRCode GetById(string id);

        IList<QRCode> GetByUser(string userId);

        IList<QRCode> GetByQrType(QrType type);

        IList<string> GetLogoByUser(string userId);

        IList<string> GetLogoByLogoName(string logoName);

        IList<QRCode> GetAllArchived();

        IList<QRCode> GetArchivedByUser(string userId);

        IList<string> GetFrameByUser(string userId);

        IList<string> GetFrameByFrameName(string frameName);
    }
}