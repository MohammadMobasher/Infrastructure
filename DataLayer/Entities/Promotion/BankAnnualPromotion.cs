using DataLayer.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entities.Promotion
{
    /// <summary>
    /// به ازای هر سال یک ترفیع باید انجام شود
    /// پس قبل از هر کاری کارشناس باید یک رکورد در این جدول ایجاد کرده، تا اعضای هئیت علمی براساس اطلاعاتی برای 
    /// آن سال در این جدول درج شده است به کار خود ادامه(ترفیع) دهند
    /// </summary>
    public class BankAnnualPromotion : BaseEntity<int>
    {
        /// <summary>
        /// بازه شروع
        /// فقط از این بازه میتوان برای این ترفیع سالیانه اعضای هئیت علمی اطلاعات بارگذاری کنند
        /// </summary>
        [Required]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// بازه پایان
        /// فقط تا این بازه میتوان برای این ترفیع سالیانه اعضای هئیت علمی اطلاعات بارگذاری کنند
        /// </summary>
        [Required]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// متنی که قرار است برای اعضای هئیت علمی ابتدا نمایش داده شود
        /// سپس بعد از زدن تیک شرایط فوق رار قبول دارم به مرحله بعد برود
        /// </summary>
        public string Description { get; set; }

    }
}
