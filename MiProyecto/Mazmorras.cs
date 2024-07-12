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
        private bool completada;

        public string Nombre { get => nombre; set => nombre = value; }
        public List<Monstruo> Monstruos { get => monstruos; set => monstruos = value; }
        public Monstruo Jefe { get => jefe; set => jefe = value; }
        public bool Completada { get => completada; set => completada = value; }

        public Mazmorra(string Nombre ,List<Monstruo> Monstruos, Monstruo Jefe)
        {

            this.Nombre = Nombre;
            this.Monstruos = Monstruos;
            this.Jefe = Jefe;
            Completada = false;
            
        }

        public static async Task<Root> NombreMazmorraAsync()
        {
            Random random = new Random();
            string numero = Convert.ToString(random.Next(1,61));
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
                return null;
            }

        }

        public bool IniciarMazmorra(Personaje personaje)
        {
            Console.WriteLine($"¡Bienvenido a la mazmorra {Nombre}!");
            FuncionesVarias.EfectoMazmorra();
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();

            foreach (var monstruo in Monstruos)
            {
                Console.Clear();
                Console.WriteLine($"<<<---APARECE UN {monstruo.Tipo}, CUIDADO!--->>>");
                if (!(Combate(personaje, monstruo)))
                {
                    return false;
                }
                Console.WriteLine($"Salud luego del combate: {personaje.Salud}");
                Console.WriteLine("Presione una tecla para el siguiente combate...");
                Console.ReadKey();


            }
            Console.Clear();
            Console.WriteLine("LLEGASTE A LA SALA DEL JEFE");
            Console.WriteLine("RECOMPENSA: SALUD AL 100%");
            Console.WriteLine("Presione una tecla para pelear con el jefe...");
            Console.ReadKey();
            personaje.Salud = 100;
            if (!(Combate(personaje, Jefe)))
            {
                return false;
            }
            Completada = true;
            return true;
        }

        public bool Combate(Personaje jugador, Monstruo monstruo)
        {
            Random random = new Random();
            int ataqueJugador = jugador.Destreza * jugador.Fuerza * jugador.Nivel;
            int defensaJugador = jugador.Armadura * jugador.Velocidad;
            int ataqueMonstruo = monstruo.Destreza * monstruo.Fuerza * monstruo.Nivel;
            int defensaMonstruo = monstruo.Armadura * monstruo.Velocidad;
            Console.Clear();

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

            while (jugador.Salud > 0 && monstruo.Salud > 0)
            {
                if (jugador.Velocidad >= monstruo.Velocidad)
                {
                    int efectividadJugador = random.Next(1, 101);
                    int danioJugador = ((ataqueJugador * efectividadJugador) - defensaMonstruo) / 500;
                    if (danioJugador < 0)
                    {
                        danioJugador = 0;
                    }

                    if (respuesta == "2")
                    {
                        FuncionesVarias.EfectoCombatePersonaje(jugador, monstruo, danioJugador);
                    }

                    monstruo.Salud -= danioJugador;
                    if (monstruo.Salud <= 0)
                    {
                        Console.WriteLine($"{monstruo.Tipo} ha sido derrotado.");
                        jugador.GanarExp(monstruo.Nivel * 15);
                        return true;
                    }
                }

                int efectividadMonstruo = random.Next(1, 101);
                int danioMonstruo = ((ataqueMonstruo * efectividadMonstruo) - defensaJugador) / 500;
                if (danioMonstruo < 0)
                {
                    danioMonstruo = 0;
                }
                if (respuesta == "2")
                {
                    FuncionesVarias.EfectoCombateMonstruo(jugador, monstruo, danioMonstruo);
                }

                jugador.Salud -= danioMonstruo;
                if (jugador.Salud <= 0)
                {
                    Console.WriteLine($"{jugador.Nombre} ha sido derrotado.");
                    return false;
                }

                if (jugador.Velocidad < monstruo.Velocidad)
                {
                    int efectividadJugador = random.Next(1, 101);
                    int danioJugador = ((ataqueJugador * efectividadJugador) - defensaMonstruo) / 500;
                    if (danioJugador < 0)
                    {
                        danioJugador = 0;
                    }

                    if (respuesta == "2")
                    {
                        FuncionesVarias.EfectoCombatePersonaje(jugador, monstruo, danioJugador);
                    }
                    monstruo.Salud -= danioJugador;
                    if (monstruo.Salud <= 0)
                    {
                        Console.WriteLine($"{monstruo.Tipo} ha sido derrotado.");
                        jugador.GanarExp(monstruo.Nivel * 15);
                        return true;
                    }
                }



            }
            return false;
        }
    }
}