using Application.VehicleCases.CreateVehicle.Query;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.VehicleCases.CreateVehicle.Command;

public sealed record DeleteVehicleRequest(Guid Id) : IRequest<DeleteVehicleResponse>;
