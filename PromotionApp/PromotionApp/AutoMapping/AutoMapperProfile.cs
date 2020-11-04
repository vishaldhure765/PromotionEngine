using AutoMapper;
using PromotionApp.Edmx;
using PromotionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace PromotionApp.AutoMapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProductMasterViewModel, ProductMaster>();
            CreateMap<ProductMaster, ProductMasterViewModel>();
        }
    }
}