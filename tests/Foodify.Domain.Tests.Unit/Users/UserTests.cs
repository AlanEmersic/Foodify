using FluentAssertions;
using Foodify.Domain.Common.Interfaces;
using Foodify.Domain.Tests.Unit.TestConstants;
using Foodify.Domain.Tests.Unit.TestUtils.Users;
using Foodify.Domain.Users;
using NSubstitute;

namespace Foodify.Domain.Tests.Unit.Users;

public sealed class UserTests
{
    private readonly IPasswordHasher mockPasswordHasher = Substitute.For<IPasswordHasher>();

    [Fact]
    public void IsCorrectPasswordHash_ShouldReturnTrue_WhenPasswordIsCorrect()
    {
        // Arrange
        User user = UserFactory.Create(
            UserConstants.Email,
            UserConstants.Password,
            UserConstants.Phone,
            UserConstants.Address,
            UserConstants.CustomerRoles);

        mockPasswordHasher.IsCorrectPassword(UserConstants.Password, UserConstants.Password).Returns(true);

        // Act
        bool result = user.IsCorrectPasswordHash(UserConstants.Password, UserConstants.Password, mockPasswordHasher);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void IsCorrectPasswordHash_ShouldReturnFalse_WhenPasswordIsIncorrect()
    {
        // Arrange
        User user = UserFactory.Create(
            UserConstants.Email,
            UserConstants.Password,
            UserConstants.Phone,
            UserConstants.Address,
            UserConstants.CustomerRoles);

        mockPasswordHasher.IsCorrectPassword(UserConstants.Password, UserConstants.Password).Returns(false);

        // Act
        bool result = user.IsCorrectPasswordHash(UserConstants.Password, UserConstants.Password, mockPasswordHasher);

        // Assert
        result.Should().BeFalse();
    }
}