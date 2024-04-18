namespace Foodify.Application.Users.DTO;

public sealed record CurrentUserDto(Guid Id, IReadOnlyCollection<string> Roles);