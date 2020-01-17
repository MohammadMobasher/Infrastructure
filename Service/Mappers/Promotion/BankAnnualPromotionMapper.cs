using AutoMapper;
using DataLayer.DTO.Promotion.BankAnnualPromotion;
using DataLayer.Entities.Promotion;
using DataLayer.ViewModels.Promotion.BankAnnualPromotion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Mappers.Promotion
{
    public class BankAnnualPromotionMapper : Profile
    {

        public BankAnnualPromotionMapper()
        {

            CreateMap<InsertBankAnnualPromotionListView, BankAnnualPromotion>();
            CreateMap<BankAnnualPromotion, BankAnnualPromotionDTO>();
            //CreateMap<InsertBankAnnualPromotionListView, BankAnnualPromotion>();

        }
    }

}
