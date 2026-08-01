using ApiPruebaAsis.Application.DTOs.Category;
using ApiPruebaAsis.Application.DTOs.Supplier;
using ApiPruebaAsis.Application.Interfaces;
using ApiPruebaAsis.Domain.Entitites;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPruebaAsis.Application.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _repository;
        private readonly IMapper _mapper;

        public SupplierService(
            ISupplierRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<SupplierDto> CreateAsync(CreateSupplierDto dto)
        {
            var supplier = _mapper.Map<Supplier>(dto);

            supplier = await _repository.AddAsync(supplier);

            return _mapper.Map<SupplierDto>(supplier);
        }

        public async Task<IEnumerable<SupplierDto>> GetAllAsync()
        {
            var suppliers = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<SupplierDto>>(suppliers);
        }
    }
}
