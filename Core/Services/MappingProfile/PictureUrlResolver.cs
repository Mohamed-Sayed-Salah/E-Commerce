using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.MappingProfile
{
    public class PictureUrlResolver(IConfiguration _configuration) : IValueResolver<Product, ProductResultDTO, string>
    {
       
        public string Resolve(Product source, ProductResultDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return $"{_configuration["BaseUrl"]}{source.PictureUrl}";
            }
            return null;
        }
    }
}
