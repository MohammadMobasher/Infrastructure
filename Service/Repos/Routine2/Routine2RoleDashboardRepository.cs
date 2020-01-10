using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Utilities;
using DataLayer.DTO.Routine2RoleDashboard;
using DataLayer.Entities.ExireRoutine;
using DataLayer.ViewModels.Routin2;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repos.Routine2
{
    public class Routine2RoleDashboardRepository : GenericRepository<Routine2RoleDashboard>
    {
        public Routine2RoleDashboardRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// ثبت در این جدول
        /// مدلی که به این تابع فرستاده می شود باید به صورت شماره نقش و نام داشبورد باید باشد
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<SweetAlertExtenstion> AddAsync(List<DashboardRoleInsertViewModel> model)
        {
            try
            {

                await DeleteAsync(model.Select(x=> x.RoleId).Distinct().SingleOrDefault());
                var entity = Mapper.Map<List<Routine2RoleDashboard>>(model);
                await AddRangeAsync(entity);
                return SweetAlertExtenstion.Ok();
            }
            catch(Exception e)
            {
                return SweetAlertExtenstion.Error();
            }
        }

        public async Task<SweetAlertExtenstion> DeleteAsync(int RoleId)
        {
            try
            {
                var result = await Entities.Where(x => x.RoleId == RoleId).ToListAsync();
                if(result != null)
                    await DeleteRangeAsync(result);
                return SweetAlertExtenstion.Ok();
            }
            catch (Exception e)
            {
                return SweetAlertExtenstion.Error();
            }
        }


        /// <summary>
        /// گرفتن تمام داشبورد‌ها بر اساس شماره نقش
        /// </summary>
        /// <param name="RoleId">شماره نقش</param>
        /// <returns></returns>
        public async Task<List<Routine2RoleDashboardDTO>> GetAllDashboardByRoleIdAsync(int RoleId)
        {
            return await Entities.Where(x => x.RoleId == RoleId).ProjectTo<Routine2RoleDashboardDTO>().ToListAsync();
        }

        public List<Routine2RoleDashboardDTO> GetAllDashboardByRoleId(int RoleId)
        {
            return Entities.Where(x => x.RoleId == RoleId).ProjectTo<Routine2RoleDashboardDTO>().ToList();
        }

    }
}
