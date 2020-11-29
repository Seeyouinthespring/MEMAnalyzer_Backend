using MEMAnalyzer_Backend.Business;
using MEMAnalyzer_Backend.DBModels;
using MEMAnalyzer_Backend.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using MEMAnalyzer_Backend.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using MEMAnalyzer_Backend.Business.Constants;
using AutoMapper;

namespace MEMAnalyzer_Backend.Services
{
    public class UserService : IUserService
    {
        private readonly ICommonRepository _commonRepository;

        public UserService(ICommonRepository commonRepository)
        {
            _commonRepository = commonRepository;
        }

        public async Task<BlockingStatus> BlockUserByIdAsync(string id)
        {
            var entity = await _commonRepository.FindByCondition<ApplicationUser>(x => x.Id == id)
                .Include(x => x.IdentityRole)
                .FirstOrDefaultAsync();
            if (entity == null) return BlockingStatus.NotFound;

            if (entity.IdentityRole.Name == Roles.ADMINISTRATOR) return BlockingStatus.Admin;

            if (entity.LockoutEnd == null || entity.LockoutEnd < DateTime.Today)
            {
                entity.LockoutEnd = DateTime.Today.AddDays(7);
                _commonRepository.Update(entity);
                await _commonRepository.SaveAsync();
                return BlockingStatus.Success;
            }
            return BlockingStatus.AlreadyBanned;
        }

        public async Task<List<ApplicationUserViewModel>> GetAllUsersAsync(string search, bool? gender, int? startAge, int? endAge, DateTime currentDate)
        {
            search = search?.ToUpper();
            var usersQuery = _commonRepository.FindByCondition<ApplicationUser>(x =>
                string.IsNullOrEmpty(search) ||
                x.NormalizedUserName.Contains(search) ||
                x.NormalizedEmail.Contains(search) ||
                x.FullName.ToUpper().Contains(search));

            if (gender != null) 
                usersQuery = usersQuery.Where(x => x.Gender == gender);

            if (startAge != null)
                usersQuery = usersQuery.Where(x => currentDate >= x.BirthDate.AddYears(startAge.Value));

            if (endAge != null)
                usersQuery = usersQuery.Where(x => currentDate <= x.BirthDate.AddYears(endAge.Value));
            
            var users = await usersQuery.ToListAsync();
            return users.MapTo<List<ApplicationUserViewModel>>();
        }

        public async Task<ApplicationUserWithResultViewModel> GetUserByIdAsync(string id)
        {
            var entity = await _commonRepository.FindByCondition<ApplicationUser>(x => x.Id == id)
                .Include(x => x.Results).ThenInclude(x => x.Stetement)
                .Include(x => x.IdentityRole)
                .FirstOrDefaultAsync();

            if (entity == null)
                return null;
            
            var model = entity.MapTo<ApplicationUserWithResultViewModel>();
            return model;
        }

        public ApplicationUser GetUserByNameAsync(string name)
        {
            var entity = _commonRepository.FindByCondition<ApplicationUser>(x => x.NormalizedUserName == name.ToUpper())
                .Include(x => x.Results).ThenInclude(x => x.Stetement)
                .FirstOrDefault();

            if (entity == null)
                return null;
            return entity;
        }

        public async Task<ApplicationUserWithResultViewModel> UpdateUserAsync(string id, ApplicationUserDtoModel model)
        {
            var entity = await _commonRepository.FindByIdAsync<ApplicationUser>(id);

            if (entity == null)
                return null;

            entity = Mapper.Map(model, entity);
            entity.NormalizedEmail = entity.Email.ToUpper();
            _commonRepository.Update(entity);
            await _commonRepository.SaveAsync();
            return await GetUserByIdAsync(entity.Id);
        }
    }
}
