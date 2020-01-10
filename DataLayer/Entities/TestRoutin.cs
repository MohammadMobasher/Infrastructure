using DataLayer.Entities.Common;
using DataLayer.Interface.Routin2;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entities
{
    public class TestRoutin : BaseEntity<int>, IRoutine2Entity
    {
        public string Title { get; set; } = "mohammad";


        #region Routin Prop
        public int RoutineStep { get; set; }
        public bool RoutineIsFlown { get; set; }
        public bool RoutineIsDone { get; set; }
        public DateTime? RoutineFlownDate { get; set; }
        public DateTime? RoutineStepChangeDate { get; set; }
        public bool RoutineIsSucceeded { get; set; }
        
        #endregion
    }
}
