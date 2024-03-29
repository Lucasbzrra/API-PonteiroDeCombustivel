﻿using Application.VehicleCases.CreateVehicle.Queries;
using MediatR;


namespace Application.VehicleCases.CreateVehicle.Command;

public sealed record UpdateVehicleReques( Guid id, string ? name , string plate, double? KmPerLiter) :IRequest<UpdateVehicleResponse>;
