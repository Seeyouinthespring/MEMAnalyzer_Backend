using MEMAnalyzer_Backend.Business;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MEMAnalyzer_Backend.Interfaces
{
    public interface IUserService
    {
        Task<List<ApplicationUserViewModel>> GetAllUsersAsync();
    }
}
