using Torneo.App.Dominio;

namespace Torneo.App.Persistencia
{
    public interface IRepositorioPartido
    {
        public Partido AddPartido(Partido partido, DateTime fechaHora, int idEquipoLocal, int marcadorLocal, int idEquipoVisitante, int marcadorVisitante);



    }
}
