using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.SSOT.Promotion
{
    public enum ProjectPromotionAssistanceSSOT
    {
        [Display(Name ="پژوهشی")]
        Research = 1,

        [Display(Name ="فناوری")]
        Technology = 2,

        [Display(Name ="تخصصی (پژوهشکده)")]
        Specialty = 3
    }
}
