using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.SSOT.Promotion
{
    public enum ProjectPromotionTypeSSOT
    {
        [Display(Name = "طرح")]
        Plan = 1,

        [Display(Name ="پروژه")]
        Project =2
    }
}
