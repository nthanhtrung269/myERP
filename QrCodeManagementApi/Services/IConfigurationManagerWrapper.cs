﻿namespace QrCodeManagementApi.Services
{
    public interface IConfigurationManagerWrapper
    {
        string DisplayEmailName { get; }

        string FromEmail { get; }

        string StatisticDomain { get; }
    }
}