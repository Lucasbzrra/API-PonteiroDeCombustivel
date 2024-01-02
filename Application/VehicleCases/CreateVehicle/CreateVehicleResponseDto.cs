
using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Application.VehicleCases.CreateVehicle;

public sealed record CreateVehicleResponseDto
{
   
    public string Name { get; set; }

    public string Plate { get; set; }

    public double KmPerLiter { get; set; }

    public ICollection<Fuel>? Fuel { get; set; }

}
