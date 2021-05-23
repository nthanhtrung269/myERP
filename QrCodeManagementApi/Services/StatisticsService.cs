using QrCodeManagementApi.EntityManager.DbAccess;
using QrCodeManagementApi.EntityManager.DbEntity;
using QrCodeManagementApi.Models;
using System;
using System.Collections.Generic;

namespace QrCodeManagementApi.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IStaticticsManager _staticticsManager;
        /// <summary>
        /// The constructor is used for the production environment.
        /// </summary>
        public StatisticsService()
            : this(null)
        {
        }

        /// <summary>
        /// The constructor is used for Unit Testing & DI Container.
        /// </summary>
        /// <param name="staticticsManager"></param>
        public StatisticsService(IStaticticsManager staticticsManager)
        {
            _staticticsManager = staticticsManager ?? new StaticticsManager();
        }

        public bool InsertQrStatistics(StatisticsModel statictics)
        {
            var entity = new Statictic
            {
                City = statictics.City,
                Country = statictics.Country,
                Device = statictics.Device,
                LatTitude = statictics.LatTitude,
                LongTitude = statictics.LongTitude,
                Os = statictics.Os,
                QrId = statictics.QrId,
                ScanDate = statictics.ScanDate
            };

            return _staticticsManager.Insert(entity);
        }

        public bool DeleteQrStatistics(int id)
        {
            return _staticticsManager.Delete(id);
        }

        public bool DeleteQrStatistics(Statictic statictics)
        {
            return _staticticsManager.Delete(statictics);
        }

        public bool UpdateQrStatistics(StatisticsModel statictics)
        {
            throw new NotImplementedException("This function no need to implement");
        }

        public IList<Statictic> GetAllQrStatistics()
        {
            return _staticticsManager.GetAll();
        }

        public Statictic GetQrStatisticsById(int id)
        {
            return _staticticsManager.GetById(id);
        }

        public IList<Statictic> GetQrStatisticsByQrId(string qrId)
        {
            return _staticticsManager.GetByQrCode(qrId);
        }
    }
}