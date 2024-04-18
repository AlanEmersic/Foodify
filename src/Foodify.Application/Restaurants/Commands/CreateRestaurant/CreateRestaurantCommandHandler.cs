using ErrorOr;
using Foodify.Application.Restaurants.Mappings;
using Foodify.Domain.Common.Interfaces;
using Foodify.Domain.Repositories;
using Foodify.Domain.Restaurants;
using MediatR;

namespace Foodify.Application.Restaurants.Commands.CreateRestaurant;

internal sealed class CreateRestaurantCommandHandler : IRequestHandler<CreateRestaurantCommand, ErrorOr<Created>>
{
    private readonly IRestaurantsRepository restaurantsRepository;
    private readonly IUnitOfWork unitOfWork;

    public CreateRestaurantCommandHandler(IRestaurantsRepository restaurantsRepository, IUnitOfWork unitOfWork)
    {
        this.restaurantsRepository = restaurantsRepository;
        this.unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Created>> Handle(CreateRestaurantCommand command, CancellationToken cancellationToken)
    {
        Restaurant restaurant = command.MapToDomain();
        await restaurantsRepository.AddAsync(restaurant);
        await unitOfWork.CommitChangesAsync(cancellationToken);

        return Result.Created;
    }
}