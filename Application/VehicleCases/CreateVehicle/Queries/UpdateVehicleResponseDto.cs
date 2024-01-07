

namespace Application.VehicleCases.CreateVehicle.Queries;

public sealed record  UpdateVehicleResponseDto
{
    public string Name { get; set; }

    public string Plate { get; set; }

    public double KmPerLiter { get; set; }
}
