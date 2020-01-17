using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.SSOT.Promotion
{
    public enum ArticlePromotionArticleIndexSSOT
    {
        [Display(Name = "Q1")]
        Q1 = 1,

        [Display(Name = "Q2")]
        Q2 = 2,

        [Display(Name = "Q3")]
        Q3 = 3,

        [Display(Name = "Q4")]
        Q4 = 4,

        [Display(Name ="ISI فاقد شاخص Q")]
        NoIndex = 5
    }
}
