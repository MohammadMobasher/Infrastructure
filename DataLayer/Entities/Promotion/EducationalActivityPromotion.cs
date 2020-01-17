
using DataLayer.Entities.Common;
using DataLayer.SSOT.Promotion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entities.Promotion
{
    public class EducationalActivityPromotion : BaseEntity<int>
    {
        /// <summary>
        /// این فعالیتی که در حال ثبت آن است مربوط به کدام پروژه یا طرح پژوهشی می‌باشد
        /// </summary>
        public int PromotionBasicInfoId { get; set; }

        /// <summary>
        /// نوع فعالیت آموزشی شخص
        /// </summary>
        public EducationalActivitySSOT Kind { get; set; }

        public float? Score { get; set; }

        public string Title { get; set; }

        /// <summary>
        /// عنوان دروس یا درس
        /// </summary>
        public string LessonTitle { get; set; }

        /// <summary>
        /// تعدغاد واحدهای درسی
        /// </summary>
        public int? LessonUnit { get; set; }

        /// <summary>
        /// سال تحصیلی
        /// </summary>
        public int? AcademicYear { get; set; }

        /// <summary>
        /// نیمسال
        /// </summary>
        public EducationalPromotionTermSSOT? Term { get; set; }

        /// <summary>
        /// مستندات
        /// </summary>
        public string Documentation { get; set; }

        public DateTime? Date { get; set; }

        /// <summary>
        /// محل برگزاری
        /// </summary>
        public string EventPlace { get; set; }

        /// <summary>
        ///  مدت زمان بر حسب ساعت
        /// </summary>
        public int? PeriodTime { get; set; }

        /// <summary>
        /// عنوان مجمع
        /// </summary>
        public string AssemblyTitle { get; set; }

        #region Relation

        [ForeignKey(nameof(PromotionBasicInfoId))]
        public PromotionBasicInfo PromotionBasicInfo { get; set; }

        #endregion
    }
}
