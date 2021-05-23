using QrCodeManagementApi.EntityManager.DbEntity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace QrCodeManagementApi.EntityManager.DbAccess
{
    public class FrameManager : IFrameManager
    {
        private readonly QRCodeManagementEntities _entity;

        public FrameManager()
        {
            _entity = new QRCodeManagementEntities();
        }

        public bool Insert(Frame frame)
        {
            _entity.Frames.Add(frame);
            _entity.Entry(frame).State = EntityState.Added;
            _entity.SaveChanges();
            return true;
        }

        public bool Delete(Frame frame)
        {
            if (frame != null)
            {
                _entity.Frames.Remove(frame);
                _entity.Entry(frame).State = EntityState.Deleted;
                _entity.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            return Delete(GetById(id));
        }

        public IList<Frame> GetAll()
        {
            return _entity.Frames?.ToList();
        }

        public Frame GetById(int id)
        {
            return _entity.Frames?.Find(id);
        }

        public IList<Frame> GetByUser(string userId)
        {
            return _entity.Frames?.Where(e => e.UserId == userId).ToList();
        }
    }
}