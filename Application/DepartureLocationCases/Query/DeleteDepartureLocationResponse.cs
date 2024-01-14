namespace Application.DepartureLocationCases.Query;

public class DeleteDepartureLocationResponse
{
    public string City { get; set; }
    public string UF { get; set; }

    public string? ReferencePoint { get; set; }

    public int IdDepartureLocation { get; }
}