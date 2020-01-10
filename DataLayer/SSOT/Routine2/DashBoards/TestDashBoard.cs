using DataLayer.Interface.Routin2;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.SSOT.Routine2.DashBoards
{
    public enum TestDashBoard
    {

        [Display(Name = "متقاضی")]
        Applicant,

        [Display(Name = "کارتابل کارشناس دفتر استانی")]
        Expert
    }
}
