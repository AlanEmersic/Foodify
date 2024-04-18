using ErrorOr;
using Foodify.Application.Authentication.DTO;
using Foodify.Domain.Subscriptions;
using MediatR;

namespace Foodify.Application.Authentication.Commands.Register;

public sealed record RegisterCommand(string Email, string Password, string Phone, string Address, SubscriptionType SubscriptionType) : IRequest<ErrorOr<AuthenticationDto>>;