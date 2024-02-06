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


    [Required(AllowEmptyStrings = false, ErrorMessage = "Necessário nome do carrro")]
    public string Name { get; set; }
    [Column(TypeName ="char")]
    [StringLength(7, ErrorMessage = "Obrigatorio inserir dados da placa")]
    public string Plate { get; set; }

    [Range(1, double.MaxValue)]
    public double KmPerLiter { get; set; }
    
    public string UserId { get; set; }
    public  User User { get; set; }
    public virtual ICollection<Fuel>? Fuel { get; set; }
}