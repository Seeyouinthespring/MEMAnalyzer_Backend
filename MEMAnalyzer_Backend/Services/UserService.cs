using MEMAnalyzer_Backend.Business.BusinessModels;
using MEMAnalyzer_Backend.DBModels;
using MEMAnalyzer_Backend.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using MEMAnalyzer_Backend.Helpers;

namespace MEMAnalyzer_Backend.Services
{
    public class UserService : IUserService
    {
        private readonly ICommonRepository _commonRepository;
        
        public UserService(ICommonRepository commonRepository) 
        {
            _commonRepository = commonRepository;
        }

        public async Task<List<ApplicationUserViewModel>> GetAllUsersAsync()
        {
            var users = await _commonRepository.GetAllAsync<ApplicationUser>();

            return users.MapTo<List<ApplicationUserViewModel>>();
        }
    }
}
