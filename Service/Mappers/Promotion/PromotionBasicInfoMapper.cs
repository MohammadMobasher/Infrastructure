using AutoMapper;
using DataLayer.DTO.Promotion.PromotionBasicInfo;
using DataLayer.Entities.Promotion;
using DataLayer.ViewModels.Promotion.PromotionBasicInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Mappers.Promotion
{
    public class PromotionBasicInfoMapper : Profile
    {
        public PromotionBasicInfoMapper()
        {
            CreateMap<InsertPromotionBasicInfoListView, PromotionBasicInfo>();
            CreateMap<PromotionBasicInfo, PromotionBasicInfoFullDTO>();
        }
    }
}
