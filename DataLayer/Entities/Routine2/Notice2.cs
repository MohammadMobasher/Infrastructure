using DataLayer.Entities.Common;
using DataLayer.Entities.Users;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DataLayer.Entities.ExireRoutine
{
    public class Notice2 : BaseEntity<int>
    {
        public DateTime CreateDate { get; set; }
        public int? CreatorUserId { get; set; }
        public int? ToUserId { get; set; }
        public bool IsRead { get; set; }

        
        public string Body { get; set; }

        
        public int? RoutineId { get; set; }

        public int? EntityId { get; set; }

        [ForeignKey("CreatorUserId")]
        public virtual Users.Users CreatorUser { get; set; }

        [ForeignKey("ToUserId")]
        public virtual Users.Users ToUser { get; set; }

        [ForeignKey("RoutineId")]
        public virtual Routine2 Routine { get; set; }
    }
}
