using ErrorOr;
using Foodify.Application.Orders.Mappings;
using Foodify.Application.Users.DTO;
using Foodify.Application.Users.Services;
using Foodify.Domain.Common.Interfaces;
using Foodify.Domain.Orders;
using Foodify.Domain.Repositories;
using Foodify.Domain.Users;
using MediatR;

namespace Foodify.Application.Orders.Commands.CreateOrder;

internal sealed class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, ErrorOr<Created>>
{
    private readonly IOrdersRepository orderRepository;
    private readonly IUnitOfWork unitOfWork;
    private readonly IDateTimeProvider dateTimeProvider;
    private readonly ICurrentUserProvider currentUserProvider;
    private readonly IUserRepository userRepository;

    public CreateOrderCommandHandler(IOrdersRepository orderRepository, IUnitOfWork unitOfWork, IDateTimeProvider dateTimeProvider, ICurrentUserProvider currentUserProvider, IUserRepository userRepository)
    {
        this.orderRepository = orderRepository;
        this.unitOfWork = unitOfWork;
        this.dateTimeProvider = dateTimeProvider;
        this.currentUserProvider = currentUserProvider;
        this.userRepository = userRepository;
    }

    public async Task<ErrorOr<Created>> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        CurrentUserDto currentUser = currentUserProvider.GetCurrentUser();
        User? user = await userRepository.GetByIdAsync(currentUser.Id);

        if (user is null)
        {
            return Error.NotFound(description: "User not found");
        }

        float subscriptionDiscount = user.Subscription!.DiscountRate;
        Random random = new();
        int randomMinutes = (int)Math.Round(random.NextDouble() * 20 / 5) * 5 + 20;
        DateTime placedTime = dateTimeProvider.UtcNow;
        DateTime completedTime = placedTime.AddMinutes(randomMinutes);
        OrderStatus status = OrderStatus.Delivered;

        Order order = command.MapToDomain(currentUser.Id, subscriptionDiscount, placedTime, completedTime, status);

        await orderRepository.AddAsync(order);
        await unitOfWork.CommitChangesAsync(cancellationToken);

        return Result.Created;
    }
}