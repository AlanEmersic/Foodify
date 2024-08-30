namespace Foodify.Application.Orders.DTO;

public sealed record UserOrdersSummaryDto
{
    public Guid UserId { get; init; }
    public string Email { get; init; } = null!;
    public decimal TotalAmountSpent { get; init; }
    public IReadOnlyList<MonthlySpendingDto> MonthlySpendings { get; init; } = null!;
}