using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.SSOT.Promotion
{
    public enum BookPromotionBookTypeSSOT
    {
        [Display(Name ="تالیف")]
        Compilation = 1,

        [Display(Name ="تصنیف")]
        Ballad = 2
    }
}
