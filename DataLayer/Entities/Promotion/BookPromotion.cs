
using DataLayer.Entities.Common;
using DataLayer.SSOT.Promotion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entities.Promotion
{
    public class BookPromotion : BaseEntity<int>
    {
        /// <summary>
        /// این فعالیتی که در حال ثبت آن است مربوط به کدام پروژه یا طرح پژوهشی می‌باشد
        /// </summary>
        public int PromotionBasicInfoId { get; set; }


        /// <summary>
        /// نوع کتاب چیست؟
        /// از این فیلد برای مشخص کردن ردیف موجود در جدول پ استفاده می‌شود
        /// </summary>
        public BookPromotionSSOT Kind { get; set; }

        /// <summary>
        /// نوع جشنواره
        /// </summary>
        public ArticlePromotionConferenceTypeSSOT? FestivalType { get; set; }


        /// <summary>
        /// عنوان
        /// </summary>
        public string Title { get; set; }


        /// <summary>
        /// تاریخ برگذاری جشنواره
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// عنوان طرح
        /// </summary>
        public string PlanTitle { get; set; }

        /// <summary>
        /// رتبه کسب شده
        /// </summary>
        public int? RankEarned { get; set; }

        /// <summary>
        /// درصد مشارکت (بر حسب صدم)
        /// </summary>
        public float? ParticipationPercentage { get; set; }

        /// <summary>
        /// مستندات
        /// </summary>
        public string Documentation { get; set; }

        /// <summary>
        ///  تعداد مخترعین یا نویسنده یا مترجمین
        /// </summary>
        public byte? PersonCount { get; set; }

        /// <summary>
        /// نفر چندم در اختراع یا نویسنده یا مترجمین؟
        /// </summary>
        public byte? PersonPosition { get; set; }

        public BookPromotionBookTypeSSOT? BookType { get; set; }

        /// <summary>
        /// عنوان انتشارات
        /// </summary>
        public string PublisherTitle { get; set; }

        /// <summary>
        /// نوبت چاپ
        /// </summary>
        public byte? Published { get; set; }


        #region Relation

        [ForeignKey(nameof(PromotionBasicInfoId))]
        public PromotionBasicInfo PromotionBasicInfo { get; set; }

        #endregion

    }
}
