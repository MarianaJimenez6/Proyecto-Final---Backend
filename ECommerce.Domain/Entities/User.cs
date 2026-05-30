// ECommerce.Domain/Entities/User.cs
using ECommerce.Domain.Entities;   // BaseEntity

namespace ECommerce.Domain.Entities;

public class User : BaseEntity
{
    public string Email { get; private set; } = string.Empty;
    public string Name { get; private set; } = string.Empty;
    public string PasswordHash { get; private set; } = string.Empty;
    public string Role { get; private set; } = "Customer";
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    private User() { }

    public User(string name, string email, string passwordHash, string role = "Customer")
    {
        Name = name;
        Email = email;
        PasswordHash = passwordHash;
        Role = role;
        CreatedAt = DateTime.UtcNow;
    }
}