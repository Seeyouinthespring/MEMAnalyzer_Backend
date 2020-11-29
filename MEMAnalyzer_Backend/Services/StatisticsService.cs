using MEMAnalyzer_Backend.Business;
using MEMAnalyzer_Backend.Business.BusinessModels;
using MEMAnalyzer_Backend.DBModels;
using MEMAnalyzer_Backend.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MEMAnalyzer_Backend.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly ICommonRepository _commonRepository;

        public StatisticsService(ICommonRepository commonRepository)
        {
            _commonRepository = commonRepository;
        }

        public async Task<StatisticViewModel> GetStatisticsAsync(bool? gender, int? startAge, int? endAge, int? lastDays, DateTime currentDate)
        {
            var users = await _commonRepository.FindByCondition<ApplicationUser>(x => x.Results.FirstOrDefault() != null)
                .Include(x => x.Results).ThenInclude(x => x.Stetement)
                .ToListAsync();
            if (users == null) return null;

            if (gender != null)
                users = users.FindAll(x => x.Gender == gender);

            if (startAge != null)
                users = users.FindAll(x => currentDate >= x.BirthDate.AddYears(startAge.Value));

            if (endAge != null)
                users = users.FindAll(x => currentDate <= x.BirthDate.AddYears(endAge.Value));

            if (lastDays != null)
                users = users.FindAll(x => x.Results.FirstOrDefault().Date >= currentDate.AddDays(-lastDays.Value));

            if (users.Count == 0) return null;

            int resultsNumber = users.Count();

            StatisticViewModel statistic = new StatisticViewModel 
            {
                All = resultsNumber,
                PopularNumber = users.Count(x => x.Results.FirstOrDefault().Stetement.OfficialCode == Statements.POPULAR),
                PointlessNumber = users.Count(x => x.Results.FirstOrDefault().Stetement.OfficialCode == Statements.POINTLESS),
                DomesticNumber = users.Count(x => x.Results.FirstOrDefault().Stetement.OfficialCode == Statements.DOMESTIC),
                IntellectualNumber = users.Count(x => x.Results.FirstOrDefault().Stetement.OfficialCode == Statements.INTELLECTUAL),
                ConservativeNumber = users.Count(x => x.Results.FirstOrDefault().Stetement.OfficialCode == Statements.CONSERVATIVE),
                NegationNumber = users.Count(x => x.Results.FirstOrDefault().Stetement.OfficialCode == Statements.NEGATION),
                UnpretentiousnessNumber = users.Count(x => x.Results.FirstOrDefault().Stetement.OfficialCode == Statements.UNPRETENTIOUSNESS),

                PopularPersentage = users.Count(x => x.Results.FirstOrDefault().Stetement.OfficialCode == Statements.POPULAR) / (double)resultsNumber * 100,
                PointlessPersentage = users.Count(x => x.Results.FirstOrDefault().Stetement.OfficialCode == Statements.POINTLESS) / (double)resultsNumber * 100,
                DomesticPersentage = users.Count(x => x.Results.FirstOrDefault().Stetement.OfficialCode == Statements.DOMESTIC) / (double)resultsNumber * 100,
                IntellectualPersentage = users.Count(x => x.Results.FirstOrDefault().Stetement.OfficialCode == Statements.INTELLECTUAL) / (double)resultsNumber * 100,
                ConservativePersentage = users.Count(x => x.Results.FirstOrDefault().Stetement.OfficialCode == Statements.CONSERVATIVE) / (double)resultsNumber * 100,
                NegationPersentage = users.Count(x => x.Results.FirstOrDefault().Stetement.OfficialCode == Statements.NEGATION) / (double)resultsNumber * 100,
                UnpretentiousnessPersentage = users.Count(x => x.Results.FirstOrDefault().Stetement.OfficialCode == Statements.UNPRETENTIOUSNESS) / (double)resultsNumber * 100
            };
            return statistic;
        }
    }
}
