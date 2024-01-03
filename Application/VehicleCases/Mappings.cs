using Application.VehicleCases.CreateVehicle;
using AutoMapper;
using Domain.Entities;


namespace Application.VehicleCases;

public sealed class Mappings:Profile
{
    public Mappings()
    {
        //Create
        CreateMap<CreateVehicleRequestDto, Vehicle>();
        CreateMap<Vehicle, ReadVehicleResponseDto>();

        //Read
        CreateMap<Vehicle, ReadVehicleResponseDto>();

    }
}
