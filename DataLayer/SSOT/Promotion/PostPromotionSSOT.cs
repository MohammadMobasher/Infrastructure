using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.SSOT.Promotion
{
    public enum PostPromotionSSOT
    {
        [Display(Name = "رئیس پژوهشگاه")]
        A = 1,

        [Display(Name = "معاونین پژوهشگاه")]
        B = 2,
        
        [Display(Name = "رئیس پژوهشكده")]
        C = 3,
        
        [Display(Name = "معاون پژوهشكده")]
        D = 4,
        
        [Display(Name = "مدیر گروه پژوهشی/ رئیس مركز توسعه فناوری")]
        E = 5,
        
        [Display(Name = "رئیس/ مدیر بلافصل رئیس پژوهشگاه")]
        F = 6,
       
        [Display(Name = "رئیس/ مدیر بلافصل معاونین پژوهشگاه")]
        G = 7,
        
        [Display(Name = "معاون گروه پژوهشی")]
        H = 8,
        
        [Display(Name = "معاون مركز توسعه فناوری")]
        I = 9,
       
        [Display(Name = "مدیر/ مسئول آزمایشگاه تخصصی")]
        J = 10,
        
        [Display(Name = "سایر مسئولیت‌های تخصصی")]
        K = 11,

        [Display(Name = "دبیر كنفرانس‌ها")]
        L = 12,

        [Display(Name = "همكاری مؤثر در تاسیس مراكز تحقیقاتی، مراكز رشد و شركتهای دانش بنیان")]
        M = 13,
        
        [Display(Name = "سردبیر/ عضو هیأت تحریریه نشریه‌های علمی و پژوهشی خارجی")]
        N = 14,
        
        [Display(Name = "عضو شوراها و كمیته‌های علمی و اجرائی مورد تأیید معاونت پژوهشی/ فناوری")]
        O = 15,
        
        [Display(Name = "سردبیر/ عضو هیأت تحریریه نشریه‌های علمی و پژوهشی داخلی")]
        P = 16,
        
        [Display(Name = "مسئول نمایشگاه‌های پژوهشی فناوری")]
        Q = 17,

        [Display(Name = "طراح و مسئول كارگاه‌های آموزشی و پژوهشی")]
        R = 18,
    }
}
