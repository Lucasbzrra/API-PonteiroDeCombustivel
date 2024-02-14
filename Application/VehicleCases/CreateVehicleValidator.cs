using Application.VehicleCases.CreateVehicle.Command;
using FluentValidation;


namespace Application.VehicleCases;

public sealed class CreateVehcileValidator : AbstractValidator<CreateVehicleRequest>
{
    public CreateVehcileValidator()
    {
        RuleFor(vehicle => vehicle.Name).NotEmpty();
        RuleFor(vehcile => vehcile.Plate).MinimumLength(7).NotEmpty().MaximumLength(7).WithMessage("Necessário inserir a placa do veiculo");
        RuleFor(vehicle => vehicle.KmPerLiter).InclusiveBetween(1, 30);
        RuleFor(vehicle => vehicle.UserId).NotEmpty();
    }
}
