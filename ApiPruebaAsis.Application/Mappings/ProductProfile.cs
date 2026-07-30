using ApiPruebaAsis.Application.DTOs.Product;
using ApiPruebaAsis.Domain.Entitites;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPruebaAsis.Application.Mappings
{
    public class ProductProfile: Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
            .ForMember(x => x.CategoryName,
                y => y.MapFrom(z => z.Category.CategoryName))
            .ForMember(x => x.SupplierName,
                y => y.MapFrom(z => z.Supplier.CompanyName));

            CreateMap<UpdateProductDto, Product>();

            CreateMap<CreateProductDto, Product>();

        }
    }
}
