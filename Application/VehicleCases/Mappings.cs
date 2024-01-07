using Application.VehicleCases.CreateVehicle.Command;
using Application.VehicleCases.CreateVehicle.Queries;
using Application.VehicleCases.CreateVehicle.Query;
using AutoMapper;
using Domain.Entities;

namespace Application.VehicleCases;

public sealed class Mappings:Profile
{
    public Mappings()
    {
        //Create
        CreateMap<CreateVehicleRequestDto, Vehicle>();
        CreateMap<Vehicle, CreateVehicleResponseDto>();

        //Read
        CreateMap<ReadVehicleRequestDto, Vehicle>();
        CreateMap<Vehicle, ReadVehicleResponseDto>();

        //Delete
        CreateMap<DeleteVehicleRequestDto, Vehicle>();
        CreateMap<Vehicle, DeleteVehicleResponseDto>();

        //Update
        CreateMap<UpdateVehicleRequesDto, Vehicle>();
        CreateMap<Vehicle, UpdateVehicleResponseDto>();
    }
}
