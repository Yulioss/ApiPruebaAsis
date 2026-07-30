using ApiPruebaAsis.Domain.Entitites;


namespace ApiPruebaAsis.Application.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> AddAsync(Category category);
        Task<List<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
    }
}
