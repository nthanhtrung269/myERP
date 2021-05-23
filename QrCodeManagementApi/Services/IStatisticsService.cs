using System.Collections.Generic;
using QrCodeManagementApi.EntityManager.DbEntity;
using QrCodeManagementApi.Models;

namespace QrCodeManagementApi.Services
{
    public interface IStatisticsService
    {
        bool InsertQrStatistics(StatisticsModel statictics);

        bool DeleteQrStatistics(int id);

        bool DeleteQrStatistics(Statictic statictics);

        bool UpdateQrStatistics(StatisticsModel statictics);

        IList<Statictic> GetAllQrStatistics();

        Statictic GetQrStatisticsById(int id);

        IList<Statictic> GetQrStatisticsByQrId(string qrId);

    }
}