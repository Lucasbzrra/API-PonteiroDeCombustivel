

using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace Domain.Entities;

public class User :IdentityUser
{
    public DateTimeOffset DateCreated { get; set; }

    public DateTimeOffset DateUpdate { get; set; }

    public DateTimeOffset DateDeleted { get; set; }
    public User() : base() { }
  
}
