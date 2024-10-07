using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurantsById
{
    public class GetRestaurantsByIdQueryHandler(IRepositoriesRestaurants repositoriesRestaurants,
        ILogger<GetRestaurantsByIdQueryHandler> logger, IMapper mapper) : IRequestHandler<GetRestaurantsByIdQuery, RestaurantDto?>
    {
        public async Task<RestaurantDto?> Handle(GetRestaurantsByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Getting restaurant {request.Id}");

            var restaurant = await repositoriesRestaurants.GetByIdAsync(request.Id);

            var restaurantDto = mapper.Map<RestaurantDto?>(restaurant);

            return restaurantDto;
        }
    }
}
