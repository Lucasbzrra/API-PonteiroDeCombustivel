

using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class User :IdentityUser
{
    public User() : base() { }
    public DateTimeOffset DateCreated { get; set; }

    public DateTimeOffset DateUpdate { get; set; }
    public DateTimeOffset DateDeleted { get; set; }
}
