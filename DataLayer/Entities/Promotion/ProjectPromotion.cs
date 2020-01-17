using DataLayer.Entities.Common;
using DataLayer.SSOT.Promotion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entities.Promotion
{
    public class ProjectPromotion : BaseEntity<int>
    {
        /// <summary>
        /// این فعالیتی که در حال ثبت آن است مربوط به کدام پروژه یا طرح پژوهشی می‌باشد
        /// </summary>
        public int PromotionBasicInfoId { get; set; }

        /// <summary>
        /// نوع طرح یا پروژه چیست؟
        /// از این فیلد برای مشخص کردن ردیف موجود در جدول الف استفاده می‌شود
        /// </summary>
        public ProjectPromotionSSOT Kind { get; set; }

        /// <summary>
        /// عنوان طرح یا پروژه
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// امتیاز
        /// </summary>
        public float? Score { get; set; }

        /// <summary>
        /// نوع : طرح بوده است یا پروژه
        /// </summary>
        public ProjectPromotionTypeSSOT? Type { get; set; }

        /// <summary>
        /// نوع پروژه یا طرح
        /// که می‌تواند از بین این 4 مورد انتخاب شود
        /// 1 => امانی
        /// 2 => پیمانی
        /// 3 => مشارکتی
        /// 4 => مرتبط با موافقت نامه
        /// </summary>
        public ProjectPromotionProjectOrPlanTypesSSOT? ProjectTypeOrPlan { get; set; }

        /// <summary>
        /// مجری پروژه/طرح
        /// </summary>
        public string ProjectExecutiveName { get; set; }

        /// <summary>
        /// مدیر پروژه/طرح
        /// </summary>
        public string ProjectManagerName { get; set; }

        /// <summary>
        /// واحد مجری
        /// </summary>
        public string ExecutiveUnit { get; set; }

        /// <summary>
        /// نوع پروژه
        /// این فیلد زمانی پر می شود که این رکورد پروژه باشد نه طرح
        /// </summary>
        public ProjectPromotionProjectTypesSSOT? ProjectType { get; set; }

        /// <summary>
        /// مدت زمان پروژه/طرح (به ماه)
        /// </summary>
        public int ProjectPeriod { get; set; }

        /// <summary>
        ///  مبلغ کل پروژه (به میلیون تومان)
        /// </summary>
        public int ProjectCost { get; set; }

        /// <summary>
        /// مبلغ پرسنلی پروژه (به میلیون تومان)
        /// این فیلد زمانی پر می‌شود که پروژه باشد نه طرح
        /// </summary>
        public int? PersonnelCost { get; set; }

        /// <summary>
        /// PLF02 فرم 
        /// فایل پیوست فرم 
        /// PLF02
        /// از این فایل به منظور فیلد
        /// PersonnelCost
        /// استفاده می‌شود
        /// </summary>
        public string PLF02File { get; set; }

        /// <summary>
        /// معاونت
        /// </summary>
        public ProjectPromotionAssistanceSSOT‌? Assistance { get; set; }

        /// <summary>
        /// درصد مشارکت (بر حسب صدم)
        /// این فیلد بر طبق مستندات می‌تواند الزاما پر نشود
        /// و در صورتی که پر نشود باید یک فایل بارگزاری شود
        /// </summary>
        public float? ParticipationPercentage  { get; set; }

        /// <summary>
        /// تاریخ تصویب طرح یا پروژه
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// مستندات
        /// </summary>
        public string Documentation { get; set; }

        /// <summary>
        /// فرم PLF05
        /// </summary>
        public string PLF05Form { get; set; }

        /// <summary>
        /// گواهی همکاری در تصویب/تدوین طرح/پروژه
        /// این فیلد درصورتی مقدار میگیرد که فیلد
        /// ParticipationPercentage
        /// مقدار نگیرد
        /// </summary>
        public string CooperationCertificate { get; set; }





        #region هنوز نمیدونم این فیلد‌ها برای چی هست

        /// <summary>
        /// وزن مرحله
        /// </summary>
        public float? StepWeight { get; set; }

        /// <summary>
        /// نوع گزارش
        /// </summary>
        public ProjectPromotionReportTypeSSOT? ReportType { get; set; }

        /// <summary>
        /// نوع داوری
        /// </summary>
        public ProjectPromotionJudgmentTypeSSOT? JudgmentType { get; set; }

        #endregion




        #region Relation

        [ForeignKey(nameof(PromotionBasicInfoId))]
        public PromotionBasicInfo PromotionBasicInfo { get; set; }

        #endregion
    }
}
