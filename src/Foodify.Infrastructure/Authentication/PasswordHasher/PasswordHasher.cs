﻿using ErrorOr;
using Foodify.Domain.Common.Interfaces;
using System.Text.RegularExpressions;

namespace Foodify.Infrastructure.Authentication.PasswordHasher;

internal partial class PasswordHasher : IPasswordHasher
{
    [GeneratedRegex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", RegexOptions.Compiled)]
    private static partial Regex StrongPasswordRegex();
    private static readonly Regex PasswordRegex = StrongPasswordRegex();

    public ErrorOr<string> HashPassword(string password)
    {
        return !PasswordRegex.IsMatch(password)
            ? Error.Validation(description: "Password too weak")
            : BCrypt.Net.BCrypt.EnhancedHashPassword(password);
    }

    public bool IsCorrectPassword(string password, string hash)
    {
        return BCrypt.Net.BCrypt.EnhancedVerify(password, hash);
    }
}