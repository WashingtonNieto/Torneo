using System.ComponentModel.DataAnnotations;

namespace Torneo.App.Dominio
{
  public class Posicion
  {
    public int Id { get; set; }

    [Display(Name = "Nombre de la Posición")]
    [Required(ErrorMessage = "El nombre es obligatorio")]
    public string Nombre { get; set; }
    public List<Jugador> Jugadores { get; set; }
  }
}
