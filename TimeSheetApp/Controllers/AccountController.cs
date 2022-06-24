using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetApp.Common;
using TimeSheetApp.Models.ViewModel;
using TimeSheetApp.Services.IServices;

namespace TimeSheetApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public  async Task<IActionResult> Login(UserAuthenticationRequest userAuthenticationRequest)
        {
            if (ModelState.IsValid)
            {
                var result =await _accountService.LogIn(userAuthenticationRequest);
                if (result.IsAuthSuccessful)
                {
                    HttpContext.Session.SetString("ssuserid", result.username);
                    return RedirectToAction("Dashboard", "Home", new {id= result.username });
                }
                else
                {
                    return NotFound();
                }
            }
            return NotFound();
        }

        public IActionResult Register()
        {
                       
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRequestModel userRequestModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.Register(userRequestModel);
                if (result.IsAuthSuccessful)
                {
                    HttpContext.Session.SetString("ssuserid", result.username);
                    return RedirectToAction("Dashboard", "Home",new {id= result.username });
                }
                else
                {
                    return NotFound();
                }
            }
            return NotFound();
        }

        public async Task<IActionResult> LogOut()
        {
            HttpContext.Session.Remove("ssuserid");
            await _accountService.Logout();

            return RedirectToAction("Index", "Home");
        }
    }
}
