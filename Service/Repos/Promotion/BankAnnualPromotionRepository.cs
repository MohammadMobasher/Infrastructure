using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Utilities;
using DataLayer.DTO.Promotion.BankAnnualPromotion;
using DataLayer.Entities.Promotion;
using DataLayer.ViewModels.Promotion.BankAnnualPromotion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repos.Promotion
{
    public class BankAnnualPromotionRepository : GenericRepository<BankAnnualPromotion>
    {
        public BankAnnualPromotionRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<Tuple<int, List<BankAnnualPromotionDTO>>> LoadAsyncCount(
           int skip = -1,
           int take = -1,
           BankAnnualPromotionSearchViewModel model = null)
        {
            var query = Entities.ProjectTo<BankAnnualPromotionDTO>();

            if (!string.IsNullOrEmpty(model.Description))
                query = query.Where(x => x.Description.Contains(model.Description));



            int Count = query.Count();

            query = query.OrderByDescending(x => x.Id);


            if (skip != -1)
                query = query.Skip((skip - 1) * take);

            if (take != -1)
                query = query.Take(take);

            return new Tuple<int, List<BankAnnualPromotionDTO>>(Count, await query.ToListAsync());
        }



        /// <summary>
        /// ثبت در این جدول
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<SweetAlertExtenstion> InsertAsync(InsertBankAnnualPromotionListView model)
        {
            try
            {
                var entity = Mapper.Map<BankAnnualPromotion>(model);

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
