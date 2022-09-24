using System.ComponentModel.DataAnnotations;

namespace Torneo.App.Dominio
{
  public class Equipo
  {
    public int Id { get; set; }
    [Display(Name = "Nombre del Equipo")]
    [Required(ErrorMessage = "El nombre del equipo es obligatorio")]
    public string Nombre { get; set; }
    [Display(Name = "Nombre del Municipio al cual pertenece el equipo")]
    [Required(ErrorMessage = "El nombre del municipio es obligatorio")]
    public Municipio Municipio { get; set; }
    [Display(Name = "Nombre del Director Tecnico")]
    [Required(ErrorMessage = "El nombre del D.T. es obligatorio")]
    public DirectorTecnico DirectorTecnico { get; set; }

    //public Jugador Jugador { get; set; }
    //public List<Partido> Partidos { get; set; }
    public List<Jugador> Jugadores { get; set; }
    //public List<DirectorTecnico> DirectoresTecnicos { get; set; }

  }
}
