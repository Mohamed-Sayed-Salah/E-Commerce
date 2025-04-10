﻿using AutoMapper;
using Domain.Entities;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.MappingProfile
{
    public class ProductProfile :Profile
    {
        public ProductProfile()
        {

            CreateMap<Product, ProductResultDTO>()
                .ForMember(d => d.BrandName,
                options => options.MapFrom(s => s.productBrand.Name))
                .ForMember(d => d.TypeName,
                options => options.MapFrom(s=>s.productType.Name));

            CreateMap<ProductBrand,BrandResultDTO>();
            CreateMap<ProductType, TypeResultDTO>();

        }
    }
}
