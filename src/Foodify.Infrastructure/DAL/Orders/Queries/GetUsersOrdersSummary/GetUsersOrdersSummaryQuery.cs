using ErrorOr;
using Foodify.Application.Authorization;
using Foodify.Application.Orders.DTO;
using MediatR;

namespace Foodify.Infrastructure.DAL.Orders.Queries.GetUsersOrdersSummary;

[Authorize(Roles = Roles.Admin)]
public sealed record GetUsersOrdersSummaryQuery : IRequest<ErrorOr<IReadOnlyList<UserOrdersSummaryDto>>>;