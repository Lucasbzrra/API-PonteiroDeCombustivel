using Application.DepartureLocationCases.Command;
using Application.DestinationCases.Command;
using Domain.Entities;
using Domain.EntitiesExternal;
using Domain.Interfaces;

namespace Application;
public class ConcreteFactory : ILocalFactory
{
    public Object CreateObject(Finaly finaly, string? TypeObject, Guid idFuel, Guid  ? idlocal )
    {
        if (TypeObject is null) { TypeObject = "Departure"; }
        switch (TypeObject)
        {
            case "Departure":


                CreateDepartureLocationRequest createDeparture = new CreateDepartureLocationRequest
                (
                Country: finaly.results[0].components.country,
                Cep: finaly.results[0].components.postcode,
                City: finaly.results[0].components.city,
                UF: finaly.results[0].components.country_code,
                ReferencePoint: finaly.results[0].components.continent + finaly.results[0].components.state,
                lat: finaly.results[0].geometry.lat.ToString(),
                lng: finaly.results[0].geometry.lng.ToString(),
                FuelId: idFuel
                 );
                return createDeparture;
            case "Destination":
                CreateDestinationRequest createDestinationRequest = new CreateDestinationRequest
                (
                Country: finaly.results[0].components.country,
                Cep: finaly.results[0].components.postcode,
                City: finaly.results[0].components.city,
                UF: finaly.results[0].components.country_code,
                ReferencePoint: finaly.results[0].components.continent + finaly.results[0].components.state,
                lat: finaly.results[0].geometry.lat.ToString(),
                lng: finaly.results[0].geometry.lng.ToString(),
                FuelId: idFuel
                );
                return createDestinationRequest;
            case "UpdateDeparture":
                UpdateDepartureLocationRequest update = new UpdateDepartureLocationRequest
                (
                Country: finaly.results[0].components.country,
                Cep: finaly.results[0].components.postcode,
                City: finaly.results[0].components.city,
                UF: finaly.results[0].components.country_code,
                ReferencePoint: finaly.results[0].components.continent + finaly.results[0].components.state,
                lat: finaly.results[0].geometry.lat.ToString(),
                lng: finaly.results[0].geometry.lng.ToString(),
                FuelIdd: idFuel,
                idDepartureLocation: idlocal.Value
                ) ;
                return update;
            case "UpdateDestination":
                UpdateDestinationRequest Destination = new UpdateDestinationRequest
                (
                Country: finaly.results[0].components.country,
                Cep: finaly.results[0].components.postcode,
                City: finaly.results[0].components.city,
                UF: finaly.results[0].components.country_code,
                ReferencePoint: finaly.results[0].components.continent + finaly.results[0].components.state,
                lat: finaly.results[0].geometry.lat.ToString(),
                lng: finaly.results[0].geometry.lng.ToString(),
                FuelId: idFuel,
                idDestination: idlocal.Value
                );
                return Destination;
            default:
                throw new ArgumentException("Não existe este objeto na nossa base de dados");
        }

    }
}
