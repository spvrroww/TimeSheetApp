using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetApp.Models.ViewModel;

namespace TimeSheetApp.Services.IServices
{
    public interface IAccountService
    {
        public Task<AuthenticationResponseModel> Register(UserRequestModel userRequestModel);
        public Task<AuthenticationResponseModel> LogIn(UserAuthenticationRequest userAuthenticationRequest);
        public Task Logout();

    }
}
