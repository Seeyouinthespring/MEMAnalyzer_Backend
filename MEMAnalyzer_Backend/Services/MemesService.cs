using MEMAnalyzer_Backend.Business;
using MEMAnalyzer_Backend.DBModels;
using MEMAnalyzer_Backend.Helpers;
using MEMAnalyzer_Backend.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MEMAnalyzer_Backend.Services
{
    public class MemesService : IMemesService
    {
        private readonly ICommonRepository _commonRepository;

        public MemesService(ICommonRepository commonRepository) 
        {
            _commonRepository = commonRepository;
        }

        public async Task<bool> AddMemAsync(string fileName, long categoryId)
        {
            Mem entity = new Mem()
            {
                Code = fileName,
                Picture = null,
                CategoryId = categoryId
            };
            await _commonRepository.AddAsync(entity);
            await _commonRepository.SaveAsync();

            Mem result = await _commonRepository.FindByIdAsync<Mem>(entity.Id);
            return result != null;
        }

        public async Task<ResultViewModel> CalculateResultAsync(List<ResultToHandleModel> answers, string userId, DateTime currentDate)
        {
            var oldResult = await _commonRepository.FindByCondition<Result>(x => x.UserId == userId)
                .Include(x => x.Answers)
                .FirstOrDefaultAsync();
            if (oldResult != null)
                await DeleteOldRsultAsync(oldResult);

            List<Mem> existingMemes = await _commonRepository.GetAll<Mem>()
                .Include(x => x.Category)
                .ToListAsync();

            if (existingMemes.Count != answers.Count)
                return null;

            Result resultEntity = new Result();
            for (int i = 1; i < 6; i++) 
            {
                List<int> marksOfMemesForCategory = new List<int>();

                foreach (ResultToHandleModel res in answers) 
                {
                    if (existingMemes.Where(m => m.Category.Order == i).Select(x => x.Id).ToHashSet().Contains(res.MemId.Value))
                        marksOfMemesForCategory.Add(res.Mark);
                }

                double percentage = marksOfMemesForCategory.Sum() / ((double)marksOfMemesForCategory.Count() * 5) * 100;
                switch (i) 
                {
                    case 1:
                        resultEntity.CategoryOnePercentage = percentage;
                        break;
                    case 2:
                        resultEntity.CategorytwoPercentage = percentage;
                        break;
                    case 3:
                        resultEntity.CategoryThreePercentage = percentage;
                        break;
                    case 4:
                        resultEntity.CategoryFourPercentage = percentage;
                        break;
                    case 5:
                        resultEntity.CategoryFivePercentage = percentage;
                        break;
                }    
            }
            resultEntity.Date = currentDate;

            var resultModel = resultEntity.MapTo<ResultViewModel>();
            Statement statement = await DefineStatement(resultModel);
            resultModel.Statement = statement.Text;

            if (userId == null)
                return resultModel;

            resultEntity.StatementId = statement.Id;
            resultEntity.UserId = userId;
            resultEntity.Answers = answers.MapTo<List<Answer>>();
            await _commonRepository.AddAsync(resultEntity);
            await _commonRepository.SaveAsync();
             
            return resultModel;
        }

        private async Task DeleteOldRsultAsync(Result oldResult)
        {
            _commonRepository.DeleteAll(oldResult.Answers);
            await _commonRepository.DeleteAsync<Result>(oldResult.Id);
            await _commonRepository.SaveAsync();
        }

        private async Task<Statement> DefineStatement(ResultViewModel resultModel)
        {
            List<double> sortArray = new List<double>()
            {
                resultModel.Domestic,
                resultModel.Popular,
                resultModel.Pointless,
                resultModel.Intellectual,
                resultModel.Conservative
            };
            sortArray.Sort();
            if (sortArray.Last() < 45)
                return await _commonRepository.FindByCondition<Statement>(x => x.OfficialCode == Statements.NEGATION).FirstOrDefaultAsync();
            if (sortArray.First() > 75 || sortArray.Last() == sortArray[^2])
                return await _commonRepository.FindByCondition<Statement>(x => x.OfficialCode == Statements.UNPRETENTIOUSNESS).FirstOrDefaultAsync();
            if (sortArray.Last() == resultModel.Domestic)
                return await _commonRepository.FindByCondition<Statement>(x => x.OfficialCode == Statements.DOMESTIC).FirstOrDefaultAsync();
            if (sortArray.Last() == resultModel.Popular)
                return await _commonRepository.FindByCondition<Statement>(x => x.OfficialCode == Statements.POPULAR).FirstOrDefaultAsync();
            if (sortArray.Last() == resultModel.Pointless)
                return await _commonRepository.FindByCondition<Statement>(x => x.OfficialCode == Statements.POINTLESS).FirstOrDefaultAsync();
            if (sortArray.Last() == resultModel.Intellectual)
                return await _commonRepository.FindByCondition<Statement>(x => x.OfficialCode == Statements.INTELLECTUAL).FirstOrDefaultAsync();
            else// (sortArray.Last() == resultModel.Conservative)
                return await _commonRepository.FindByCondition<Statement>(x => x.OfficialCode == Statements.CONSERVATIVE).FirstOrDefaultAsync();
        }

        public async Task<List<MemViewModel>> GetAllMemesAsync() 
        {
            List<Mem> memes = await _commonRepository.GetAll<Mem>()
                .Include(x => x.Category)
                .ToListAsync();

            return memes.MapTo<List<MemViewModel>>();
        }

        public async Task<MemWithCategoryViewModel> UpdateMemAsync(long id, MemDtoModel model) 
        {
            var entity = await _commonRepository.FindByCondition<Mem>(x => x.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            if (entity == null)
                return null;
            entity = model.MapTo<Mem>();
            entity.Picture = null;
            entity.Id = id;

            _commonRepository.Update(entity);
            await _commonRepository.SaveAsync();
            return await GetMemByIdAsync(id);
        }

        public async Task<MemWithCategoryViewModel> GetMemByIdAsync(long id)
        {
            var entity = await _commonRepository.FindByCondition<Mem>(x => x.Id == id)
                .Include(x => x.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            if (entity == null)
                return null;
            return entity.MapTo<MemWithCategoryViewModel>();
        }

        public async Task<byte[]> GetMemBytesAsync(string code)
        {
            Mem mem = await _commonRepository.FindFirstByConditionAsync<Mem>(x => x.Code == code);
            if (mem == null)
                return null;
            return mem.Picture;
        }

        public async Task<MemViewModel> GetRandomMemAsync()
        {
            List<Mem> memes = await _commonRepository.GetAllAsync<Mem>();
            Random rnd = new Random();
            int randomValue = rnd.Next(0, memes.Count() - 1);
            return memes[randomValue].MapTo<MemViewModel>();
        }
    }
}
