using Torneo.App.Dominio;

namespace Torneo.App.Persistencia
{
    public interface IRepositorioDT
    {
        public DirectorTecnico AddDT(DirectorTecnico directorTecnico);
        public IEnumerable<DirectorTecnico> GetAllDTs();
        public DirectorTecnico GetDT(int idDT);
        public DirectorTecnico UpdateDT(DirectorTecnico dt);
        public DirectorTecnico DeleteDirectorTecnico(int idDT);
        public IEnumerable<DirectorTecnico> SearchDts(string nombre);
    }
}
