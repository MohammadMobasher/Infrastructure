﻿using DataLayer.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.DTO.Promotion.PromotionBasicInfo
{
    public class PromotionBasicInfoFullDTO
    {
        public int Id { get; set; }


        /// <summary>
        /// شماره کاربری هیئت علمی مورد نظر
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// تاریخ شروع به کار هیئت علمی
        /// </summary>
        public DateTime StartToWork { get; set; }

        /// <summary>
        /// آخرین پایه استحقاقی
        /// </summary>
        public int DeservedLastGrade { get; set; }

        /// <summary>
        /// آخرین پایه ایثارگری
        /// </summary>
        public int SacrificeLastGrade { get; set; }

        /// <summary>
        /// آخرین پایه تشویقی
        /// </summary>
        public int IncentivesLastGrade { get; set; }

        /// <summary>
        /// فایل آخرین حکم کارگزینی
        /// در این فیلد باید آدرس 
        /// PDF
        /// مربوط به تمام مستندات آخرین فایل کارگزینی فرد ذخیره شود
        /// </summary>
        public string SentenceFile { get; set; }

        /// <summary>
        /// فایل ساعات کارکرد
        /// </summary>
        public string WorkingHoursFile { get; set; }

        /// <summary>
        /// زمانی که این درخواست ثبت شده است
        /// </summary>
        public DateTime DateRequest { get; set; }

        #region Routin Prop
        public int RoutineStep { get; set; }
        public bool RoutineIsFlown { get; set; }
        public bool RoutineIsDone { get; set; }
        public DateTime? RoutineFlownDate { get; set; }
        public DateTime? RoutineStepChangeDate { get; set; }
        public bool RoutineIsSucceeded { get; set; }

        #endregion

        #region Relation

        [ForeignKey(nameof(UserId))]
        public Users User { get; set; }

        #endregion

    }
}
