using MEMAnalyzer_Backend.Business;
using MEMAnalyzer_Backend.DBModels;
using MEMAnalyzer_Backend.Helpers;
using MEMAnalyzer_Backend.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public async Task<bool> AddMemAsync(byte[] bytes, string fileName, long categoryId)
        {
            Mem entity = new Mem()
            {
                Code = fileName.Remove(fileName.IndexOf("."), 4),
                Picture = bytes,
                CategoryId = categoryId
            };
            await _commonRepository.AddAsync(entity);
            await _commonRepository.SaveAsync();

            Mem result = await _commonRepository.FindByIdAsync<Mem>(entity.Id);
            return entity != null;
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
