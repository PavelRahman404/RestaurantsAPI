using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
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
                    throw new NotFoundException(nameof(Restaurant), request.Id.ToString());

            await  repositoriesRestaurants.Delete(restaurant);
            return true;
        }
    }
}
