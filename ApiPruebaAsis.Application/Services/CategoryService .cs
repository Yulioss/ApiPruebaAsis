using ApiPruebaAsis.Application.DTOs.Category;
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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CategoryDto> CreateAsync(CreateCategoryDto dto)
        {
            var category = _mapper.Map<Category>(dto);

            await _repository.AddAsync(category);

            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categories = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }
    }
}
