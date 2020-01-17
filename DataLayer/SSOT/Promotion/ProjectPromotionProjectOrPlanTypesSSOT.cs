using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.SSOT.Promotion
{
    public enum ProjectPromotionProjectOrPlanTypesSSOT
    {
        [Display(Name ="امانی")]
        Amani = 1,

        [Display(Name ="پیمانی")]
        Peymani = 2,

        [Display(Name ="مشارکتی")]
        Mosharekati = 3,

        [Display(Name ="مرتبط با موافقت نامه")]
        Mortabet = 4
    }
}
