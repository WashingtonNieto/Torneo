using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torneo.App.Persistencia;
using Torneo.App.Dominio;

namespace Torneo.App.Frontend.Pages.DirectoresTecnicos
{
  public class IndexModel : PageModel
  {
    private readonly IRepositorioDT _repoDT;
    public IEnumerable<DirectorTecnico> directoresTecnicos { get; set; }
    public IndexModel(IRepositorioDT repoDT)
    {
      _repoDT = repoDT;
    }
    public void OnGet()
    {
      directoresTecnicos = _repoDT.GetAllDT();
    }
  }
}