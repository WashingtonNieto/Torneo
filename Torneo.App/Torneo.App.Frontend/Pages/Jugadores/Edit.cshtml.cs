using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torneo.App.Dominio;
using Torneo.App.Persistencia;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Torneo.App.Frontend.Pages.Jugadores
{
    public class EditModel : PageModel
    {
        private readonly IRepositorioJugador _repoJugador;
        private readonly IRepositorioEquipo _repoEquipo;
        private readonly IRepositorioPosicion _repoPosicionT;

        public Jugador jugador { get; set; }
        public SelectList EquipoOptions { get; set; }
        public SelectList PosicionOptions { get; set; }

        public EditModel(
            IRepositorioJugador repoJugador,
            IRepositorioEquipo repoEquipo,
            IRepositorioPosicion repoPosicionT
        )
        {
            _repoJugador = repoJugador;
            _repoEquipo = repoEquipo;
            _repoPosicionT = repoPosicionT;
        }

/*        public IActionResult OnGet(int id)
        {
            jugador = _repoJugador.GetJugador(id);
            EquipoOptions = new SelectList(_repoEquipo.GetAllEquipos(), "Id", "Nombre");
            EquipoSelected = jugador.Equipo.Id;
            PosicionOptions = new SelectList(_repoDT.GetAllDTs(), "Id", "Nombre");
            PosicionSelected = equipo.Municipio.Id;
            DTSelected = equipo.DirectorTecnico.Id;
            if (equipo == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }
        */
    }
}
