using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.CustomAttributes;
using Core.Utilities;
using DataLayer.ViewModels.Promotion.PromotionBasicInfo;
using Microsoft.AspNetCore.Mvc;
using Service.Repos.Promotion;
using Service.Repos.Routine2;
using Service.Repos.User;
using WebFramework.Authenticate;
using WebFramework.Base;

namespace ElevatorAdmin.Areas.Promotion.Controllers
{

    [Area("Promotion")]
    [ControllerRole("فرآیند ترفیع‌")]
    public class PromotionRoutineController : BaseAdminController
    {
        private readonly PromotionBasicInfoRepository _promotionBasicInfoRepository;

        public PromotionRoutineController(
            UsersAccessRepository usersAccessRepository,
            Routine2RoleDashboardRepository routine2RoleDashboardRepository,
            PromotionBasicInfoRepository promotionBasicInfoRepository) : base(usersAccessRepository, routine2RoleDashboardRepository)
        {
            HasRoutine = true;
            _promotionBasicInfoRepository = promotionBasicInfoRepository;
        }


        [ActionRole("صفحه لیست درخواست‌ها")]
        [HasAccess]
        public async Task<IActionResult> Index(PromotionBasicInfoSearchViewModel searchModel)
        {

            var model = await _promotionBasicInfoRepository.LoadAsyncCount(
                this.CurrentPage,
                this.PageSize,
                searchModel);

            this.TotalNumber = model.Item1;

            ViewBag.SearchModel = searchModel;

            return View(model.Item2);
        }

        #region ثبت
        [ActionRole("ثبت درخواست جدید")]
        [HasAccess]
        public async Task<IActionResult> Insert()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(InsertPromotionBasicInfoListView model)
        {
            model.UserId = this.UserId;

            TempData.AddResult(await _promotionBasicInfoRepository.InsertAsync(model));

            return RedirectToAction("Index");
        }

        #endregion
    }
}