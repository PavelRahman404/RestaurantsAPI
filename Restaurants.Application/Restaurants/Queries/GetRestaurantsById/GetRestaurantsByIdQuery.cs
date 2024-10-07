using MediatR;
using Restaurants.Application.Restaurants.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurantsById
{
    public class GetRestaurantsByIdQuery : IRequest<RestaurantDto?>
    {
        public GetRestaurantsByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; }
    }
}
