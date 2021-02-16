using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyExchange.Core.Dtos.Account;
using CurrencyExchange.Core.Dtos.Account.RolePermissions;
using CurrencyExchange.Core.Sequrity;
using CurrencyExchange.Core.Services.Interfaces;
using CurrencyExchange.Core.Utilities.Convertors;
using CurrencyExchange.Domain.EntityModels.Access;
using CurrencyExchange.Domain.EntityModels.Account;
using CurrencyExchange.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchange.Core.Services.Implementations
{
    public class UserService : IUserService
    {
        #region Constructor
        private readonly IUserRepository _userRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IUserPermissionRepository _userPermissionRepository;
        private readonly IUserRolePermissionRepository _userRolePermissionRepository;
        private readonly IPasswordHelper _passwordHelper;
        private readonly IMailSender _mailSender;
        private readonly IViewRenderService _renderView;



        public UserService(IUserRepository userRepository, IUserRoleRepository userRoleRepository, IUserRolePermissionRepository userRolePermissionRepository, IPasswordHelper passwordHelper, IMailSender mailSender, IViewRenderService renderView, IUserPermissionRepository userPermissionRepository)
        {
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
            _userRolePermissionRepository = userRolePermissionRepository;
            _passwordHelper = passwordHelper;
            _mailSender = mailSender;
            _renderView = renderView;
            _userPermissionRepository = userPermissionRepository;
        }
        #endregion

        #region User Service Methods

            #region Register User

            public async Task<RegisterUserDto.RegisterUserResult> RegisterUser(RegisterUserDto registerUserDto)
            {
                var isUserExist = _userRepository.IsUserExist(registerUserDto.UserName.Trim().ToLowerInvariant());
                if (isUserExist)
                    return RegisterUserDto.RegisterUserResult.UserExist;
                var user = new User
                {
                    Email = registerUserDto.Email.SanitizeText(),
                    FirstName = registerUserDto.FirstName.SanitizeText(),
                    LastName = registerUserDto.LastName.SanitizeText(),
                    EmailActiveCode = Guid.NewGuid().ToString(),
                    UserName = registerUserDto.UserName.SanitizeText(),
                    Password = _passwordHelper.EncodePasswordMd5(registerUserDto.Password)
                };
                await _userRepository.AddEntity(user);
                await _userRepository.SaveChanges();
                var userDto = new RegisterUserDto()
                {
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    EmailActiveCode = user.EmailActiveCode,
                    Password = _passwordHelper.EncodePasswordMd5(registerUserDto.Password)
                };
                var body = await _renderView.RenderToStringAsync("Email/ActivateAccount", userDto);
                _mailSender.Send(userDto.Email.ToLower().Trim(), "سیستم مدیریت فروش ارز-فعالسازی حساب کاربری جدید", body);
                return RegisterUserDto.RegisterUserResult.Success;
            }

            #endregion

            #region Edit User

            public async Task EditUSerInfo(UserInfoDto userInfo)
            {
                var user = await _userRepository.GetEntityById(userInfo.Id);
                _userRepository.UpdateEntity(user);
                await _userRepository.SaveChanges();
            }

            #endregion

            #region Active User

            public async Task ActivatedCode(UserInfoDto userInfoDto)
            {
                var user = await _userRepository.GetEntityById(userInfoDto.Id);
                user.IsActivated = true;
                user.EmailActiveCode = Guid.NewGuid().ToString();
                _userRepository.UpdateEntity(user);
                await _userRepository.SaveChanges();
            }

            public async Task<UserInfoDto> GetUserByActivatedCode(string activatedCode)
            {
                var userInfo = await _userRepository.
                    GetEntities().
                    SingleOrDefaultAsync(x => x.EmailActiveCode == activatedCode);
                return FillUserInfoDto(userInfo, "");
            }

            #endregion

            #region Login User

            public async Task<LoginUserResult> LoginUser(LoginUserDto loginUserDtOs)
            {
                var password = _passwordHelper.EncodePasswordMd5(loginUserDtOs.Password);
                var userLogin = await _userRepository.UserExistByCheckUserName(loginUserDtOs.UserName.Trim().ToLower(), password);
                if (userLogin == null)
                    return LoginUserResult.UserAndPassAreNotValid;
                if (!userLogin.IsActivated)
                    return LoginUserResult.UserIsNotActive;

                var roleName = await GetRoleByUserId(userLogin.Id);
                if (roleName != null && roleName == "")
                    return LoginUserResult.UserDoesNotHAveAnyRoles;

                return LoginUserResult.Success;
            }

            #endregion

            #region Permission Methods

            #region Permission - List By Id

            public async Task<List<UserPermissionDto>> GetUserPermissions(long userId)
            {
                var userRolePermissionDto = new List<UserPermissionDto>();
                var userRole = await _userRoleRepository.GetUserRoleByUserId(userId);
                if (userRole != null)
                {
                    var userPermissions = await _userRolePermissionRepository.GetUserRolePermissionsByUserRoleId(userRole.Id);
                    foreach (var item in userPermissions)
                    {
                        if (item.Permission.ParentId == null)
                        {
                            var list = userPermissions.Where(x => x.Permission.ParentId == item.PermissionId);
                            var listSubMenus = new List<UserRolePermissionDto>();
                            foreach (var subDetail in list)
                            {
                                listSubMenus.Add(new UserRolePermissionDto { AccessLink = subDetail.Permission.AccessLink, PersianName = subDetail.Permission.PersianName });
                            }
                            userRolePermissionDto.Add(new UserPermissionDto { DetaiList = listSubMenus, ParentName = item.Permission.PersianName });
                        }
                    }
                }
                return userRolePermissionDto;
            }

            #endregion

            #region  Permission - List

            public async Task<List<PermissionDto>> GetPermissions(long userId)
            {
                var getPermissions = new List<PermissionDto>();
                var userPermissions = await _userPermissionRepository.GetUserPermissions();
                if (userPermissions != null && userPermissions.Count > 0)
                {
                    foreach (var item in userPermissions)
                    {
                        getPermissions.Add(new PermissionDto
                            { Id = item.Id, ParentId = item.ParentId, DisplayTitle = item.PersianName });
                    }
                }
                return getPermissions;
            }

            #endregion

            #region Permission - Add 

            public async Task<LoginUserResult> InsertToDatabaseRolesAndPermissions(UserAccountPermissions userAccountPermissions)
            {
                #region AddDataToUserRoleAndRolePErmissions

                var userRoles = userAccountPermissions.UserNotRoleList.Where(x => x.RoleName != "0");

                var userRolePermission =
                    userAccountPermissions.RolePermissionListItems.
                        Select(x => new RolePermissionListItems
                        {
                            UserId = x.UserId,
                            PermissionFlatNode = x.PermissionFlatNode.Where(c => c.Selected).ToList()
                        });
                await AddDataToUserRoleAndRolePErmissions(userRoles, userRolePermission);

                #endregion

                await _userRepository.SaveChanges();
                return LoginUserResult.Success;
            }

            #endregion

            #endregion

            #region Get Role By UserId

            public async Task<string> GetRoleByUserId(long userId)
            {
                const string roleName = "";
                var userRole = await _userRoleRepository.GetUserRoleByUserId(userId);
                if (userRole != null)
                    return userRole.Role.Name;
                else
                    return roleName;
            }

            #endregion

            #region Get User Many Types


            public async Task<List<UserInfoDto>> GetActiveUsersExceptCurrentUserIdByUserId(long userId)
            {
                var userListDto = new List<UserInfoDto>();
                var users = await _userRepository.GetActiveUsersExceptCurrentUserIdByCurrentUserId(userId);

                foreach (var itemUser in users)
                {
                    var role = await _userRoleRepository.GetUserRoleByUserId(itemUser.Id);
                    string roleId = null;
                    if (role != null)
                    {
                        roleId = role.RoleId.ToString();
                    }
                    userListDto.Add(new UserInfoDto
                    {
                        Id = itemUser.Id,
                        FirstName = itemUser.FirstName,
                        LastName = itemUser.LastName,
                        UserName = itemUser.UserName,
                        RoleName = roleId
                    });
                }

                return userListDto;
            }

            public async Task<UserInfoDto> GetUserById(long userId)
            {
                var userInfo = await _userRepository.GetEntityById(userId);
                var roleName = await GetRoleByUserId(userInfo.Id);
                if (roleName != null && roleName == "")
                    return FillUserInfoDto(userInfo, roleName);
                else
                    return FillUserInfoDto(userInfo, "");

            }
            public async Task<UserInfoDto> GetUserByUserName(string userName)
            {
                var userInfo = await _userRepository.GetUserByUserName(userName.Trim().ToLower());
                var roleName = await GetRoleByUserId(userInfo.Id);
                if (roleName != null && roleName == "")
                    return FillUserInfoDto(userInfo, roleName);
                else
                    return FillUserInfoDto(userInfo, "");
            }

            public bool IsUserAdminByUserId(long userId)
            {
                return _userRoleRepository.CheckAdminRoleByUserId(userId);
            }

            #endregion

        #endregion

        #region Utilities 

        private UserInfoDto FillUserInfoDto(User userInfo, string roleName)
        {
            var returnValue = new UserInfoDto();
            if (userInfo != null)
            {
                returnValue = new UserInfoDto()
                {
                    Id = userInfo.Id,
                    FirstName = userInfo.FirstName.Trim().SanitizeText(),
                    LastName = userInfo.LastName.Trim().SanitizeText(),
                    Email = userInfo.Email.Trim().SanitizeText(),
                    UserName = userInfo.UserName.Trim().SanitizeText(),
                    RoleName = roleName.Trim().SanitizeText()
                };
            }

            return returnValue;

        }

        private async Task AddDataToUserRoleAndRolePErmissions(IEnumerable<UserInfoDto> userRoles,
            IEnumerable<RolePermissionListItems> userRolePermissions)
        {
            foreach (var userRole in userRoles)
            {
                var existisUserRole = await _userRoleRepository.GetUserRoleByUserId(userRole.Id);
                if (existisUserRole == null)
                {
                    existisUserRole = new UserRole
                        {RoleId = Convert.ToInt64(userRole.RoleName), UserId = userRole.Id};
                    await _userRoleRepository.AddEntity(existisUserRole);
                }
                else
                {
                    existisUserRole.RoleId = Convert.ToInt64(userRole.RoleName);
                    existisUserRole.UserId = userRole.Id;
                    _userRoleRepository.UpdateEntity(existisUserRole);
                }

                if (userRolePermissions.Any(x=>x.UserId == existisUserRole.UserId))
                {
                    await InsertOrUpdateUserRolePermission(userRolePermissions.FirstOrDefault(x => x.UserId == existisUserRole.UserId), existisUserRole);
                }
                


            }
        }
        private async Task InsertOrUpdateUserRolePermission(RolePermissionListItems userRolePermissions,
            UserRole  userRoles)
        {
                    var rolePermissionsByUserRoleId =await _userRolePermissionRepository.GetUserRolePermissionsByUserRoleId(userRoles.Id);
                    if (rolePermissionsByUserRoleId.Count > 0 )
                    {
                        foreach (var removedItem in rolePermissionsByUserRoleId)
                        {
                            _userRolePermissionRepository.RemoveEntity(removedItem);
                        }
                    }    

                foreach (var itemForInsert in userRolePermissions.PermissionFlatNode)
                {
                    var per =await  _userPermissionRepository.GetEntityById(itemForInsert.Id);
                    await _userRolePermissionRepository.AddEntity(new UserRolePermission() { Permission = per, UserRole = userRoles });
                }
                 
        }



        #endregion

        #region Dispose

        public void Dispose()
        {
            _userRepository?.Dispose();
            _userRoleRepository?.Dispose();
            _userRolePermissionRepository?.Dispose();
            _userPermissionRepository?.Dispose();
        }

        #endregion

    }
}
