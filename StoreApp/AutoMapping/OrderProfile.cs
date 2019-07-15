using AutoMapper;
using BusinessLogic.Models;
using DataAccess.Entities;
using StoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.AutoMapping
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderViewModel, OrderModel>().ReverseMap();
            CreateMap<OrderModel, Order>().ReverseMap();
        }
    }
}
