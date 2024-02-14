
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public abstract class BaseEntityLocation:BaseEntity
{
    public string Country { get; set; }
    
    public string City { get; set; }
    public string UF { get; set; }

    public string? ReferencePoint { get; set; }

    public string Cep { get; set; }

    public string Lat { get; set; }
    public string Lng { get; set; }

}
