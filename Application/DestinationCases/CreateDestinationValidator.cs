using Application.DestinationCases.Command;
using FluentValidation;

namespace Application.DestinationCases;

public sealed class CreateDestinationValidator : AbstractValidator<CreateDestinationRequest>
{
    public CreateDestinationValidator()
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