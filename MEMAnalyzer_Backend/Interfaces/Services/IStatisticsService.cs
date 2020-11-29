using MEMAnalyzer_Backend.Business.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MEMAnalyzer_Backend.Interfaces
{
    public interface IStatisticsService
    {
        Task<StatisticViewModel> GetStatisticsAsync(bool? gender, int? startAge, int? endAge, int? lastDays, DateTime currentDate);
    }
}
