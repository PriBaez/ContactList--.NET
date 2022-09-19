using System.ComponentModel.DataAnnotations;

namespace MVC_Project.Models;

public class Contactos
{
    public int IdContacto { get; set; }
    [Required(ErrorMessage ="Debes introducir tu nombre para continuar.")]
    public string? Nombre { get; set; }
    [Required(ErrorMessage ="Debes introducir tu telefono para continuar.")]
    public string? Telefono { get; set; }
    [Required(ErrorMessage ="Debes introducir tu correo para continuar.")]
    public string? Correo { get; set; }
}
