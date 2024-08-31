using Foodify.Application.Restaurants.Commands.CreateProduct;
using Foodify.Application.Restaurants.Commands.CreateRestaurant;
using Foodify.Application.Restaurants.DTO;
using Foodify.Domain.Orders;
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

    public static ProductSummaryDto MapToDto(this IGrouping<ProductGroupingKey, OrderItem> orderItemGroup)
    {
        return new ProductSummaryDto
        {
            ProductName = orderItemGroup.Key.Name,
            TotalQuantity = orderItemGroup.Sum(x => x.Quantity),
            Sales = orderItemGroup
                .GroupBy(x => x.Order!.PlacedTime.ToString("yyyy-MM"))
                .Select(monthGroup => new SalesDto
                {
                    Month = monthGroup.Key,
                    Quantity = monthGroup.Sum(x => x.Quantity)
                })
                .ToList()
        };
    }

    public static Restaurant MapToDomain(this CreateRestaurantCommand command)
    {
        return new Restaurant
        {
            Name = command.Name,
            Description = command.Description,
            Address = command.Address,
            Email = command.Email,
            ImageUrl = command.ImageUrl
        };
    }

    public static Product MapToDomain(this CreateProductCommand command)
    {
        return new Product
        {
            RestaurantId = command.RestaurantId,
            Name = command.Name,
            Description = command.Description,
            Price = command.Price,
            ImageUrl = command.ImageUrl
        };
    }
}