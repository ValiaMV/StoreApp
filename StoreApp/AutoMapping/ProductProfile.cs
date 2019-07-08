using AutoMapper;
using BusinessLogic.Models;
using DataAccess.Entities;
using StoreApp.Models;

namespace StoreApp.AutoMapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductModel, ProductViewModel>().ForMember(pr => pr.CategoryName, opts => opts.MapFrom(src => src.Category.Name)).ReverseMap();
            CreateMap<ProductModel, Product>().ReverseMap();
        }
    }
}
