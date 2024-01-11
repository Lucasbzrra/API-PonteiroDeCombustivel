
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public abstract class BaseEntityLocation:BaseEntity
{
    [Required]
    public string City { get; set; }
    [Required]
    public string UF { get; set; }

    public string? ReferencePoint { get; set; }
}
