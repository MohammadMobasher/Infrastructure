using Core.CustomAttributes;
using DataLayer.DTO.UserRoleDTO;
using DataLayer.Entities.Users;
using DataLayer.SSOT.Routine2;
using DataLayer.SSOT.Routine2.DashBoards;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Service.Repos;
using Service.Repos.Routine2;
using Service.Repos.User;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using WebFramework.Base;
using static Microsoft.AspNetCore.WebSockets.Internal.Constants;

namespace ElevatorAdmin.Controllers
{
    public class TestController : BaseAdminController
    {
        private readonly TestRoutinRepository _testRoutinRepository;
        private readonly mohammadTestRepository _mohammadTestRepository;
        private readonly UserRepository _userRepository;
        private readonly SignInManager<Users> _signInManager;

        public TestController(UsersAccessRepository usersAccessRepository,
            TestRoutinRepository testRoutinRepository,
            Routine2RoleDashboardRepository routine2RoleDashboardRepository,
            mohammadTestRepository mohammadTestRepository,
            UserRepository userRepository,
            SignInManager<Users> signInManager
            ) : base(usersAccessRepository, routine2RoleDashboardRepository)
        {
            _testRoutinRepository = testRoutinRepository;
            _mohammadTestRepository = mohammadTestRepository;
            _userRepository = userRepository;
            _signInManager = signInManager;
            HasRoutine = true;
        }
        [AllowAccess]
        public async Task<IActionResult> Index()
        {
            

            var user = _userRepository.Table.FirstOrDefault(a => a.Id == this.UserId);
            ClaimsIdentity identity = (ClaimsIdentity)User.Identity;
            var claim = (identity).FindFirst("selectedRoleId");
            identity.RemoveClaim(claim);
            identity.AddClaim(new Claim("selectedRoleId", 14.ToString()));
            //await _signInManager.RefreshSignInAsync(user);
            //await _signInManager.SignOutAsync();
            //await _signInManager.SignInAsync(user, false, null);
            var claimsPrincipal = await _signInManager.CreateUserPrincipalAsync(user);

            ClaimsIdentity identity1 = (ClaimsIdentity)claimsPrincipal.Identity;
            var claim1 = (identity1).FindFirst("selectedRoleId");
            identity1.RemoveClaim(claim1);
            identity1.AddClaim(new Claim("selectedRoleId", 14.ToString()));

            await _signInManager.RefreshSignInAsync(user);
            //var ddd = claimsPrincipal.Identities.FirstOrDefault().Claims.Where(x => x.Type == "selectedRoleId").SingleOrDefault();















            //_mohammadTestRepository.ddd();
            //var claim = (identity).FindFirst("selectedRoleId");
            //identity.RemoveClaim(claim);
            //identity.AddClaim(new Claim("selectedRoleId", "14"));


            ////        AuthenticationManager.AuthenticationResponseGrant = new AuthenticationResponseGrant
            ////(new ClaimsPrincipal(identity), new AuthenticationProperties { IsPersistent = false });
            //var d = this.SelectedRoleId;


            return View();
        }

        [AllowAccess]
        [HttpPost]
        public IActionResult ChangeStep(int interViewModuleId, int toStep)
        {
            _testRoutinRepository.UpdateStep(interViewModuleId, toStep, this.UserId, 1);
            return RedirectToAction("Index");
        }


        [HttpPost]
        [AllowAccess]
        public async Task<IActionResult> ChangeDashboard(int id, Routine2Actions action, string description = "")
        {
            this.IsPermitted(TestDashBoard.Applicant);
            var result = await _testRoutinRepository.ChangeStep(UserId, 1, id, action, description);
            return Json(result);
        }


        //public IActionResult Manage(UpgradeLicenseSearchCriteriaViewModel searchCriteria, UpgradeLicenseDashboard currentDashboard, int page = 1)
        //{
        //    ViewBag.Current = currentDashboard.ToString();
        //    ViewBag.DashboardType = searchCriteria.DashboardType;

        //    if (!IsPermitted(currentDashboard)) return Forbid();

        //    // شناسه کاربر لاگین شده در سیستم
        //    var userId = _userResolverService.GetUserId();

        //    // مراحل تازه‌های کارتابل فعلی چیست
        //    searchCriteria.RoutineStepList =
        //        _routine2Repository.GetRoleSteps(UpgradeLicenseRoutine.RoutineId, currentDashboard.ToString());

        //    // کاربر در سمت فعلی، بر روی چه طرح‌هایی عملیاتی انجام داده است
        //    searchCriteria.RoutineLogList =
        //        _routine2Repository.GetUserEntityIds(UpgradeLicenseRoutine.RoutineId, userId, currentDashboard.ToString());



        //    // ارسال شده ها
        //    if (searchCriteria.DashboardType == DashboardTypes.New ||
        //        searchCriteria.DashboardType == DashboardTypes.Archived)
        //        searchCriteria.RoutineIsDone = false;

        //    // خاتمه یافته‌ّها
        //    if (searchCriteria.DashboardType == DashboardTypes.Done)
        //        searchCriteria.RoutineIsDone = true;

        //    if (searchCriteria.DashboardType == DashboardTypes.Draft)
        //        searchCriteria.RoutineIsFlown = false;


        //    // متقاضی
        //    if (currentDashboard == UpgradeLicenseDashboard.Applicant)
        //        searchCriteria.OwnerUserId = userId;



        //    var data = _upgradeLicenseRepository.GetData(searchCriteria, page);


        //    var model = new Routine2PageModel<
        //        IPaginated<UpgradeLicenseSummeryDTOL>, UpgradeLicenseSearchCriteriaViewModel, UpgradeLicenseDashboard>(data, searchCriteria, currentDashboard);

        //    return View(model);
        //}


    }
}