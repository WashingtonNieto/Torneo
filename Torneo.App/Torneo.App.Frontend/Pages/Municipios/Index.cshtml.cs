using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torneo.App.Persistencia;
using Torneo.App.Dominio;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Torneo.App.Frontend.Pages.Municipios
{
  public class IndexModel : PageModel
  {

    private readonly IRepositorioMunicipio _repoMunicipio;
    public IEnumerable<Municipio> municipios { get; set; }
    public int MunicipioSelected { get; set; }
    public SelectList MunicipioOptions { get; set; }
    public string BusquedaActual { get; set; }
    public bool ErrorEliminar { get; set; }

    public IndexModel(IRepositorioMunicipio repoMunicipio)
    {
      _repoMunicipio = repoMunicipio;
    }
    public void OnGet()
    {
      MunicipioOptions = new SelectList(_repoMunicipio.GetAllMunicipios(), "Id", "Nombre");
      municipios = _repoMunicipio.GetAllMunicipios();
      MunicipioSelected = -1;
      BusquedaActual = "";
      ErrorEliminar = false;


      //super codigo para mostrar en consola un resultado!!!
      // foreach (var municipio in municipios)
      // {
      //   Console.WriteLine(municipio.Nombre);
      //   foreach (var equipo in municipio.Equipos)
      //   {
      //     Console.WriteLine("\t" + equipo.Nombre);
      //   }
      // }
    }



    public IActionResult OnPostDelete(int id)
    {
      try
      {
        _repoMunicipio.DeleteMunicipio(id);
        municipios = _repoMunicipio.GetAllMunicipios();
        return Page();
      }
      catch (Exception ex)
      {
        municipios = _repoMunicipio.GetAllMunicipios();
        ErrorEliminar = true;
        return Page();

      }
    }

    public void OnPostBuscar(string nombre)
    {
      MunicipioOptions = new SelectList(_repoMunicipio.GetAllMunicipios(), "Id", "Nombre");
      MunicipioSelected = -1;
      if (string.IsNullOrEmpty(nombre))
      {
        BusquedaActual = "";
        municipios = _repoMunicipio.GetAllMunicipios();
      }
      else
      {
        BusquedaActual = nombre;
        municipios = _repoMunicipio.SearchMunicipios(nombre);
      }
    }

  }
}
