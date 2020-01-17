
using DataLayer.Entities.Common;
using DataLayer.SSOT.Promotion;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities.Promotion
{
    public class Promotion : BaseEntity<int>
    {

        public PromotionTypesSSOT Type { get; set; }

        public string Title { get; set; }

        public int? ParentId { get; set; }

        /// <summary>
        /// امتیاز در هر ردیف
        /// </summary>
        public float? ScorePerRow { get; set; }

        /// <summary>
        /// امتیاز در هر مورد
        /// </summary>
        public float? ScorePerCase { get; set; }

        /// <summary>
        /// ترتیب نمایش
        /// </summary>
        public int SortOrder { get; set; }

    }
}
