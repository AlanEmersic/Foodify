using ErrorOr;
using Foodify.Application.Users.DTO;
using Foodify.Application.Users.Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Foodify.Infrastructure.DAL.Users.Queries.GetUser;

internal sealed class GetUserQueryHandler : IRequestHandler<GetUserQuery, ErrorOr<UserDto>>
{
    private readonly FoodifyDbContext context;

    public GetUserQueryHandler(FoodifyDbContext context)
    {
        this.context = context;
    }


    public async Task<ErrorOr<UserDto>> Handle(GetUserQuery query, CancellationToken cancellationToken)
    {
        UserDto? user = await context.Users
            .AsNoTracking()
            .Include(x => x.Subscription)
            .Where(x => x.Email == query.Email)
            .Select(x => x.MapToDto())
            .SingleOrDefaultAsync(cancellationToken: cancellationToken);

        if (user is null)
        {
            return Error.NotFound(description: "User not found");
        }

        return user;
    }
}