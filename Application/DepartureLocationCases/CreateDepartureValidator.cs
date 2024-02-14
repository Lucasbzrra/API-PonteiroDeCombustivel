using Application.DepartureLocationCases.Command;
using FluentValidation;


namespace Application.DepartureLocationCases;

public sealed class CreateDepartureValidator : AbstractValidator<CreateDepartureLocationRequest>
{
    public CreateDepartureValidator()
    {
        RuleFor(destination => destination.Cep).NotEmpty();
        RuleFor(destination => destination.City).NotEmpty();
        RuleFor(destination => destination.Country).NotEmpty();
        RuleFor(destination => destination.lng).NotEmpty();
        RuleFor(destination => destination.lat).NotEmpty();
        RuleFor(destination => destination.ReferencePoint).NotEmpty();
        RuleFor(destination => destination.FuelId).NotEmpty();
    }
}
