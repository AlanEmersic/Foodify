using FluentAssertions;
using Foodify.Domain.Common.ValueObjects;

namespace Foodify.Domain.Tests.Unit.Common.ValueObjects;

public sealed class TimeRangeTests
{
    [Fact]
    public void Constructor_ShouldThrowArgumentException_WhenStartTimeIsAfterEndTime()
    {
        // Arrange
        TimeOnly start = new(12, 0);
        TimeOnly end = new(10, 0);

        // Act
        Action action = () => new TimeRange(start, end);

        // Assert
        action.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void IsOverlapping_ShouldReturnTrue_WhenOverlapping()
    {
        // Arrange
        TimeRange timeRange1 = new(new TimeOnly(10, 0), new TimeOnly(12, 0));
        TimeRange timeRange2 = new(new TimeOnly(11, 0), new TimeOnly(13, 0));

        // Act
        bool result = timeRange1.IsOverlapping(timeRange2);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void IsOverlapping_ShouldReturnFalse_WhenNotOverlapping()
    {
        // Arrange
        TimeRange timeRange1 = new(new TimeOnly(10, 0), new TimeOnly(12, 0));
        TimeRange timeRange2 = new(new TimeOnly(13, 0), new TimeOnly(14, 0));

        // Act
        bool result = timeRange1.IsOverlapping(timeRange2);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void IsOverlapping_ShouldReturnTrue_WhenTimeRangeIsSame()
    {
        // Arrange
        TimeRange timeRange1 = new(new TimeOnly(10, 0), new TimeOnly(12, 0));
        TimeRange timeRange2 = new(new TimeOnly(10, 0), new TimeOnly(12, 0));

        // Act
        bool result = timeRange1.IsOverlapping(timeRange2);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void IsOverlapping_ShouldReturnFalse_WhenTimeRangeIsAdjacent()
    {
        // Arrange
        TimeRange timeRange1 = new(new TimeOnly(10, 0), new TimeOnly(12, 0));
        TimeRange timeRange2 = new(new TimeOnly(12, 0), new TimeOnly(14, 0));

        // Act
        bool result = timeRange1.IsOverlapping(timeRange2);

        // Assert
        result.Should().BeFalse();
    }
}