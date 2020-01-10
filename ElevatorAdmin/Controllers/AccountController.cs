using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.CustomAttributes;
using Core.Utilities;
using DataLayer.Entities.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.Repos.User;
using WebFramework.Base;

namespace ElevatorAdmin.Controllers
{
    public class AccountController : BaseAdminController
    {
        private readonly UserRepository _userRepository;
        private readonly UsersRoleRepository _usersRoleRepository;
        private readonly SignInManager<Users> _signInManager;
        private readonly UserManager<Users> _userManager;
        private readonly RoleManager<Roles> roleManager;
        private readonly RoleRepository _roleRepository;


        public AccountController(SignInManager<Users> signInManager,
            UserManager<Users> userManager,
            RoleManager<Roles> roleManager,
            UserRepository userRepository,
            UsersRoleRepository usersRoleRepository,
            RoleRepository roleRepository,
            UsersAccessRepository usersAccessRepository
            ) : base(usersAccessRepository)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            this.roleManager = roleManager;
            _userRepository = userRepository;
            _usersRoleRepository = usersRoleRepository;
            _roleRepository = roleRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAccess]
        [AllowAnonymous()]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAccess]
        [AllowAnonymous()]
        public async Task<IActionResult> Login(string userName, string password)
        {
            var model = _userRepository.TableNoTracking.FirstOrDefault(a => a.UserName == userName);

            if (model == null)
            {
                TempData.AddResult(SweetAlertExtenstion.Error("کاربری با این نام کاربری یافت نشد!"));
                return RedirectToAction("Login");
            }

            if (model.IsActive == false)
            {
                TempData.AddResult(SweetAlertExtenstion.Error("شما فعال نیستید!"));
                return RedirectToAction("Login");
            }

            var result = await _signInManager.PasswordSignInAsync(model, password, true, false);

            if (result.Succeeded)
            {
                //await _userRepository.SetUserClaims(userName);
                return RedirectToAction("Index", "Home");
            }
            TempData.AddResult(SweetAlertExtenstion.Error("کلمه عبور یا نام کاربری نادرست است"));
            return RedirectToAction("Index");
        }

        [AllowAccess]
        [AllowAnonymous()]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/");
        }

        [AllowAccess]
        [AllowAnonymous()]
        public async Task<IActionResult> changeSelectedRole(int selectedRoleId, string returnURL)
        {
            var user = _userRepository.Table.FirstOrDefault(a => a.Id == this.UserId);
            ClaimsIdentity identity = (ClaimsIdentity)User.Identity;
            var claim = (identity).FindFirst("selectedRoleId");
            identity.RemoveClaim(claim);
            identity.AddClaim(new Claim("selectedRoleId", selectedRoleId.ToString()));
            await _userManager.AddClaimAsync(user, new Claim("selectedRoleId", selectedRoleId.ToString()));
            await _signInManager.RefreshSignInAsync(user);


            //var user = _userRepository.Table.FirstOrDefault(a => a.Id == this.UserId);
            //ClaimsIdentity identity = (ClaimsIdentity)User.Identity;
            //var claim = (identity).FindFirst("selectedRoleId");
            //identity.RemoveClaim(claim);
            //identity.AddClaim(new Claim("selectedRoleId", selectedRoleId.ToString()));
            //await _signInManager.SignOutAsync();
            //await _signInManager.SignInAsync(user, false, null);
            return Redirect(returnURL);
        }
    }
}
