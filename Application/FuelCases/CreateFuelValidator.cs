using Application.FuelCases.Command;
using FluentValidation;


namespace Application.FuelCases;

public sealed class CreateFuelValidator : AbstractValidator<FuelCreateRequest>
{
    public CreateFuelValidator()
    {
        RuleFor(fuel => fuel.typeFuel).InclusiveBetween(0, 1);
        RuleFor(fuel => fuel.QuantityOfLiters).InclusiveBetween(1, 70);
        RuleFor(fuel => fuel.ValuePerLiter).InclusiveBetween(1, 10);
        RuleFor(fuel => fuel.VehicleID).NotEmpty();

    }
}
