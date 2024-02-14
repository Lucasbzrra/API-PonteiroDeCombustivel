using Application.DepartureLocationCases.Command;
using Application.DepartureLocationCases.Query;
using Application.DestinationCases.Command;
using Application.DestinationCases.Query;
using Application.FuelCases.Command;
using Application.FuelCases.Queries;
using Application.UserCases;
using Application.UserCases.Command;
using Application.UserCases.Query;
using Application.UserCases.UserAuthentication;
using Application.VehicleCases.CreateVehicle.Command;
using Application.VehicleCases.CreateVehicle.Queries;
using Application.VehicleCases.CreateVehicle.Query;
using AutoMapper;
using Domain.Entities;

namespace Application;

public sealed class Mappings : Profile
{
    public Mappings()
    {
        CreateMap<CreateVehicleRequest, Vehicle>();
        CreateMap<Vehicle, CreateVehicleResponse>();


        CreateMap<ReadVehicleRequest, Vehicle>();
        CreateMap<Vehicle, ReadVehicleResponse>();

        CreateMap<DeleteVehicleRequest, Vehicle>();
        CreateMap<Vehicle, DeleteVehicleResponse>();

        CreateMap<UpdateVehicleReques, Vehicle>();
        CreateMap<Vehicle, UpdateVehicleResponse>();

        CreateMap<FuelCreateRequest, Fuel>();
        CreateMap<Fuel, FuelCreateResponse>();

        CreateMap<FuelReadRequest, Fuel>();
        CreateMap<Fuel, FuelReadResponse>();

        CreateMap<FuelUpdateRequest, Fuel>()
        .ForMember(dest => dest.QuantityOfLiters, opt => opt.MapFrom(src => src.QuantityOfLiters))
        .ForMember(dest => dest.typeFuel, opt => opt.MapFrom(src => src.typeFuel))
        .ForMember(dest => dest.ValuePerLiter, opt => opt.MapFrom(src => src.ValuePerLiter))
        .ForMember(dest => dest.SupplyDate, opt => opt.MapFrom(src => src.SupplyDate));
        CreateMap<Fuel, FuelUpdateResponse>();

        CreateMap<FuelDeleteRequest, Fuel>();
        CreateMap<Fuel, FuelDeleteResponse>();


        CreateMap<CreateDestinationRequest, Destination>();
        CreateMap<Destination, CreateDestinationResponse>();

        CreateMap<ReadDestinationResquet, Destination>();
        CreateMap<Destination, ReadDestinationResponse>();

        CreateMap<DeletDestinationRequest, Destination>();
        CreateMap<Destination, DeletDestinationResponse>();

        CreateMap<UpdateDestinationRequest, Destination>();
        CreateMap<Destination, UpdateDestinationResponse>();


        CreateMap<CreateDepartureLocationRequest, DepartureLocation>();
        CreateMap<DepartureLocation, CreateDepartureLocationResponse>();

        CreateMap<ReadDepartureLocationRequest, DepartureLocation>();
        CreateMap<DepartureLocation, ReadDepartureLocationResponse>();

        CreateMap<DeleteDepartureLocationRequest, DepartureLocation>();
        CreateMap<DepartureLocation, DeleteDepartureLocationResponse>();

        CreateMap<UpdateDepartureLocationRequest, DepartureLocation>();
        CreateMap<DepartureLocation,UpdateDeparureLocationResponse>();

        CreateMap<CreateLoginRequest, User>();
        CreateMap<User, CreateLoginResponse>();

        CreateMap<ReadLoginRequest, User>();
        CreateMap<User, ReadLoginResponse>();

        CreateMap<UpdateLoginRequest, User>();
        CreateMap<User, UpdateLoginResponse>();

        CreateMap<DeleteLoginRequest, User>();
        CreateMap<User, DeleteLoginResponse>();



        CreateMap<LoginUserRequest, LoginUserResponse>();

    }
}
