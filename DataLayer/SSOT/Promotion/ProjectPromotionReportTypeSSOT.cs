using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.SSOT.Promotion
{
    public enum ProjectPromotionReportTypeSSOT
    {
        [Display(Name ="مرحله ای")]
        Phase = 1,
        
        [Display(Name ="نهایی")]
        Ultimate = 2
    }
}
