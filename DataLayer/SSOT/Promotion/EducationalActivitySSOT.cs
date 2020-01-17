using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.SSOT.Promotion
{
    public enum EducationalActivitySSOT
    {
        [Display(Name = "تدريس هر واحد درس تخصصي")]
        A = 1,

        [Display(Name = "ارائه كارگاههاي آموزشي تخصصي (معادل يك واحد درس كارشناسي)")]
        B = 2,

        [Display(Name = "تدريس دركارگاههاي آموزشي (به ازاي هر 6 ساعت)")]
        C = 3,
    }
}
