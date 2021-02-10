using CurrencyExchange.Core.Dtos.Account;
using CurrencyExchange.Core.Services.Interfaces;
using CurrencyExchange.Core.Utilities.Common;
using CurrencyExchange.Core.Utilities.Extensions;
using CurrencyExchange.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.WebApi.Controllers
{
    public class AccountController : AppBaseController
    {
        #region Constructor

        private IUserService userService;

        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }

        #endregion

        #region Create

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto registerUserDto)
        {
            if (ModelState.IsValid)
            {
                var res = await userService.RegisterUser(registerUserDto);
                switch (res)
                {
                    case RegisterUserDto.RegisterUserResult.UserExist:
                        return JsonResponseStatus.Error(new {Info = "نام کاربری شما در سیستم قبلا ثبت شده است"});
                }
            }

            return JsonResponseStatus.Success();
        }

        #endregion

        #region Activate User

        [HttpGet("activate-account/{id}")]
        public async Task<IActionResult> ActiveUser(string id)
        {
            if (ModelState.IsValid)
            {
                var user = await userService.GetUserByActivatedCode(id);
                if (user != null)
                {
                    await userService.ActivatedCode(user);
                    return JsonResponseStatus.Success();
                }
            }

            return JsonResponseStatus.NotFound();
        }

        #endregion

        #region Login

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto loginUserDtOs)
        {
            if (ModelState.IsValid)
            {
                var res = await userService.LoginUser(loginUserDtOs);
                switch (res)
                {
                    case LoginUserResult.UserAndPassAreNotValid:
                        return JsonResponseStatus.Error(new {Info = "اطلاعات وارد شده نادرست میباشد"});

                    case LoginUserResult.UserIsNotActive:
                        return JsonResponseStatus.Error(new {Info = "نام کاربری وارد شده فعال نیست"});

                    case LoginUserResult.UserDoesNotHAveAnyRoles:
                        return JsonResponseStatus.Error(new
                            {Info = "هیچ نقشی به کاربر انتخاب شده , اختصاص داده نشده است"});

                    case LoginUserResult.Success:
                        var user = await userService.GetUserByUserName(loginUserDtOs.UserName);
                        var roleName = await userService.GetRoleByUserId(user.Id);
                        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("AngularExchangeJwtBearer"));
                        var signinCredential = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                        var claimList = new List<Claim>()
                        {
                            new Claim(ClaimTypes.Name, user.UserName),
                            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                        };
                        var userIdentity = new ClaimsIdentity(user.Id.ToString());
                        userIdentity.AddClaims(claimList);
                        var tokenOptions = new JwtSecurityToken(
                            issuer: "https://localhost:5001/",
                            expires: DateTime.Now.AddDays(1),
                            signingCredentials: signinCredential,
                            claims: claimList
                        );

                        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                        var userPermissions = await userService.GetUserPermissions(user.Id);
                        return JsonResponseStatus.Success(new
                        {
                            token = tokenString,
                            expireTime = 1,
                            firstName = user.FirstName,
                            lastName = user.LastName,
                            userId = user.Id,
                            userRole = roleName,
                            userPermissions= userPermissions
                        });
                }
            }

            return JsonResponseStatus.Success();
        }

        #endregion

        #region Check User Authentication

        [HttpPost("check-auth")]
        public async Task<IActionResult> CheckUserAuth()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.GetUserId();
                var userInfo = await userService.GetUserById(userId);
                var roleName = await userService.GetRoleByUserId(userId);
                var userPermissions = await userService.GetUserPermissions(userId);
                var returnJson = JsonResponseStatus.Success(new
                {
                    id = userInfo.Id,
                    firstName = userInfo.FirstName,
                    lastName = userInfo.LastName,
                    userName = userInfo.UserName,
                    userRole = roleName,
                    userPermissions = userPermissions
                });
                return returnJson;
            }

            return JsonResponseStatus.Error(new {Info = "کاربر مورد نظر در سیستم لاگین نیست"});
        }

        #endregion

        #region Sgin Out

        [HttpGet("signout")]
        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync();
                return JsonResponseStatus.Success();
            }

            return JsonResponseStatus.Error();
        }

        #endregion

        #region EditUser

        [HttpPost("edit-user")]
        public async Task<IActionResult> EditUser([FromBody] EditUserDto editUserDto)
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.GetUserId();
                {
                    var user = await userService.GetUserById(userId);
                    user.FirstName = editUserDto.FirstName;
                    user.LastName = editUserDto.LastName;
                    await userService.EditUSerInfo(user);
                    return JsonResponseStatus.Success();
                }
            }

            return JsonResponseStatus.Error(new {Info = "کاربر ویرایش نشد "});
        }

        #endregion

        #region userRole

        [HttpPost("users-any-roles")]
        public async Task<IActionResult> UsersHaveNotRoles()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userList = await userService.GetUsersThatAnyRoles(User.GetUserId());
                if (userList.Count > 0 )
                    return JsonResponseStatus.Success(userList);
            }
            return JsonResponseStatus.Error(new { Info = "کاربر مورد نظر در سیستم یافت نشد" });
        }

        #endregion
    }
}