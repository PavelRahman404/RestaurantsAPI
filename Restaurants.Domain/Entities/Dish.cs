namespace Restaurants.Domain.Entities
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Desciption { get; set; } = default!;
        public decimal Price { get; set; }

    }
}