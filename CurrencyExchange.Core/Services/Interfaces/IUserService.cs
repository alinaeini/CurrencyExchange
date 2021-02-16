using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CurrencyExchange.Core.Dtos.Account;
using CurrencyExchange.Core.Dtos.Account.RolePermissions;
using CurrencyExchange.Domain.EntityModels.Access;

namespace CurrencyExchange.Core.Services.Interfaces
{
    public interface IUserService : IDisposable
    {
        public Task<RegisterUserDto.RegisterUserResult> RegisterUser(RegisterUserDto registerUserDto);
        public Task<LoginUserResult> LoginUser(LoginUserDto loginUserDto);
        public Task EditUSerInfo(UserInfoDto userInfoDto);
        public Task<UserInfoDto> GetUserByActivatedCode(string activatedCode);
        public Task ActivatedCode(UserInfoDto user);
        public Task<UserInfoDto> GetUserById(long userId);
        public Task<UserInfoDto> GetUserByUserName(string userName);
        public Task<string> GetRoleByUserId(long userId);
        public Task<List<UserPermissionDto>> GetUserPermissions(long userId);

        public Task<List<UserInfoDto>> GetActiveUsersExceptCurrentUserIdByUserId(long userId);
        public Task<List<PermissionDto>> GetPermissions(long userId);
        public Task<LoginUserResult> InsertToDatabaseRolesAndPermissions(UserAccountPermissions userAccountPermissions);
    }
}