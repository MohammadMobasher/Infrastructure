using System;
using DataLayer.Entities.ExireRoutine;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.DTO.Routin2RoleDTO
{
    public class Routin2RoleFullDetailDTO
    {
        public int Id { get; set; }
        public int RoutineId { get; set; }
        public string Title { get; set; }
        public string DashboardEnum { get; set; }
        public int SortOrder { get; set; }

        [ForeignKey("RoutineId")]
        public virtual DataLayer.Entities.ExireRoutine.Routine2 Routine { get; set; }

    }
}
