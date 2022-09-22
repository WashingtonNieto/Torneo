using Microsoft.EntityFrameworkCore;
using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
  public class RepositorioDT : IRepositorioDT
  {
    private readonly DataContext _dataContext = new DataContext();
    public DirectorTecnico AddDT(DirectorTecnico directorTecnico)
    {
      var dtInsertado = _dataContext.DirectoresTecnicos.Add(directorTecnico);
      _dataContext.SaveChanges();
      return dtInsertado.Entity;
    }

    public IEnumerable<DirectorTecnico> GetAllDTs()
    {
      var dt = _dataContext.DirectoresTecnicos
      .Include(m => m.Equipos)
      .ToList();

      return dt;
    }

    public DirectorTecnico GetDT(int idDT)
    {
      var dtEncontrado = _dataContext.DirectoresTecnicos.Find(idDT);
      return dtEncontrado;
    }

    public DirectorTecnico UpdateDT(DirectorTecnico dt)
    {
      var dtEncontrado = _dataContext.DirectoresTecnicos.Find(dt.Id);
      if (dtEncontrado != null)
      {
        dtEncontrado.Nombre = dt.Nombre;
        dtEncontrado.Documento = dt.Documento;
        dtEncontrado.Telefono = dt.Telefono;
        _dataContext.SaveChanges();
      }
      return dtEncontrado;
    }

    public DirectorTecnico DeleteDirectorTecnico(int idDT)
    {
      var dtEncontrado = _dataContext.DirectoresTecnicos.Find(idDT);
      if (dtEncontrado != null)
      {
        _dataContext.DirectoresTecnicos.Remove(dtEncontrado);
        _dataContext.SaveChanges();
      }
      return dtEncontrado;
    }

  }
}