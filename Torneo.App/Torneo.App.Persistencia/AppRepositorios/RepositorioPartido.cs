using Microsoft.EntityFrameworkCore;
using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public class RepositorioPartido : IRepositorioPartido
    {
        private readonly DataContext _dataContext = new DataContext();
        
        public Partido AddPartido(Partido partido, DateTime fechaHora, int idEquipoLocal, int marcadorLocal, int idEquipoVisitante, int marcadorVisitante)
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


    
    }
}