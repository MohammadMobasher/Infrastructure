using AutoMapper;
using DataLayer.DTO.Routin2RoleDTO;
using DataLayer.DTO.Routine2;
using DataLayer.DTO.Routine2RoleDashboard;
using DataLayer.Entities.ExireRoutine;
using DataLayer.ViewModels.Routin2;
using DataLayer.ViewModels.Routine2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Mappers
{
    public class RoutinMapper : Profile
    {

        public RoutinMapper()
        {
            // Routine2
            CreateMap<CreateRoutine2LogViewModel, Routine2Log>();
            CreateMap<Routine2, Routine2FullDTO>();
            CreateMap<Routine2Role, Routine2RoleDTO>();
            CreateMap<Routine2Role, Routin2RoleFullDetailDTO>();
            CreateMap<DashboardRoleInsertViewModel, Routine2RoleDashboard>();
            CreateMap<Routine2RoleDashboard, Routine2RoleDashboardDTO>();
            CreateMap<Routine2Step, Routine2StepDTO>();
            CreateMap<Routine2Action, Routine2ActionDTO>();
        }
       
    }
}
