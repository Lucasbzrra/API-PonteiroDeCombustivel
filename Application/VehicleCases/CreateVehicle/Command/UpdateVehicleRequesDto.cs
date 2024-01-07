using Application.VehicleCases.CreateVehicle.Queries;
using MediatR;


namespace Application.VehicleCases.CreateVehicle.Command;

public sealed record UpdateVehicleRequesDto( string ? name , string plate, double? KmPerLiter) :IRequest<UpdateVehicleResponseDto>;
