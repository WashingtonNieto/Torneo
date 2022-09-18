using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torneo.App.Dominio;
using Torneo.App.Persistencia;


namespace Torneo.App.Frontend.Pages.DirectoresTecnicos
{
  public class IndexModel : PageModel
  {
    private readonly IRepositorioDT _repoDT;
    public IEnumerable<DirectorTecnico> dt { get; set; }
    public IndexModel(IRepositorioDT repoDT)
    {
      _repoDT = repoDT;
    }

    public void OnGet()
    {
      dt = _repoDT.GetAllDTs();
    }


  }
}
