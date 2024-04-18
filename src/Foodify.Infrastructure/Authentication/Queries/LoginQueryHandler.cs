using ErrorOr;
using Foodify.Application.Authentication.DTO;
using Foodify.Domain.Common.Interfaces;
using Foodify.Domain.Repositories;
using Foodify.Domain.Users;
using Foodify.Infrastructure.Authentication.Errors;
using MediatR;

namespace Foodify.Infrastructure.Authentication.Queries;

internal sealed class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationDto>>
{
    private readonly IUserRepository userRepository;
    private readonly IPasswordHasher passwordHasher;
    private readonly IJwtTokenGenerator jwtTokenGenerator;

    public LoginQueryHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtTokenGenerator jwtTokenGenerator)
    {
        this.userRepository = userRepository;
        this.passwordHasher = passwordHasher;
        this.jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<AuthenticationDto>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        User? user = await userRepository.GetByEmailAsync(query.Email);

        return user is null || !user.IsCorrectPasswordHash(query.Password, user.Password, passwordHasher)
            ? AuthenticationErrors.InvalidCredentials
            : new AuthenticationDto(user.Email, jwtTokenGenerator.GenerateToken(user));
    }
}