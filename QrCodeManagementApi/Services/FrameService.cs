using System;
using System.Collections.Generic;
using System.Linq;
using QrCodeManagementApi.EntityManager.DbAccess;
using QrCodeManagementApi.EntityManager.DbEntity;
using QrCodeManagementApi.Models;

namespace QrCodeManagementApi.Services
{
    public class FrameService : IFrameService
    {
        private readonly IFrameManager _frameManager;
        /// <summary>
        /// The constructor is used for the production environment.
        /// </summary>
        public FrameService()
            : this(null)
        {
        }

        /// <summary>
        /// The constructor is used for Unit Testing & DI Container.
        /// </summary>
        /// <param name="frameManager"></param>
        public FrameService(IFrameManager frameManager)
        {
            _frameManager = frameManager ?? new FrameManager();
        }


        public Frame InsertFrame(FrameModel frameModel)
        {
            Frame frame = new Frame
            {
                FileName = frameModel.FileName,
                UserId = frameModel.UserId
            };

            if (_frameManager.Insert(frame))
            {
                return frame;
            }

            return null;
        }

        public bool DeleteFrame(int id)
        {
            return _frameManager.Delete(id);
        }

        public IList<Frame> GetAllFrames()
        {
            return _frameManager.GetAll();
        }

        public Frame GetFrameById(int id)
        {
            return _frameManager.GetById(id);
        }

        public IList<Frame> GetFrameByUser(string userId)
        {
            return _frameManager.GetByUser(userId);
        }

        public bool FrameIsInUsed(string frameName)
        {
            if (frameName.ToLower().Contains("default_frame")
                || frameName.ToLower().Equals("no_frame.png"))
            {
                return true;
            }

            // Check Frame in QR table
            if (new QrCodeManager().GetFrameByFrameName(frameName).Count > 0)
            {
                return true;
            }

            // Check Frame in Frame table or template
            if (new FrameService().GetAllFrames().Any(x => x.FileName == frameName))
            {
                return true;
            }

            return false;
        }
    }
}