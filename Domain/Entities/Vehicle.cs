using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Vehicle:BaseEntity
{

    private static int nextIdFuel =1;
    public int IdVehicle { get; }
    public Vehicle()
    {
        IdVehicle = nextIdFuel;
        nextIdFuel++;
    }

    public string Name { get; set; }
    public string Plate { get; set; }

    public double KmPerLiter { get; set; }
    
    public string UserId { get; set; }
    public  User User { get; set; }
    public virtual ICollection<Fuel>? Fuel { get; set; }
}