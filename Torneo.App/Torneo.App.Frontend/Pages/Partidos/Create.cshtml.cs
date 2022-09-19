using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torneo.App.Dominio;
using Torneo.App.Persistencia;

namespace Torneo.App.Frontend.Pages.Partidos
{
  public class CreateModel : PageModel
  {
    private readonly IRepositorioPartido _repoPartido;
    private readonly IRepositorioEquipo _repoEquipo;

    public Partido partido { get; set; }
    public IEnumerable<Equipo> equipos { get; set; }

    public CreateModel(
      IRepositorioPartido repoPartido,
      IRepositorioEquipo repoEquipo)

    {
      _repoPartido = repoPartido;
      _repoEquipo = repoEquipo;
    }

    public void OnGet()
    {
      partido = new Partido();
      equipos = _repoEquipo.GetAllEquipos();
    }

    public IActionResult OnPost(Partido partido, DateTime FechaHora, int idEquipoLocal, int marcadorLocal, int idEquipoVisitante, int marcadorVisitante)
    {
      partido = new Partido();
      equipos = _repoEquipo.GetAllEquipos();
      _repoPartido.AddPartido(partido, FechaHora, idEquipoLocal, marcadorLocal, idEquipoVisitante, marcadorVisitante);
      return RedirectToPage("Index");
    }
  }
}