using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public abstract class BaseEntity
{
    [Key]
    public Guid Id { get; set; }
    public DateTimeOffset DateCreated { get; set; }

    public DateTimeOffset DateUpdate { get; set; }
    public DateTimeOffset DateDeleted { get; set; }
}
