using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entities.Common
{
    public interface IEntity
    {
    }

    public abstract class BaseEntity<TKey> : IEntity
    {
        public TKey Id { get; set; }


        #region مربوط به روتین است

        /// <summary>
        /// // این فیلد روی هیچ جدولی اعمال نمیشود
        /// </summary>
        [NotMapped]
        public List<int> DoneSteps { get; set; } = new List<int>() ;
        /// <summary>
        /// // این فیلد روی هیچ جدولی اعمال نمیشود
        /// </summary>
        [NotMapped]
        public List<int> SucceededSteps { get; set; } = new List<int>() ;
        

        #endregion

    }

    public abstract class BaseEntity : BaseEntity<int>
    {
    }
}
