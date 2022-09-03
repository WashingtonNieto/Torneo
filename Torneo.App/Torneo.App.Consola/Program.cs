using Torneo.App.Dominio;
using Torneo.App.Persistencia;

//actualizacion
//mdoificacion Washington Nieto 
namespace Torneo.App.Consola
{
    class Program
    {
        private static IRepositorioMunicipio _repoMunicipio = new RepositorioMunicipio();
        private static IRepositorioDT _repoDT = new RepositorioDT();
        private static IRepositorioEquipo _repoEquipo = new RepositorioEquipo();
        private static IRepositorioPosicion _repoPosicion = new RepositorioPosicion();
        private static IRepositorioJugador _repoJugador = new RepositorioJugador();
        private static IRepositorioPartido _repoPartido = new RepositorioPartido();

        static void Main(string[] args) 
        {
            int opcion = 0;
            do{
                Console.WriteLine("--------------------------");
                Console.WriteLine("-----------MENU-----------");
                Console.WriteLine("--------------------------");
                Console.WriteLine("1 Insert Municipio");
                Console.WriteLine("2 Mostrar Municipios");
                Console.WriteLine("----------------------");
                Console.WriteLine("3 Insert Director Tecnico");
                Console.WriteLine("4 Mostrar Director Tecnico");
                Console.WriteLine("----------------------");
                Console.WriteLine("5 Insert Equipo");
                Console.WriteLine("6 Mostar Equipo");
                Console.WriteLine("----------------------");
                Console.WriteLine("7 Insert Jugador");
                Console.WriteLine("8 Mostar Jugador");
                Console.WriteLine("----------------------");
                Console.WriteLine("9 Insert Posicion");
                Console.WriteLine("10 Mostar Posicion");
                Console.WriteLine("----------------------");
                Console.WriteLine("11 Insert Partidos");
                Console.WriteLine("12 Mostar Partidos");
                Console.WriteLine("----------------------");
                Console.WriteLine("0 Salir");
                Console.WriteLine("Seleccione la opción correcta");
                opcion = Int32.Parse(Console.ReadLine());
                switch(opcion)
                {
                    case 1:
                        AddMunicipio();
                        break;
                    case 2:
                        GetAllMunicipios();
                        break;
                    case 3:
                        AddDT();
                        break;
                    case 4:
                        GetAllDTs();
                        break;
                    case 5:
                        AddEquipo();
                        break;
                    case 6:
                        GetAllEquipos();
                        break;
                    case 7:
                        AddJugador();
                        break;
                    case 8:
                        GetAllJugadores();
                        break;
                    case 9:
                        AddPosicion();
                        break;
                    case 10:
                        GetAllPosiciones();
                        break;
                    case 11:
                        AddPartido();
                        break;
                    case 12:
                        GetAllPartidos();
                        break;
                }
            }while(opcion != 0);
        }

        private static void AddMunicipio()
        {
            Console.WriteLine("Ingrese el nombre del municipio");
            string nombre = Console.ReadLine();
            var municipio = new Municipio 
            { 
                Nombre = nombre, 
            };
            //para mostrar por consola el resultado de la consulta
            //Console.WriteLine(_repoMunicipio.AddMunicipio(municipio));
            _repoMunicipio.AddMunicipio(municipio);
        }
        private static void AddDT()
        {
            Console.WriteLine("Ingrese el nombre del director tecnico");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el documento del director tecnico");
            string documento = Console.ReadLine();
            Console.WriteLine("Ingrese el telefono del director tecnico");
            string telefono = Console.ReadLine();
            var directorTecnico = new DirectorTecnico 
            { 
                Nombre = nombre, 
                Documento = documento, 
                Telefono = telefono, 
            };
            _repoDT.AddDT(directorTecnico);
        }
        private static void AddEquipo()
        {
            Console.WriteLine("Ingrese el nombre del equipo");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el id del municipio");
            int idMunicipio = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el id del director tecnico");
            int idDT = Int32.Parse(Console.ReadLine());

            var equipo = new Equipo 
            { 
                Nombre = nombre, 
            };
            _repoEquipo.AddEquipo(equipo, idMunicipio, idDT);
        }

        private static void AddPosicion()
        {
            Console.WriteLine("Ingrese el nombre de la posicion");
            string nombre = Console.ReadLine();
            var posicion = new Posicion 
            { 
                Nombre = nombre, 
            };
            //para mostrar por consola el resultado de la consulta
            //Console.WriteLine(_repoMunicipio.AddMunicipio(municipio));
            _repoPosicion.AddPosicion(posicion);
        }


        private static void AddJugador()
        {
            Console.WriteLine("Ingrese el nombre del jugador");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el numero del jugador");
            int numero = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el equipo del jugador");
            int idEquipo = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la posicion del jugador");
            int idPosicion = Int32.Parse(Console.ReadLine());

            var jugador = new Jugador 
            { 
                Nombre = nombre, 
            };
            _repoJugador.AddJugador(jugador, numero, idEquipo, idPosicion);
        }

        private static void AddPartido()
        {
            Console.WriteLine("Ingrese fecha del partido");
            DateTime fecha = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el id del equipo local");
            int idEquipoLocal = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el marcador del equipo local");
            int marcadorLocal = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el id del equipo visitante");
            int idEquipoVisitante = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el marcador del equipo visitante");
            int marcadorVisitante = Int32.Parse(Console.ReadLine());

            var partido = new Partido 
            { 
                FechaHora = fecha, 
            };
            _repoPartido.AddPartido(partido, fecha, idEquipoLocal, marcadorLocal, idEquipoVisitante, marcadorVisitante);
        }

        private static void GetAllMunicipios()
        {
            foreach(var municipio in _repoMunicipio.GetAllMunicipios())
            {
                Console.WriteLine(municipio.Id + " " + municipio.Nombre);
            }
        }
        private static void GetAllDTs()
        {
            foreach(var directorTecnico in _repoDT.GetAllDTs())
            {
                Console.WriteLine(directorTecnico.Id + " " + directorTecnico.Nombre);
            }
        }

        private static void GetAllEquipos()
        {
            foreach(var equipo in _repoEquipo.GetAllEquipos())
            {
                Console.WriteLine(equipo.Nombre + " "
                + equipo.Municipio.Nombre + " " + equipo.DirectorTecnico.Nombre);
            }
        }        

        private static void GetAllPosiciones()
        {
            foreach(var posicion in _repoPosicion.GetAllPosiciones())
            {
                Console.WriteLine(posicion.Id + " " + posicion.Nombre);
            }
        }
        
        private static void GetAllJugadores()
        {
            foreach(var jugador in _repoJugador.GetAllJugadores())
            {
                Console.WriteLine(jugador.Nombre + " "
                + jugador.Equipo.Nombre + " " + jugador.Posicion.Nombre);
            }
        }

        
        private static void GetAllPartidos()
        {
            foreach(var partido in _repoPartido.GetAllPartidos())
            {
                Console.WriteLine(partido.FechaHora + " "
                + partido.Local.Nombre + " " + partido.MarcadorLocal + " " + partido.Visitante.Nombre + " " + partido.MarcadorVisitante);
            }
        }        

    }
}
