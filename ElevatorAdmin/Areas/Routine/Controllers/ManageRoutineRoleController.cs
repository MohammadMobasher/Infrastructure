using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.CustomAttributes;
using Core.Utilities;
using DataLayer.ViewModels.Routin2;
using Microsoft.AspNetCore.Mvc;
using Service.Repos;
using Service.Repos.Routine2;
using Service.Repos.User;
using WebFramework.Authenticate;
using WebFramework.Base;

namespace ElevatorAdmin.Areas.Routine.Controllers
{
    [Area("Routine")]
    [ControllerRole("مدیریت روتین")]
    public class ManageRoutineRoleController : BaseAdminController
    {

        private readonly Routin2RoleRepository _routin2RoleRepository;
        private readonly RoleRepository _roleRepository;
        private readonly Routine2RoleDashboardRepository _routine2RoleDashboardRepository;


        public ManageRoutineRoleController(UsersAccessRepository usersAccessRepository,
            Routin2RoleRepository routin2RoleRepository,
            RoleRepository roleRepository,
            Routine2RoleDashboardRepository routine2RoleDashboardRepository) : base(usersAccessRepository)
        {
            _routin2RoleRepository = routin2RoleRepository;
            _roleRepository = roleRepository;
            _routine2RoleDashboardRepository = routine2RoleDashboardRepository;
            
        }

        
        public IActionResult Index()
        {
            
            return View();
        }


        #region ثبت کارتابل برای یک نقش

        [HasAccess]
        [ActionRole("ثبت کارتابل برای نقش")]
        public async Task<IActionResult> ManageDashboardsToRole(int id)
        {
            ViewBag.Role = await _roleRepository.GetByIdAsync(id);
            ViewBag.DashboardForRole = await _routine2RoleDashboardRepository.GetAllDashboardByRoleIdAsync(id);
            var model = await _routin2RoleRepository.GetAllDashBoards();

            return View(model);

        }


        [HttpPost]
        public async Task<IActionResult> ManageDashboardsToRole(List<DashboardRoleSubmitViewModel> vm)
        {
            List<DashboardRoleInsertViewModel> model = new List<DashboardRoleInsertViewModel>();
            foreach (DashboardRoleSubmitViewModel item in vm.Where(x=> x.DashboardEnum != null))
            {
                foreach (string Dashboard in item.DashboardEnum)
                {
                    model.Add(new DashboardRoleInsertViewModel {
                        RoleId = item.RoleId,
                        DashboardEnum = Dashboard
                    });
                }
            }

            TempData.AddResult(await _routine2RoleDashboardRepository.AddAsync(model));

            return RedirectToAction("Index", "RoleManage"); 
        }

        #endregion





    }
}