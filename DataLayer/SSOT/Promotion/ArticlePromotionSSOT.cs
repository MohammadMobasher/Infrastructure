using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.SSOT.Promotion
{
    public enum ArticlePromotionSSOT
    {
        [Display(Name = "مقاله علمی پژوهشی، علمی مروری منتشر شده در نشریات معتبر داخلی و خارجی (بر حسب اعتبار مجله)")]
        A = 1,
       
        [Display(Name = "مقاله علمی منتشر شده در نشریات علمی ترویجی داخلی معتبر")]
        B = 2,
       
        [Display(Name = "مقاله علمی كامل ارائه شده در كنفرانس‌های علمی معتبر (بین المللی)")]
        C_A = 3,
        [Display(Name = "مقاله علمی كامل ارائه شده در كنفرانس‌های علمی معتبر (ملی)")]
        C_B = 4,
       
        [Display(Name = "خلاصه مقاله علمی ارائه شده در كنفرانس‌های علمی معتبر (بین المللی)")]
        D_A = 5,
        [Display(Name = "خلاصه مقاله علمی ارائه شده در كنفرانس‌های علمی معتبر (ملی)")]
        D_B = 6,

        [Display(Name = "شركت در كارگاه‌ها و دوره‌های آموزشی تخصصی")]
        E = 7,
        
        [Display(Name = "داوری مقاله علمی پژوهشی نشریه‌های معتبر")]
        F = 8,
        
        [Display(Name = "داوری مقاله كنفرانس")]
        G = 9,
        
        [Display(Name = "راهنمایی پروژه پایان دوره كارشناسی")]
        H = 10,
        
        [Display(Name = "استاد راهنمای مشترك پایان نامه كارشناسی ارشد")]
        I = 11,
        
        [Display(Name = "استاد مشاور پایان نامه كارشناسی ارشد")]
        J = 12,
        
        [Display(Name = "استاد راهنمای مشترك رساله دكترای تخصصی")]
        K = 13,
       
        [Display(Name = "استاد مشاور رساله دكترای تخصصی")]
        L = 14,
        
        [Display(Name = "هدایت محقق پسا دكتری، محقق فرصت مطالعاتی صنعتی و ...")]
        M = 15,
       
    }
}
