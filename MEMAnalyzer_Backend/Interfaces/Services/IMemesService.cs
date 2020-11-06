using MEMAnalyzer_Backend.Business;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MEMAnalyzer_Backend.Interfaces
{
    public interface IMemesService
    {
        Task<List<MemViewModel>> GetAllMemesAsync();

        Task<byte[]> GetMemBytesAsync(string code);

        Task<bool> AddMemAsync(string fileName, long categoryId);

        Task<ResultViewModel> CalculateResultAsync(List<ResultToHandleModel> answers);
    }
}
