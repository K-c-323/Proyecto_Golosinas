using System.ComponentModel.DataAnnotations;

namespace Modelos;

public class Producto
{
    [Required(ErrorMessage = "El campo codigo es obligatorio")]
    public string Codigo { get; set; }
    [Required(ErrorMessage = "El campo descripcion es obligatorio")]
    public string Descripcion { get; set; }
    public string Precio { get; set; }
    public string Existencia { get; set; }
    
}
