using System.ComponentModel.DataAnnotations;

namespace Torneo.App.Dominio
{
  public class Partido
  {
    public int Id { get; set; }
    [Display(Name = "Fecha y hora del Partido")]
    public DateTime FechaHora { get; set; }
    [Display(Name = "Nombre del equipo local")]
    [Required(ErrorMessage = "El nombre del equipo es obligatorio")]
    public Equipo Local { get; set; }
    [Display(Name = "Marcador del equipo local")]
    public int MarcadorLocal { get; set; }
    [Display(Name = "Nombre del equipo visitante")]
    [Required(ErrorMessage = "El nombre del equipo es obligatorio")]
    public Equipo Visitante { get; set; }
    [Display(Name = "Marcador del equipo visitante")]
    public int MarcadorVisitante { get; set; }
  }
}
