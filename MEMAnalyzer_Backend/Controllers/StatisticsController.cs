using MEMAnalyzer_Backend.Attributes;
using MEMAnalyzer_Backend.Business.BusinessModels;
using MEMAnalyzer_Backend.Business.Constants;
using MEMAnalyzer_Backend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MEMAnalyzer_Backend.Controllers
{
    [Route("api/Statistics")]
    public class StatisticsController : BaseController
    {
        private readonly IStatisticsService _statisticsService;

        public StatisticsController(IStatisticsService statisticsService) 
        {
            _statisticsService = statisticsService;
        }

        /// <summary>
        /// Get statistc
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = Roles.ADMINISTRATOR)]
        [Swagger200(typeof(StatisticViewModel))]
        public async Task<IActionResult> GetMemes(bool? gender, int? startAge, int? endAge, int? lastDays)
        {
            DateTime currentDate = GetCurrentDate();
            return await GetResultAsync(() => _statisticsService.GetStatisticsAsync(gender, startAge, endAge, lastDays, currentDate));
        }
    }
}
