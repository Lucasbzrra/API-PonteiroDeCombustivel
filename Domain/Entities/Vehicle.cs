using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Vehicle:BaseEntity
{
  
    [Required(AllowEmptyStrings = false, ErrorMessage = "Necessário nome do carrro")]
    public string Name { get; set; }
    [Column(TypeName ="char")]
    [StringLength(7, ErrorMessage = "Obrigatorio inserir dados da placa")]
    public string Plate { get; set; }

    [Range(1, double.MaxValue)]
    public double KmPerLiter { get; set; }

    public virtual ICollection<Fuel>? Fuel { get; set; }
}