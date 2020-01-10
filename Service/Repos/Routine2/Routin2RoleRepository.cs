using AutoMapper.QueryableExtensions;
using DataLayer.DTO.Routin2RoleDTO;
using DataLayer.Entities.ExireRoutine;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repos.Routine2
{
    public class Routin2RoleRepository : GenericRepository<Routine2Role>
    {
        public Routin2RoleRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// لیست تمام کارتابل‌‌‌های موجود برای تمامی روتین ها
        /// </summary>
        /// <returns></returns>
        public async Task<List<Routin2RoleFullDetailDTO>> GetAllDashBoards()
        { 
            return await Entities.ProjectTo<Routin2RoleFullDetailDTO>().ToListAsync();
        }


        /// <summary>
        /// لیست تمام کارتابل‌‌‌های موجود برای یک روتین خاص
        /// </summary>
        /// <param name="RoutinId">شماره روتین مورد نظر</param>
        /// <returns></returns>
        public async Task<List<Routin2RoleFullDetailDTO>> GetAllDashBoardsByRoutinId(int RoutinId)
        {
            return await Entities.Where(x=> x.RoutineId == RoutinId).ProjectTo<Routin2RoleFullDetailDTO>().ToListAsync();
        }

    }
}

