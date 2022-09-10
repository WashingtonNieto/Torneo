using Microsoft.EntityFrameworkCore;
using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
  public class RepositorioJugador : IRepositorioJugador
  {
    private readonly DataContext _dataContext = new DataContext();

    public Jugador AddJugador(Jugador jugador, int numero, int idEquipo, int idPosicion)
    {
      var equipoEncontrado = _dataContext.Equipos.Find(idEquipo);
      var posicionEncontrado = _dataContext.Posiciones.Find(idPosicion);
      jugador.Equipo = equipoEncontrado;
      jugador.Posicion = posicionEncontrado;
      var jugadorInsertado = _dataContext.Jugadores.Add(jugador);
      _dataContext.SaveChanges();
      return jugadorInsertado.Entity;
    }

    public IEnumerable<Jugador> GetAllJugadores()
    {
      var jugador = _dataContext.Jugadores
      .Include(e => e.Equipo)
      .Include(e => e.Posicion)
      .ToList();
      return jugador;
    }

    public Jugador GetJugador(int idJugador)
    {
      var jugadorEncontrado = _dataContext.Jugadores.Find(idJugador);
      return jugadorEncontrado;
    }
  }
}