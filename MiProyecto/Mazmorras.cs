using Monstruos;
using Protagonista;
using Funciones;
using System.Text.Json;

namespace Mazmorras
{
    public class Mazmorra
    {
        private string nombre;
        private List<Monstruo> monstruos;
        private Monstruo jefe;

        public string Nombre { get => nombre; set => nombre = value; }
        public List<Monstruo> Monstruos { get => monstruos; set => monstruos = value; }
        public Monstruo Jefe { get => jefe; set => jefe = value; }

        public Mazmorra(string Nombre, List<Monstruo> Monstruos, Monstruo Jefe)
        {

            this.Nombre = Nombre;
            this.Monstruos = Monstruos;
            this.Jefe = Jefe;

        }

        public static async Task<Root> NombreMazmorraAsync()
        {
            Random random = new Random();
            string numero = Convert.ToString(random.Next(1, 61));
            var url = $"https://swapi.dev/api/planets/{numero}/?format=json";
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Root root = JsonSerializer.Deserialize<Root>(responseBody);
                return root;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Problemas de acceso a la API");
                Console.WriteLine("Message :{0} ", e.Message);
                return new Root() { name = "Mazmorra" };
            }

        }

        public bool IniciarMazmorra(Personaje personaje)
        {
            Console.Clear();
            Console.WriteLine($"¡Bienvenido a la mazmorra {Nombre}!");
            FuncionesMazmorra.EfectoMazmorra();
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();

            foreach (var monstruo in Monstruos)
            {
                Console.Clear();
                
                if (!Combate(personaje, monstruo))
                {
                    foreach (var item in Monstruos)
                    {
                        item.Salud = 100;
                    }
                    return false;
                }
                FuncionesPartida.LimpiarBuffer();
                Console.WriteLine($"Salud luego del combate: {personaje.Estadisticas.Salud}");
                Console.WriteLine("Presione una tecla para el siguiente combate...");
                Console.ReadKey();


            }
            Console.Clear();
            Console.WriteLine("LLEGASTE A LA SALA DEL JEFE");
            Console.WriteLine("RECOMPENSA: SALUD AL 100%");
            Console.WriteLine("Presione una tecla para pelear con el jefe...");
            Console.ReadKey();
            personaje.Estadisticas.Salud100(); // salud al 100%
            if (!Combate(personaje, Jefe))
            {
                foreach (var item in Monstruos)
                {
                    item.Salud = 100;
                }
                Jefe.Salud = 100;
                return false;
            }
            Console.WriteLine($"Superaste la mazmorra {Nombre}, FELICITACIONES!!!");
            return true;
        }

        public static bool Combate(Personaje jugador, Monstruo monstruo)
        {
            Random random = new Random();
            int ataqueJugador = jugador.Estadisticas.Destreza * jugador.Estadisticas.Fuerza * jugador.Estadisticas.Nivel;
            int defensaJugador = jugador.Estadisticas.Armadura * jugador.Estadisticas.Velocidad;
            int ataqueMonstruo = monstruo.Destreza * monstruo.Fuerza * monstruo.Nivel;
            int defensaMonstruo = monstruo.Armadura * monstruo.Velocidad;
            Console.Clear();
            Console.WriteLine($"<<<---APARECE UN {monstruo.Tipo}, CUIDADO!--->>>");

            string respuesta;
            do
            {
                Console.WriteLine("DESEA SALTEAR EL EFECTO COMBATE?");
                Console.WriteLine("1.SI");
                Console.WriteLine("2.NO");
                Console.Write("Ingrese su respuesta: ");
                respuesta = Console.ReadLine();
                if (respuesta != "1" && respuesta != "2")
                {
                    Console.WriteLine("***RESPUESTA NO VALIDA***");
                }
            } while (respuesta != "1" && respuesta != "2");
            Console.Clear();
            Console.WriteLine($"<<<---APARECE UN {monstruo.Tipo}, CUIDADO!--->>>");

            while (jugador.Estadisticas.Salud > 0 && monstruo.Salud > 0)
            {
                if (jugador.Estadisticas.Velocidad >= monstruo.Velocidad)
                {
                    int efectividadJugador = random.Next(1, 101);
                    int danioJugador = (ataqueJugador * efectividadJugador / 500 ) - defensaMonstruo;
                    if (danioJugador <= 0)
                    {
                        danioJugador = 2;
                    }

                    if (respuesta == "2")
                    {
                        FuncionesMazmorra.EfectoCombatePersonaje(jugador, monstruo, danioJugador);
                    }

                    monstruo.Salud -= danioJugador;
                    if (monstruo.Salud <= 0)
                    {
                        Console.WriteLine($"{monstruo.Tipo} ha sido derrotado.");
                        jugador.GanarExp(monstruo.Nivel * 5);
                        return true;
                    }
                }

                int efectividadMonstruo = random.Next(1, 101);
                int danioMonstruo = (ataqueMonstruo * efectividadMonstruo / 500 ) - defensaJugador;
                if (danioMonstruo <= 0)
                {
                    danioMonstruo = 1;
                }
                if (respuesta == "2")
                {
                    FuncionesMazmorra.EfectoCombateMonstruo(jugador, monstruo, danioMonstruo);
                }

                jugador.Estadisticas.ModificarEstadisticas(0,0,0,0,0, -danioMonstruo, 0);
                if (jugador.Estadisticas.Salud <= 0)
                {
                    Console.WriteLine($"{jugador.Datos.Nombre} ha sido derrotado.");
                    return false;
                }

                if (jugador.Estadisticas.Velocidad < monstruo.Velocidad)
                {
                    int efectividadJugador = random.Next(1, 101);
                    int danioJugador = (ataqueJugador * efectividadJugador / 500 ) - defensaMonstruo;
                    if (danioJugador <= 0)
                    {
                        danioJugador = 2;
                    }

                    if (respuesta == "2")
                    {
                        FuncionesMazmorra.EfectoCombatePersonaje(jugador, monstruo, danioJugador);
                    }
                    monstruo.Salud -= danioJugador;
                    if (monstruo.Salud <= 0)
                    {
                        Console.WriteLine($"{monstruo.Tipo} ha sido derrotado.");
                        jugador.GanarExp(monstruo.Nivel * 5);
                        return true;
                    }
                }



            }
            return false;
        }
    }
}