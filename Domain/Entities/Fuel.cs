﻿
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Fuel : BaseEntity
{
    private static int nextIdFuel = 0;
    public int IdFuel { get; }
    public Fuel()
    {
        IdFuel = nextIdFuel;
        nextIdFuel++;
    }

    [Required]
    [Range(1, 50)]
    public double QuantityOfLiters { get; set; }

    [Required]
    [Range(1, 2, ErrorMessage = "0-Gasol, 1-Etanol")]
    public TypFuelEnum typeFuel { get; set; }


    [Range(1, double.MaxValue)]
    public double ValuePerLiter { get; set; }
    [RegularExpression(@"^(nome|int)$")]
    public string SupplyDate { get; set; } 

    public Guid departureLocationId { get; set; }
    public  DepartureLocation departureLocation { get; set; }
    
    public Guid destinationId { get; set; }
    public  Destination destination { get; set; }
    

}
