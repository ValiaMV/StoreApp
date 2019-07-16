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
    public class DeliveryProfile : Profile
    {

        public DeliveryProfile()
        {
            CreateMap<Delivery, DeliveryModel>().ReverseMap();
            CreateMap<DeliveryModel, DeliveryViewModel>().ReverseMap();
        }
    }
}
