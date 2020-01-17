using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.SSOT.Promotion
{
    public enum PromotionTypesSSOT
    {
        [Display(Name = "گروه اصلی")]
        MainGroup = 1,

        [Display(Name = "شاخص اصلی")]
        MainIndex = 2,

        [Display(Name = "شاخص فرعی")]
        Index = 3
    }
}
