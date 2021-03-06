﻿using MEMAnalyzer_Backend.Business;
using MEMAnalyzer_Backend.DBModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MEMAnalyzer_Backend.Interfaces
{
    public enum BlockingStatus
    {
        Success,
        Admin,
        NotFound,
        AlreadyBanned
    }

    public interface IUserService
    {
        Task<List<ApplicationUserViewModel>> GetAllUsersAsync(string search, bool? gender, int? startAge, int? endAge, DateTime currentDate);

        Task<ApplicationUserWithResultViewModel> GetUserByIdAsync(string id);

        ApplicationUser GetUserByNameAsync(string name);

        Task<BlockingStatus> BlockUserByIdAsync(string id);

        Task<ApplicationUserWithResultViewModel> UpdateUserAsync(string id, ApplicationUserDtoModel model);
    }
}
