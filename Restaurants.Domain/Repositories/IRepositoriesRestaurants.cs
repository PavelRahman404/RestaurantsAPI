using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories
{
    public interface IRepositoriesRestaurants
    {
        Task<IEnumerable<Restaurant>> GetAllAsync();
    }
}
