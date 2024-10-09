﻿using MediatR;
using Restaurants.Application.Dishes.Dtos;

namespace Restaurants.Application.Dishes.Queries.GetDishesForRestaurant
{
    public class GetDishesForRestaurantQuery(int restaurentId): IRequest<IEnumerable<DishDto>>
    {
        public int RestaurantId { get; } = restaurentId;
    }
}
