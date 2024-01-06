using Domain.Entities;

namespace Application.VehicleCases.CreateVehicle.Query;

public sealed record CreateVehicleResponseDto
{

    public string Name { get; set; }

    public string Plate { get; set; }

    public double KmPerLiter { get; set; }

    public ICollection<Fuel>? Fuel { get; set; }

}
