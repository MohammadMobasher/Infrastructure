using DataLayer.Entities.Common;
using DataLayer.SSOT.Promotion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entities.Promotion
{
    public class PostPromotion : BaseEntity<int>
    {

        /// <summary>
        /// این فعالیتی که در حال ثبت آن است مربوط به کدام پروژه یا طرح پژوهشی می‌باشد
        /// </summary>
        public int PromotionBasicInfoId { get; set; }

        public PostPromotionSSOT Kind { get; set; }

        public float? Score { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        /// <summary>
        /// مدت زمان تصدی مسئولیت در بازه ترفیع پایه سالیانه(به ماه وارد شود)
        /// </summary>
        public int? CorporateResponsibilityTime { get; set; }

        /// <summary>
        /// مستندات
        /// </summary>
        public string Documentation { get; set; }

        public string Title { get; set; }

        public DateTime? Date { get; set; }

        /// <summary>
        /// سهم مشارکت (بر حسب صدم)
        /// </summary>
        public float? ContributionShare { get; set; }

        /// <summary>
        /// مدت زمان مشارکت بر حسب ساعت
        /// </summary>
        public int? ParticipationTime { get; set; }

        #region Relation

        [ForeignKey(nameof(PromotionBasicInfoId))]
        public PromotionBasicInfo PromotionBasicInfo { get; set; }

        #endregion
    }
}
