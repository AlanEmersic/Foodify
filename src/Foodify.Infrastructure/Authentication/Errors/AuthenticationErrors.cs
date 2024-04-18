using ErrorOr;

namespace Foodify.Infrastructure.Authentication.Errors;

public static class AuthenticationErrors
{
    public static readonly Error InvalidCredentials = Error.Validation(code: "Authentication.InvalidCredentials", description: "Invalid credentials");
}