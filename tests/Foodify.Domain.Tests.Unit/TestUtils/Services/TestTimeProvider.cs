using Foodify.Domain.Common.Interfaces;

namespace Foodify.Domain.Tests.Unit.TestUtils.Services;

internal sealed class TestTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => fixedDateTime ?? DateTime.UtcNow;

    private readonly DateTime? fixedDateTime;

    public TestTimeProvider(DateTime? fixedDateTime = null)
    {
        this.fixedDateTime = fixedDateTime;
    }
}
