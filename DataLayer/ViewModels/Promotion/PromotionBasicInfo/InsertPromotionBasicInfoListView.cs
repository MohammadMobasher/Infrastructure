using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.ViewModels.Promotion.PromotionBasicInfo
{
    public class InsertPromotionBasicInfoListView
    {

        /// <summary>
        /// شماره کاربری هیئت علمی مورد نظر
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// تاریخ شروع به کار هیئت علمی
        /// </summary>
        public DateTime StartToWork { get; set; }

        /// <summary>
        /// آخرین پایه استحقاقی
        /// </summary>
        public int DeservedLastGrade { get; set; }

        /// <summary>
        /// آخرین پایه ایثارگری
        /// </summary>
        public int SacrificeLastGrade { get; set; }

        /// <summary>
        /// آخرین پایه تشویقی
        /// </summary>
        public int IncentivesLastGrade { get; set; }

        /// <summary>
        /// فایل آخرین حکم کارگزینی
        /// در این فیلد باید آدرس 
        /// PDF
        /// مربوط به تمام مستندات آخرین فایل کارگزینی فرد ذخیره شود
        /// </summary>
        public string SentenceFile { get; set; }

        /// <summary>
        /// فایل ساعات کارکرد
        /// </summary>
        public string WorkingHoursFile { get; set; }

        /// <summary>
        /// زمانی که این درخواست ثبت شده است
        /// </summary>
        public DateTime DateRequest { get; set; } = DateTime.Now;

    }
}
