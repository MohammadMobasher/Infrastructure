using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.SSOT.Promotion
{
    public enum ArticlePromotionArticleTypeSSOT
    {
        [Display(Name ="ISI")]
        ISI = 1,

        [Display(Name ="علمی-پژوهشی")]
        ScientificResearch = 2
    }
}
