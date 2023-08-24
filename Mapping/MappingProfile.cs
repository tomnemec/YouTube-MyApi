using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MyApi.Models;
using MyApi.Resources;

namespace MyApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //mapping from domain to API resources
            CreateMap<Customer, CustomerResource>();

            //api resource to domain
            CreateMap<SaveCustomerResource, Customer>();
        }

    }
}