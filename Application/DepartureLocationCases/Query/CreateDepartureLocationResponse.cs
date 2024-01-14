namespace Application.DepartureLocationCases.Query;

public class CreateDepartureLocationResponse
{
    public string City { get; set; }
    public string UF { get; set; }
    public string Country { get; set; }

    public string Cep { get; set; }
    public string? ReferencePoint { get; set; }

}