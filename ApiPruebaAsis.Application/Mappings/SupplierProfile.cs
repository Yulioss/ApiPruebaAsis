using ApiPruebaAsis.Application.DTOs.Supplier;
using ApiPruebaAsis.Domain.Entitites;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPruebaAsis.Application.Mappings
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<CreateSupplierDto, Supplier>();

            CreateMap<Supplier, SupplierDto>();
        }
    }
}
