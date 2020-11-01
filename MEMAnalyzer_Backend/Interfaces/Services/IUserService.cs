using MEMAnalyzer_Backend.Business.BusinessModels;
using MEMAnalyzer_Backend.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MEMAnalyzer_Backend.Interfaces
{
    public interface IUserService
    {
        Task<List<ApplicationUserViewModel>> GetAllUsersAsync();
    }
}
