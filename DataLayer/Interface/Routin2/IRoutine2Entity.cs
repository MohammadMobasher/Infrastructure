using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Interface.Routin2
{
    public interface IRoutine2Entity
    {
        /// <summary>
        /// مرحله فعلی روال
        /// برابر با فیلد [RoutineStep].[Step]
        /// </summary>
        int RoutineStep { get; set; }

        /// <summary>
        /// آیا طرح وارد روال شده است یا خیر
        /// از این فیلد برای تفکیک کارتابل پیش‌نویس استفاده می‌کنیم
        /// </summary>
        bool RoutineIsFlown { get; set; }

        /// <summary>
        /// آیا طرح به اتمام رسیده است یا خیر
        /// از این فیلد برای تفکیک کارتابل خاتمه‌یافته‌ها استفاده می‌کنیم
        /// </summary>
        bool RoutineIsDone { get; set; }

        /// <summary>
        /// تاریخ اولیه به جریان افتادن روال
        /// این فیلد فقط بار اول پر می‌شود و دیگر آپدیت نمی‌شود
        /// </summary>
        DateTime? RoutineFlownDate { get; set; }

        /// <summary>
        /// تاریخ آخرین تغییر کارتابل روال
        /// با هر بار تغییر کارتابل روال، این فیلد آپدیت می‌شود
        /// </summary>
        DateTime? RoutineStepChangeDate { get; set; }

        /// <summary>
        /// آیا طرح با موفقیت همراه بوده است یا خیر
        /// طرح یا تایید نهایی می‌شود یا رد نهایی
        /// در کارتابل خاتمه‌یافته‌ها این طرح‌ها را فیلتر گذاری میکنیم
        /// </summary>
        bool RoutineIsSucceeded { get; set; }

        
    }
}
