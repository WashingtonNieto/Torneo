using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torneo.App.Dominio;
using Torneo.App.Persistencia;

namespace Torneo.App.Frontend.Pages.Partidos
{
    public class CreateModel : PageModel
    {
        private readonly IRepositorioPartido _repPartodp;
        private readonly IRepositorioEquipo _repoEquipo;

        public Partido partido {get; set;}
        public IEnumerable<Equipo> equipos { get; set; }

        public CreateModel(IRepositorioPartido repoPartido, IRepositorioEquipo repoEquipo)

        {
            _repoPartido = repoPartido;
            _repoEquipo = repoMunicipio;
        }

        public void OnGet()
        {
            partido = new Partido();
            equipos = _repoEquipo.GetAllEquipos();
        }
    }
}
