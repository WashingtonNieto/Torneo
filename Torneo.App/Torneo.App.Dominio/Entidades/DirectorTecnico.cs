using System.ComponentModel.DataAnnotations;

namespace Torneo.App.Dominio
{
  public class DirectorTecnico
  {
    public int Id { get; set; }
    [Display(Name = "Nombre del Director Tecnico")]
    [Required(ErrorMessage = "El nombre del D.T. es obligatorio")]
    public string Nombre { get; set; }
    [Display(Name = "Documento del Director Tecnico")]
    [Required(ErrorMessage = "El documento es obligatorio")]
    public string Documento { get; set; }
    [Display(Name = "Telefono del Director Tecnico")]
    [Required(ErrorMessage = "El telefono es obligatorio")]
    public string Telefono { get; set; }
  }
}
