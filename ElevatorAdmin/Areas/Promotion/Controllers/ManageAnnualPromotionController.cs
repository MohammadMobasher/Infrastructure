using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Core.CustomAttributes;
using Core.Utilities;
using DataLayer.ViewModels.Promotion.BankAnnualPromotion;
using Microsoft.AspNetCore.Mvc;
using Service.Repos.Promotion;
using Service.Repos.Routine2;
using Service.Repos.User;
using WebFramework.Authenticate;
using WebFramework.Base;

namespace ElevatorAdmin.Areas.Promotion.Controllers
{

    [Area("Promotion")]
    [ControllerRole("مدیریت ترفیع‌های سالانه")]

    public class ManageAnnualPromotionController : BaseAdminController
    {
        private readonly BankAnnualPromotionRepository _bankAnnualPromotionRepository;

        public ManageAnnualPromotionController(
            UsersAccessRepository usersAccessRepository,
            Routine2RoleDashboardRepository routine2RoleDashboardRepository,
            BankAnnualPromotionRepository bankAnnualPromotionRepository) : base(usersAccessRepository, routine2RoleDashboardRepository)
        {
            HasRoutine = true;
            _bankAnnualPromotionRepository = bankAnnualPromotionRepository;
        }



        [ActionRole("صفحه لیست  دوره ترفیع‌ها")]
        [HasAccess]
        public async Task<IActionResult> Index(BankAnnualPromotionSearchViewModel searchModel)
        {
            var model = await _bankAnnualPromotionRepository.LoadAsyncCount(
                this.CurrentPage,
                this.PageSize,
                searchModel);

            this.TotalNumber = model.Item1;

            ViewBag.SearchModel = searchModel;

            return View(model.Item2);

        }


        #region ثبت
        [ActionRole("ثبت دوره ترفیع جدید")]
        [HasAccess]
        public async Task<IActionResult> Insert()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(InsertBankAnnualPromotionListView model)
        {
            TempData.AddResult(await _bankAnnualPromotionRepository.InsertAsync(model));

            return RedirectToAction("Index");
        }

        #endregion

        //#region ویرایش
        //[ActionRole("ویرایش خبر")]
        //[HasAccess]
        //public async Task<IActionResult> Update(int Id)
        //{

        //    var result = await _newsRepository.GetByIdAsync(Id);
        //    ViewBag.NewsGroups = await _newsGroupRepository.LoadAsync<NewsGroupDTO>();
        //    return View(result);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Update(NewsUpdateViewModel model)
        //{
        //    var result = await _newsRepository.UpdateAsync(model);

        //    TempData.AddResult(result);

        //    return RedirectToAction("Index");
        //}

        //#endregion

        //#region حذف
        //[ActionRole("حذف خبر")]
        //[HasAccess]
        //public async Task<IActionResult> Delete(int Id)
        //{

        //    var result = await _newsRepository.DeleteAsync(Id);
        //    TempData.AddResult(result);

        //    return RedirectToAction("Index");
        //}

        //#endregion
    }
}