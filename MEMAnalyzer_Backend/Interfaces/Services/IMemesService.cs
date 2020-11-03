using MEMAnalyzer_Backend.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MEMAnalyzer_Backend.Interfaces
{
    public interface IMemesService
    {
        Task<List<MemViewModel>> GetAllMemesAsync();

        Task<bool> AddMemAsync(string fileName, long categoryId);
    }
}
