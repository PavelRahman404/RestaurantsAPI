using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommandHandler(ILogger<DeleteRestaurantCommandHandler> logger,
        IRepositoriesRestaurants repositoriesRestaurants) : IRequestHandler<DeleteRestaurantCommand,bool>
    {
        public async Task<bool> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Deleting restaurant with id: {RestaurantId}", request.Id);
            var restaurant = await repositoriesRestaurants.GetByIdAsync( request.Id);
            if (restaurant == null)
            return false;

            await  repositoriesRestaurants.Delete(restaurant);
            return true;
        }
    }
}
