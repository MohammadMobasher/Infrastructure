using DataLayer.Entities.Common;
using DataLayer.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entities.ExireRoutine
{
    /// <summary>
    /// ایجاد شده تویط مبشر
    /// از این جدول به منظور مدیریت نقش‌ها برای کارتابل‌ها استفاده می شود
    /// </summary>
    public class Routine2RoleDashboard : BaseEntity<int>
    {
        /// <summary>
        /// شماره نقش مربوطه
        /// کارتابل‌ها را به نقش‌ها را میدهیم
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// مربوط به نام کارتابل است
        /// از این فیلد برای مقایسه با کارتابل جاری اسفتاده می شود
        /// </summary>
        [Required]
        [MaxLength(1024)]
        public string DashboardEnum { get; set; }


        #region 

        [ForeignKey(nameof(RoleId))]
        public virtual Roles Roles { get; set; }
    
        #endregion

    }
}
