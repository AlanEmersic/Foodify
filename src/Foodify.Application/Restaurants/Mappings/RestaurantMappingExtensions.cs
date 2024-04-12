using Foodify.Application.Restaurants.Commands.CreateRestaurant;
using Foodify.Application.Restaurants.DTO;
using Foodify.Domain.Restaurants;

namespace Foodify.Application.Restaurants.Mappings;

public static class RestaurantMappingExtensions
{
    public static RestaurantDto MapToDto(this Restaurant restaurant)
    {
        return new RestaurantDto
        {
            Id = restaurant.Id,
            Name = restaurant.Name,
            Description = restaurant.Description,
            Address = restaurant.Address,
            Email = restaurant.Email,
            ImageUrl = restaurant.ImageUrl,
            Products = restaurant.Products?.Select(product => product.MapToDto()).ToList()
        };
    }

    public static ProductDto MapToDto(this Product product)
    {
        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            ImageUrl = product.ImageUrl
        };
    }

    public static Restaurant MapToDomain(this CreateRestaurantCommand command)
    {
        return new Restaurant
        {
            Name = command.Name,
            Description = command.Description,
            Address = command.Address,
            Email = command.Email
        };
    }
}