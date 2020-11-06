using MEMAnalyzer_Backend.Business;
using MEMAnalyzer_Backend.DBModels;
using MEMAnalyzer_Backend.Helpers;
using MEMAnalyzer_Backend.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public async Task<ResultViewModel> CalculateResultAsync(List<ResultToHandleModel> answers)
        {
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

            var resultModel = resultEntity.MapTo<ResultViewModel>();
            resultModel.Statement = DefineStatement(resultModel);

            resultEntity.Answers = answers.MapTo<List<Answer>>();
            await _commonRepository.AddAsync(resultEntity);
            await _commonRepository.SaveAsync();
             
            return resultModel;
        }

        private string DefineStatement(ResultViewModel resultModel)
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
                return Statements.NEGATION;
            if (sortArray.First() > 75 || sortArray.Last() == sortArray[^2])
                return Statements.UNPRETENTIOUSNESS;
            if (sortArray.Last() == resultModel.Domestic)
                return Statements.DOMESTIC;
            if (sortArray.Last() == resultModel.Popular)
                return Statements.POPULAR;
            if (sortArray.Last() == resultModel.Pointless)
                return Statements.POINTLESS;
            if (sortArray.Last() == resultModel.Intellectual)
                return Statements.INTELLECTUAL;
            if (sortArray.Last() == resultModel.Conservative)
                return Statements.CONSERVATIVE;
            return "i dont even know";
        }

        public async Task<List<MemViewModel>> GetAllMemesAsync() 
        {
            List<Mem> memes = await _commonRepository.GetAll<Mem>()
                .Include(x => x.Category)
                .ToListAsync();

            return memes.MapTo<List<MemViewModel>>();
        }

        public async Task<byte[]> GetMemBytesAsync(string code)
        {
            Mem mem = await _commonRepository.FindFirstByConditionAsync<Mem>(x => x.Code == code);
            if (mem == null)
                return null;
            return mem.Picture;
        }
    }
}
