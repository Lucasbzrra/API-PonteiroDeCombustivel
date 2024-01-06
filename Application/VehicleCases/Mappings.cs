using Application.VehicleCases.CreateVehicle;
using AutoMapper;
using Domain.Entities;
using WebFuelPointer.Controllers;

namespace Application.VehicleCases;

public sealed class Mappings:Profile
{
    public Mappings()
    {
        //Create
        CreateMap<CreateVehicleRequestDto, Vehicle>();

        //Read
        CreateMap<ReadVehicleRequestDto, ReadVehicleResponseDto>();

        //Delete
        CreateMap<DeleteVehicleRequestDto, Vehicle>();
        CreateMap<Vehicle, DeleteVehicleResponseDto>();

    }
}
