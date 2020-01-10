using Core.CustomAttributes;
using Core.Utilities;
using DataLayer.DTO.UserRoleDTO;
using DataLayer.SSOT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Service;
using Service.Repos.Routine2;
using Service.Repos.User;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebFramework.Authenticate;

namespace WebFramework.Base
{
    [HasAccess]
    [Authorize]
    public class BaseAdminController : Controller
    {
        private readonly UsersAccessRepository _usersAccessRepository;
        private readonly Routine2RoleDashboardRepository _routine2RoleDashboardRepository;

        public BaseAdminController(UsersAccessRepository usersAccessRepository) : base()
        {
            _usersAccessRepository = usersAccessRepository;
        }

        /// <summary>
        /// درصروتی که روتین داشته باشیم باید از سازنده استفاده کنیم
        /// </summary>
        /// <param name="usersAccessRepository"></param>
        /// <param name="routine2RoleDashboardRepository"></param>
        public BaseAdminController(UsersAccessRepository usersAccessRepository,
            Routine2RoleDashboardRepository routine2RoleDashboardRepository) : base()
        {
            _usersAccessRepository = usersAccessRepository;
            _routine2RoleDashboardRepository = routine2RoleDashboardRepository;
        }

        public BaseAdminController() : base()
        {

        }

        #region Fields

        public bool HasRoutine { get; set; } = false;


        #region مربوط به گیرید است و برای آن استفاده می شود
        /// <summary>
        /// شماره صفحه فعلی
        /// </summary>
        public int CurrentPage { get; set; } = 0;


        /// <summary>
        /// تعداد آیتم برای هر صفحه
        /// </summary>
        public int PageSize { get; set; } = 10;


        /// <summary>
        /// تعداد کل آیتم‌ها
        /// </summary>
        public int TotalNumber { get; set; }


        /// <summary>
        /// تعداد صفحات
        /// </summary>
        public int PageCount { get; set; }
        #endregion



        /// <summary>
        /// شماره کاربری شخصی که لاگین است
        /// </summary>
        public int UserId
        {
            get
            {
                if (_userId == null)
                    _userId = User.Identity.FindFirstValue(ClaimTypes.NameIdentifier).ToInt();
                return _userId.Value;
            }
        }
        private int? _userId { get; set; }



        /// <summary>
        /// شماره نقش فردی که لاگین کرده است
        /// </summary>
        public string RoleId
        {
            get
            {
                if (_roleId == null)
                    _roleId = User.Identity.FindFirstValue(ClaimTypes.Role);

                return _roleId;
            }
        }
        private string _roleId { get; set; }

        /// <summary>
        /// شماره نقشی که انتخاب شده است
        /// </summary>
        public int SelectedRoleId
        {
            get
            {
                if (_selectedRoleId == -1)
                    _selectedRoleId = User.Identity.FindFirstValue("selectedRoleId").ToInt();

                return _selectedRoleId;
            }
        }
        private int _selectedRoleId { get; set; } = -1;


        #endregion



        /// <summary>
        /// قبل از اجرا هر اکشنی این تابع اجرا میشود تا بتواند اطلاعات مورد نیاز که 
        /// از صفحه پاس داده شده است اینجا مقداردهی کند
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);


            this.CurrentPage = Request.Query["currentPage"].Count != 0 ? Convert.ToInt32(Request.Query["currentPage"][0]) : 1;
            this.PageSize = Request.Query["pageSize"].Count != 0 ? Convert.ToInt32(Request.Query["pageSize"][0]) : 10;

        }



        /// <summary>
        /// بعد از هر اکشنی این تابع صدا زده می‌شود
        /// </summary>
        /// <param name="context"></param>
        public override async void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
            
            

            ViewBag.CurrentPage = this.CurrentPage;
            ViewBag.pageSize = this.PageSize;
            ViewBag.pageCount = (int)Math.Floor((decimal)((this.TotalNumber + this.PageSize - 1) / this.PageSize));
            ViewBag.totalNumber = this.TotalNumber;

            if (User.Identity.FindFirstValue("UserHasRoles") != null)
                ViewBag.UserHasRoles = JsonConvert.DeserializeObject<List<UserRoleDetailDTO>>(User.Identity.FindFirstValue("UserHasRoles"));

            if (this.SelectedRoleId != -1 && this.SelectedRoleId != 0)
                ViewBag.selectedRoleId = this.SelectedRoleId;


            // لیست دسترسی‌های موجود برای این نقش
            getListAccess();

            if (HasRoutine)
                // لیست دسترسی‌های کارتابل موجود برای این نقش
                GetListRoutinAccess();

        }




        #region Page AccessLevel

        /// <summary>
        /// با استفاده از این تابع یک لیستی به صفحه پاس داده می‌شود
        /// در این تابع لیستی از 
        /// controller 
        /// و
        /// action
        /// هایی که این نقش دارد را به صفحه پاس میدهد
        /// </summary>
        private void getListAccess()
        {
            ViewBag.ListAccess = _usersAccessRepository.GetAllUserAccesss(this.SelectedRoleId);
        }

        #endregion

        #region Routin AccessLevel

        /// <summary>
        /// این نقش مورد نظر به کدام داشبوردها دسترسی دارد
        /// </summary>
        private void GetListRoutinAccess()
        {
            ViewBag.Dashboards = _routine2RoleDashboardRepository.GetAllDashboardByRoleId(this.SelectedRoleId);
        }

        #endregion

        



        #region Routin

        /// <summary>
        /// آیا کاربر فعلی به این کارتابل دسترسی دارد یا خیر
        /// </summary>
        /// <typeparam name="TEnum">نوع کارتابل</typeparam>
        /// <param name="currentDashboard">کارتابل فعلی</param>
        /// <returns></returns>
        public bool IsPermitted<TEnum>(TEnum currentDashboard) where TEnum : struct, IConvertible, IComparable, IFormattable
        {
            ///درصورتی که پارامتر پاس داده شده به صورت 
            /// eunm
            /// نباشد باید به برنامه نویس یک خطا بدهیم
            if (!typeof(TEnum).IsEnum)
            {
                throw new ArgumentException("TEnum in IsPermitted function must be an enum.");
            }


            //// کارتابل  متقاضی
            //if (currentDashboard == UpgradeLicenseDashboard.Applicant)
            //{
            //    if (!User.HasRole(AuthorityCode.UpgradeLicenseApplicant))
            //    {
            //        return false;
            //    }
            //}

            return false;
        }





        #endregion


    }
}
