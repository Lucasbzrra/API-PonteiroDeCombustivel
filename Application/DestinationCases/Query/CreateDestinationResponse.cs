using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Application.DestinationCases.Query;

public class CreateDestinationResponse
{
    public string Country { get; set; }

    public string  Cep { get; set; }
    public string City { get; set; }
    public string UF { get; set; }

    public string? ReferencePoint { get; set; }

    public int IdDestination { get; set; }
}
