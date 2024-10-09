﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes.Commands.CreateDish;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Dishes.Queries.GetDisheByIdForRestaurant
{
    public class GetDisheByIdForRestaurantQueryHandler(ILogger<GetDisheByIdForRestaurantQueryHandler> logger,
        IRepositoriesRestaurants repositoriesRestaurants,
        IMapper mapper) : IRequestHandler<GetDisheByIdForRestaurantQuery, DishDto>
    {
        public async Task<DishDto> Handle(GetDisheByIdForRestaurantQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Retrieving dish: {DishId}, for restaurant with id: {RestaurantId}", request.DishId, request.RestaurantId);
            var restaurant = await repositoriesRestaurants.GetByIdAsync(request.RestaurantId);
            if (restaurant == null) throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());

            var dish = restaurant.Dishes.FirstOrDefault(d=>d.Id == request.DishId);
            if (restaurant == null) throw new NotFoundException(nameof(Dish), request.DishId.ToString());

            var result = mapper.Map<DishDto>(dish);

            return result;
        }
    }
}
