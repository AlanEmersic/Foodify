using ErrorOr;
using Foodify.Domain.Common.Interfaces;
using Foodify.Domain.Repositories;
using Foodify.Domain.Restaurants;
using MediatR;

namespace Foodify.Application.Restaurants.Commands.DeleteRestaurant;

internal sealed class DeleteRestaurantCommandHandler : IRequestHandler<DeleteRestaurantCommand, ErrorOr<Deleted>>
{
    private readonly IRestaurantsRepository restaurantsRepository;
    private readonly IUnitOfWork unitOfWork;

    public DeleteRestaurantCommandHandler(IRestaurantsRepository restaurantsRepository, IUnitOfWork unitOfWork)
    {
        this.restaurantsRepository = restaurantsRepository;
        this.unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Deleted>> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
    {
        Restaurant? restaurant = await restaurantsRepository.GetByIdAsync(request.Id);

        if (restaurant is null)
        {
            return Error.NotFound(description: "Restaurant not found");
        }

        await restaurantsRepository.DeleteAsync(restaurant);
        await unitOfWork.CommitChangesAsync(cancellationToken);

        return Result.Deleted;
    }
}