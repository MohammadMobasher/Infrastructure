using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.SSOT.Promotion
{
    public enum BookPromotionSSOT
    {
        [Display(Name = "كسب رتبه در جشنوارههای داخلی و خارجی با در نظر گرفتن اعتبار جشنواره و رتبه متقاضی")]
        A = 1,
       
        [Display(Name = "اختراع یا اكتشاف ثبت شده در داخل كشور (دارای تأییدیه از مراجع ذی صلاح)")]
        B = 2,
        
        [Display(Name = "اختراع یا اكتشاف ثبت شده در خارج از كشور")]
        C = 3,
        
        [Display(Name = "تولید و واگذاری دانش فنی/ اختراع یا اكتشاف منجر به تولید و تجاری سازی محصول (با تأیید مراجع ذیصلاح)")]
        D = 4,
        
        [Display(Name = "تألیف یا تصنیف كتاب (به زبان فارسی)")]
        E = 5,
        
        [Display(Name = "تألیف یا تصنیف كتاب (به زبان خارجی) چاپ شده توسط ناشران معتبر بین‌المللی")]
        F = 6,
        
        [Display(Name = "تألیف مجموعه كتاب‌هایی همانند دائره المعارف")]
        G = 7,
        
        [Display(Name = "تدوین كتاب به شیوه گردآوری")]
        H = 8,
       
        [Display(Name = "تدوین مجموعه مقالات همایش‌های علمی معتبر")]
        I = 9,
       
        [Display(Name = "ویرایش علمی كتاب")]
        J = 10,
       
        [Display(Name = "تصحیح انتقادی كتاب")]
        K = 11,
        
        [Display(Name = "ترجمه كتاب مرتبط با تخصص نویسنده")]
        L = 12,
    }
}
