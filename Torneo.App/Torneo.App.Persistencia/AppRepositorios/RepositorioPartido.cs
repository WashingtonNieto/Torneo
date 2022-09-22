using Microsoft.EntityFrameworkCore;
using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
  public class RepositorioPartido : IRepositorioPartido
  {
    private readonly DataContext _dataContext = new DataContext();

    public Partido AddPartido(Partido partido, int idEquipoLocal, int marcadorLocal, int idEquipoVisitante, int marcadorVisitante)
    {
      var equipoLocalEncontrado = _dataContext.Equipos.Find(idEquipoLocal);
      var equipoVisitanteEncontrado = _dataContext.Equipos.Find(idEquipoVisitante);
      partido.Local = equipoLocalEncontrado;
      partido.MarcadorLocal = marcadorLocal;
      partido.Visitante = equipoVisitanteEncontrado;
      partido.MarcadorVisitante = marcadorVisitante;
      var partidoInsertado = _dataContext.Partidos.Add(partido);
      _dataContext.SaveChanges();
      return partidoInsertado.Entity;
    }

    public IEnumerable<Partido> GetAllPartidos()
    {
      var partido = _dataContext.Partidos
      .Include(e => e.Local)
      .Include(e => e.Visitante)
      .ToList();
      return partido;
    }

    public Partido GetPartido(int idPartido)
    {
      var partidoEncontrado = _dataContext.Partidos
      .Where(e => e.Id == idPartido)
      .Include(e => e.Local)
      .Include(e => e.Visitante)
      .FirstOrDefault();
      return partidoEncontrado;
    }

    public Partido UpdatePartido(Partido partido, DateTime FechaHora, int idEquipoLocal, int MarcadorLocal, int idEquipoVisitante, int MarcadorVisitante)
    {
      var partidoEncontrado = GetPartido(partido.Id);
      var equipoLocalEncontrado = _dataContext.Equipos.Find(idEquipoLocal);
      var equipoVisitanteEncontrado = _dataContext.Equipos.Find(idEquipoVisitante);
      partidoEncontrado.FechaHora = partido.FechaHora;
      partidoEncontrado.Local = equipoLocalEncontrado;
      partidoEncontrado.MarcadorLocal = partido.MarcadorLocal;
      partidoEncontrado.Visitante = equipoVisitanteEncontrado;
      partidoEncontrado.MarcadorVisitante = partido.MarcadorVisitante;
      _dataContext.SaveChanges();
      return partidoEncontrado;
    }



  }
}