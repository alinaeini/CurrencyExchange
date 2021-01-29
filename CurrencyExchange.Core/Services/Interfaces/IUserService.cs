using System;
using System.Threading.Tasks;
using CurrencyExchange.Core.Dtos.Account;

namespace CurrencyExchange.Core.Services.Interfaces
{
    public interface IUserService : IDisposable
    {

        Task<RegisterUserDto.RegisterUserResult> RegisterUser(RegisterUserDto registerUserDto);
        Task<LoginUserResult> LoginUser(LoginUserDto loginUserDto);
        Task EditUSerInfo(UserInfoDto userInfoDto);
        Task<UserInfoDto> GetUserByActivatedCode(string activatedCode);
        Task ActivatedCode(UserInfoDto user);
        Task<UserInfoDto> GetUserById(long userId);
        Task<UserInfoDto> GetUserByUserName(string userName);
        Task<string> GetRoleByUserId(long userId);


    }


}
