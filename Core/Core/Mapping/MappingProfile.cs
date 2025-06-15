using AutoMapper;
using Core.Dao;
using Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
                .ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<ProductInStock, ProductInStockDto>().ReverseMap();
            CreateMap<ProductOrdered, ProductOrderedDto>().ReverseMap();
        }
    }
}
