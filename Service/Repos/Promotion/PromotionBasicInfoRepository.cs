using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Utilities;
using DataLayer.DTO.Promotion.PromotionBasicInfo;
using DataLayer.Entities.Promotion;
using DataLayer.ViewModels.Promotion.PromotionBasicInfo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repos.Promotion
{
    public class PromotionBasicInfoRepository : GenericRepository<PromotionBasicInfo>
    {
        public PromotionBasicInfoRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }


        public async Task<Tuple<int, List<PromotionBasicInfoFullDTO>>> LoadAsyncCount(
           int skip = -1,
           int take = -1,
           PromotionBasicInfoSearchViewModel model = null)
        {
            var query = Entities.ProjectTo<PromotionBasicInfoFullDTO>();

            
            int Count = query.Count();

            query = query.OrderByDescending(x => x.Id);


            if (skip != -1)
                query = query.Skip((skip - 1) * take);

            if (take != -1)
                query = query.Take(take);

            return new Tuple<int, List<PromotionBasicInfoFullDTO>>(Count, await query.ToListAsync());
        }


        /// <summary>
        /// ثبت در این جدول
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<SweetAlertExtenstion> InsertAsync(InsertPromotionBasicInfoListView model)
        {
            try
            {
                var entity = Mapper.Map<PromotionBasicInfo>(model);
                await AddAsync(entity);
                return SweetAlertExtenstion.Ok();
            }
            catch
            {
                return SweetAlertExtenstion.Error();
            }
        }
    }
}
