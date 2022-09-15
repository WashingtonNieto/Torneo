using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torneo.App.Dominio;
using Torneo.App.Persistencia;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Torneo.App.Frontend.Pages.Equipos
{
  public class EditModel : PageModel
  {
    private readonly IRepositorioEquipo _repoEquipo;
    private readonly IRepositorioMunicipio _repoMunicipio;
    private readonly IRepositorioDT _repoDT;

    public EditModel(IRepositorioEquipo repoEquipo, IRepositorioMunicipio
    repoMunicipio, IRepositorioDT repoDT)
    {
      _repoEquipo = repoEquipo;
      _repoMunicipio = repoMunicipio;
      _repoDT = repoDT;
    }


    public void OnGet()
    {
    }
  }
}
