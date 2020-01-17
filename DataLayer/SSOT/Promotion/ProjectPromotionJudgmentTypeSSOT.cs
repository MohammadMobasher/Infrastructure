using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.SSOT.Promotion
{
    public enum ProjectPromotionJudgmentTypeSSOT
    {
        [Display(Name ="طرح")]
        Plan = 1,

        [Display(Name ="پروژه پژوهشی (اعم از طرح استاد یا پروژه‌های برونسپاری شده و سایر)")]
        ResearchProject = 2,

        [Display(Name ="پایان‌نامه")]
        Thesis = 3,

        [Display(Name ="رساله")]
        Tract = 4,

        [Display(Name ="کتاب")]
        Book = 5,

        [Display(Name ="ثبت اختراع")]
        Patent = 6
    }
}
