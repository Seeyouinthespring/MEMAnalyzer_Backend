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

        public async Task<List<MemViewModel>> GetAllMemesAsync() 
        {
            List<Mem> memes = await _commonRepository.GetAll<Mem>()
                .Include(x => x.Category)
                .ToListAsync();

            return memes.MapTo<List<MemViewModel>>();
        }
    }
}
