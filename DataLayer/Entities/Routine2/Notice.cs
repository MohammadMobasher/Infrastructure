using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataLayer.Entities.Users;

namespace DataLayer.Entities.ExireRoutine
{
    public class Notice
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public int? CreatorUserId { get; set; }
        public int? ToUserId { get; set; }
        public bool IsRead { get; set; }
        [MaxLength(512)]
        public string Title { get; set; }
        public string Body { get; set; }
        [MaxLength(2048)]
        public string Module { get; set; }
        public int? EntityId { get; set; }

        [ForeignKey("CreatorUserId")]
        public virtual Users.Users CreatorUser { get; set; }

        [ForeignKey("ToUserId")]
        public virtual Users.Users ToUser { get; set; }
    }
}
