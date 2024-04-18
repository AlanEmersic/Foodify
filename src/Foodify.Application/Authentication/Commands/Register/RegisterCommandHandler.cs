using ErrorOr;
using Foodify.Application.Authentication.DTO;
using Foodify.Application.Authentication.Mappings;
using Foodify.Domain.Common.Interfaces;
using Foodify.Domain.Repositories;
using Foodify.Domain.Subscriptions;
using Foodify.Domain.Users;
using MediatR;

namespace Foodify.Application.Authentication.Commands.Register;

internal sealed class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationDto>>
{
    private readonly IUserRepository userRepository;
    private readonly IUnitOfWork unitOfWork;
    private readonly IPasswordHasher passwordHasher;
    private readonly IJwtTokenGenerator jwtTokenGenerator;

    public RegisterCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IPasswordHasher passwordHasher, IJwtTokenGenerator jwtTokenGenerator)
    {
        this.userRepository = userRepository;
        this.passwordHasher = passwordHasher;
        this.unitOfWork = unitOfWork;
        this.jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<AuthenticationDto>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        if (await userRepository.ExistsByEmailAsync(command.Email))
        {
            return Error.Conflict(description: "User with given email already exists");
        }

        ErrorOr<string> hashPasswordResult = passwordHasher.HashPassword(command.Password);

        if (hashPasswordResult.IsError)
        {
            return hashPasswordResult.Errors;
        }

        IReadOnlyCollection<Subscription> subscriptions = await userRepository.GetSubscriptionsAsync();
        Subscription subscription = subscriptions.Single(s => s.SubscriptionType == command.SubscriptionType);

        User user = command.MapToDomain(hashPasswordResult.Value, subscription.Id);

        await userRepository.AddAsync(user);
        await unitOfWork.CommitChangesAsync(cancellationToken);

        string token = jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationDto(user.Email, token);
    }
}