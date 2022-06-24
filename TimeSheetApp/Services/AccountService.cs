using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetApp.Common;
using TimeSheetApp.Models;
using TimeSheetApp.Models.ViewModel;
using TimeSheetApp.Services.IServices;

namespace TimeSheetApp.Services
{
    public class AccountService:IAccountService
    {
        private readonly ApplicationDbContext _db;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountService(ApplicationDbContext db, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<AuthenticationResponseModel> Register(UserRequestModel userRequestModel)
        {
            var user = new IdentityUser
            {
                UserName = userRequestModel.Username,
                       
            };

            var result = await _userManager.CreateAsync(user, userRequestModel.Password);
            if (result.Succeeded)
            {
                if (!_db.Roles.Any())
                {
                    await _roleManager.CreateAsync(new IdentityRole(SD.admin_Role));
                    await _roleManager.CreateAsync(new IdentityRole(SD.employee_Role));

                }

                await _userManager.AddToRoleAsync(user, userRequestModel.Role);
                await _signInManager.SignInAsync(user, false);
                var newuser= await _userManager.FindByNameAsync(userRequestModel.Username);
                return new AuthenticationResponseModel {username = newuser.UserName, IsAuthSuccessful=true};
            }
            return new AuthenticationResponseModel { IsAuthSuccessful= false};
        }

        public async Task<AuthenticationResponseModel> LogIn(UserAuthenticationRequest userAuthenticationRequest)
        {
            var result = await _signInManager.PasswordSignInAsync(userAuthenticationRequest.Username, userAuthenticationRequest.Password, false, false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(userAuthenticationRequest.Username);
                return new AuthenticationResponseModel {
                    username = user.UserName,
                    
                    IsAuthSuccessful = true
                
                };
            }
            return new AuthenticationResponseModel
            {

                IsAuthSuccessful = false
            }; 
        }
        public async Task Logout()
        {
            await _signInManager.SignOutAsync();

        }

    }
}
