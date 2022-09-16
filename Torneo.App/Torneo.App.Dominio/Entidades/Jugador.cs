using System.ComponentModel.DataAnnotations;

namespace Torneo.App.Dominio
{
  public class Jugador
  {
    public int Id { get; set; }
    [Display(Name = "Nombre del Jugador")]
    [Required(ErrorMessage = "El nombre del jugador es obligatorio")]
    public string Nombre { get; set; }
    
    [Display(Name = "Numero del Jugador")]
    [Required(ErrorMessage = "El numero del jugador es obligatorio")]
    public int Numero { get; set; }
    
    [Display(Name = "Equipo del Jugador")]
    [Required(ErrorMessage = "El nombre del equipo es obligatorio")]
    public Equipo Equipo { get; set; }
    
    [Display(Name = "Posicion del Jugador")]
    [Required(ErrorMessage = "La posicion del jugador es obligatorio")]
    public Posicion Posicion { get; set; }
  }
}
