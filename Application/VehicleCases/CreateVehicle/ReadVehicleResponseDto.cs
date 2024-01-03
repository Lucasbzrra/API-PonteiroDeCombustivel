using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.VehicleCases.CreateVehicle;

public sealed record ReadVehicleResponseDto
{

    public string Name { get; set; }

    public string Plate { get; set; }

    public double KmPerLiter { get; set; }

    public ICollection<Fuel>? Fuel { get; set; }

}
