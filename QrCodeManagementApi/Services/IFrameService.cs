using System.Collections.Generic;
using QrCodeManagementApi.EntityManager.DbEntity;
using QrCodeManagementApi.Models;

namespace QrCodeManagementApi.Services
{
    public interface IFrameService
    {
        Frame InsertFrame(FrameModel frameModel);

        bool DeleteFrame(int id);

        IList<Frame> GetAllFrames();

        Frame GetFrameById(int id);

        IList<Frame> GetFrameByUser(string userId);

        bool FrameIsInUsed(string FrameName);
    }
}