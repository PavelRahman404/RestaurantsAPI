using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories
{
    public interface IRepositoriesDishes
    {
        Task<int> Create(Dish entity);
        Task Delete(IEnumerable<Dish> entities);
    }
}
