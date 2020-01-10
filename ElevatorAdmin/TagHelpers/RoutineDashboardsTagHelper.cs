using DataLayer.DTO.Routin2RoleDTO;
using DataLayer.DTO.Routine2RoleDashboard;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Service.Repos.Routine2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElevatorAdmin.TagHelpers
{
    [HtmlTargetElement("RoutineDashboards", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class RoutineDashboardsTagHelper : TagHelper
    {

        #region فیلدها

        /// <summary>
        /// شماره روتین که باید کارتابل‌های آن نمایش داده شود
        /// </summary>
        [HtmlAttributeName("routinId")]
        public int RoutinId { get; set; }

        /// <summary>
        /// نام کنترلری که باید درخواست‌ها به سمت آن ارسال شود
        /// </summary>
        [HtmlAttributeName("controller")]
        public string Controller { get; set; }

        /// <summary>
        /// نام اکشنی که باید درخواست‌ها به سمت آن ارسال شود
        /// </summary>
        [HtmlAttributeName("action")]
        public string Action { get; set; }

        #endregion

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }


        private readonly Routin2RoleRepository _routin2RoleRepository;

        public RoutineDashboardsTagHelper(Routin2RoleRepository routin2RoleRepository)
        {
            _routin2RoleRepository = routin2RoleRepository;
        }


        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {

            List<Routin2RoleFullDetailDTO> LatablList = await _routin2RoleRepository.GetAllDashBoardsByRoutinId(this.RoutinId);

            //========================================================================
            string Kartabls = "";

            string OutPutView = @"
                                    <div class='panel-body'>
                                        <div class='stats__section'>
                                            <div class='stats-title'>
                                                <h4 class='size-16'>لیست کارتابل‌ها</h4>
                                            </div>  
                                            <div class='stats-icon'>
                                                <i class='pe-7s-news-paper fa-2x text-primary'></i>
                                            </div>
                                        </div>
                                        <div class='margin-top-10'>
                                             XXKartablsXX
                                        </div>
                                    </div>
                                ";

            // لیست داشبورد‌هایی که به آن دسترسی دارد
            List<Routine2RoleDashboardDTO> Dashboards = ViewContext.ViewBag.Dashboards;
            //========================================================================


            foreach (Routin2RoleFullDetailDTO item in LatablList)
            {
                // درصورتی که به این کارتابل دسترسی داشته باشد
                if(Dashboards.Where(x=> x.DashboardEnum == item.DashboardEnum).SingleOrDefault() != null)
                    Kartabls += "<a class='btn btn-block btn-outline btn-info btn-lg size-14 weight-400' href='/" + this.Controller + "/" + this.Action + "/'>" + item.Title + "</a>";
            }

            OutPutView = OutPutView.Replace("XXKartablsXX", Kartabls);
            
            output.Content.AppendHtml(OutPutView);
            await base.ProcessAsync(context, output);
        }
    }
}
