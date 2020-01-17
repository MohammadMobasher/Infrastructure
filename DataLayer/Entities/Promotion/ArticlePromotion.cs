
using DataLayer.Entities.Common;
using DataLayer.SSOT.Promotion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entities.Promotion
{
    public class ArticlePromotion : BaseEntity<int>
    {

        /// <summary>
        /// این فعالیتی که در حال ثبت آن است مربوط به کدام پروژه یا طرح پژوهشی می‌باشد
        /// </summary>
        public int PromotionBasicInfoId { get; set; }


        /// <summary>
        /// نوع مقاله چیست؟
        /// از این فیلد برای مشخص کردن ردیف موجود در جدول ب استفاده می‌شود
        /// </summary>
        public ArticlePromotionSSOT Kind { get; set; }


        /// <summary>
        /// امتیاز
        /// </summary>
        public float? Score { get; set; }


        /// <summary>
        /// نوع مقاله
        /// </summary>
        public ArticlePromotionArticleTypeSSOT? ArticleType { get; set; }

        /// <summary>
        /// DOI مقاله
        /// </summary>
        public string ArticleDOI { get; set; }

        /// <summary>
        /// عنوان مقاله
        /// </summary>
        public string ArticleTitle { get; set; }

        /// <summary>
        /// عنوان مجله یا کنفرانس
        /// </summary>
        public string JournalTitle { get; set; }

        /// <summary>
        /// زبان مقاله
        /// </summary>
        public ArticlePromotionArticleLanguageSSOT? ArticleLanguage { get; set; }

        /// <summary>
        /// شاخص مقاله
        /// </summary>
        public ArticlePromotionArticleIndexSSOT? ArticleIndex { get; set; }

        /// <summary>
        /// تعداد نویسندگان
        /// </summary>
        public byte? WritersCount { get; set; }

        /// <summary>
        /// نویسنده چندم مقاله؟؟
        /// </summary>
        public byte? WriterPosition { get; set; }

        /// <summary>
        /// تاریخ پذیرش/چاپ مقاله
        /// </summary>
        public DateTime? AcceptDate { get; set; }

        ///// <summary>
        ///// مستندات
        ///// </summary>
        //public string Documentation { get; set; }

        /// <summary>
        /// فایل صفحه اول مقاله
        /// </summary>
        public string FirstPageFile { get; set; }

        /// <summary>
        /// فایل گواهی پذیرش
        /// </summary>
        public string CertificationFile { get; set; }

        /// <summary>
        /// نوع کنفرانس
        /// </summary>
        public ArticlePromotionConferenceTypeSSOT? ConferenceType { get; set; }

        /// <summary>
        /// مدت زمان دوره/کارگاه (برحسب ساعت)
        /// </summary>
        public int? SetPeriod { get; set; }

        /// <summary>
        /// نام دانشگاه/ پژوهشگاه
        /// </summary>
        public string UniversityName { get; set; }


        #region هنوز نمیدونم
        #endregion


        #region Relation

        [ForeignKey(nameof(PromotionBasicInfoId))]
        public PromotionBasicInfo PromotionBasicInfo { get; set; }

        #endregion

    }
}
