namespace Foodify.Application.Orders.DTO;

public sealed record MonthlySpendingDto
{
    public string Month { get; init; } = null!;
    public decimal TotalSpent { get; init; }
}