using Torneo.App.Dominio;

namespace Torneo.App.Persistencia
{
    public interface IRepositorioPartido
    {
        public Partido AddPartido(Partido partido, DateTime FechaHora, int idEquipoLocal, int marcadorLocal, int idEquipoVisitante, int marcadorVisitante);
        public IEnumerable<Partido> GetAllPartidos();
        public Partido GetPartido (int idPartido);
        public Partido UpdatePartido(Partido partido, DateTime FechaHora, int idEquipoLocal, int MarcadorLocal, int idEquipoVisitante, int MarcadorVisitante);
    }
}