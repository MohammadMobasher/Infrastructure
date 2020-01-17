using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.SSOT.Promotion
{
    public enum ArticlePromotionConferenceTypeSSOT
    {
        [Display(Name ="ملی")]
        National = 1,

        [Display(Name ="بین المللی")]
        International = 2
    }
}
