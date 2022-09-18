using Microsoft.EntityFrameworkCore;
using Torneo.App.Dominio;

namespace Torneo.App.Persistencia
{
    public class RepositorioPartido : IRepositorioPartido
    {
        private readonly DataContext _dataContext = new DataContext();

        public Partido AddPartido(
            Partido partido,
            DateTime fechaHora,
            int idEquipoLocal,
            int marcadorLocal,
            int idEquipoVisitante,
            int marcadorVisitante
        )
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
            var partidos = _dataContext.Partidos
                .Include(e => e.Local)
                .Include(e => e.Visitante)
                .ToList();
            return partidos;
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

        public Partido UpdatePartido(Partido partido, DateTime fechaHora, int idEquipoLocal, int marcadorLocal, int idEquipoVisitante, int marcadorVisitante)       
         {
            var partidoEncontrado = GetPartido(partido.Id);
            var equipoLocalEncontrado = _dataContext.Equipos.Find(idEquipoLocal);
            var equipoVisitanteEncontrado = _dataContext.Equipos.Find(idEquipoVisitante);
            partidoEncontrado.Id = partido.Id;
            partidoEncontrado.Local = equipoLocalEncontrado;
            partidoEncontrado.Visitante = equipoVisitanteEncontrado;
            _dataContext.SaveChanges();
            return partidoEncontrado;
        }
    }
}
