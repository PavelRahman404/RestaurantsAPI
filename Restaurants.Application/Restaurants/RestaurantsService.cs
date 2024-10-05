﻿using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants
{
    public class RestaurantsService(IRepositoriesRestaurants repositoriesRestaurants,
        ILogger<RestaurantsService> logger, IMapper mapper) : IRestaurantsService
    {
        public async Task<int> Create(CreateRestaurantDto dto)
        {
            logger.LogInformation("Creating a new reatuarnt");

            var restaurant = mapper.Map<Restaurant>(dto);

            int id = await repositoriesRestaurants.Create(restaurant);

            return id;
        }

        public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
        {
            logger.LogInformation("Getting all restaurants");

            var restaurants = await repositoriesRestaurants.GetAllAsync();

            var restaurantsDtos = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);

            return restaurantsDtos!;
        }

        public async Task<RestaurantDto?> GetById(int id)
        {
            logger.LogInformation($"Getting restaurant {id}");

            var restaurant = await repositoriesRestaurants.GetByIdAsync(id);

            var restaurantDto = mapper.Map<RestaurantDto?>(restaurant);

            return restaurantDto;
        }
    }
}
