using Domain.Entities;
using MediatR;

namespace Application.VehicleCases.CreateVehicle.Query;

public sealed record ReadVehicleResponseDto
{


    public string Name { get; set; }

    public string Plate { get; set; }

    public double KmPerLiter { get; set; }


}