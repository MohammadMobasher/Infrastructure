using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.SSOT.Promotion
{
    /// <summary>
    /// نوع پروژه انجام شده، زمانی از این استفاده می‌شود که پروژه باشد نه طرح
    /// </summary>
    public enum ProjectPromotionProjectTypesSSOT
    {
        [Display(Name ="آزمون ایده")]
        IdeaTest = 1,

        [Display(Name ="آینده پژوهی")]
        Futurology = 2,

        [Display(Name ="آینده نگری")]
        providence = 3,

        [Display(Name ="سیاست پژوهی")]
        ResearchPolicy = 4
    }
}
