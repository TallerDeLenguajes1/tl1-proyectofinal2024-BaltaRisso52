using Monstruos;
using Protagonista;
using Funciones;
namespace Mazmorras
{
    public class Mazmorra
    {
        private string nombre;
        private List<Monstruo> monstruos;
        private Monstruo jefe;
        private bool completada;

        public Mazmorra(string Nombre, List<Monstruo> Monstruos, Monstruo Jefe)
        {
            nombre = Nombre;
            monstruos = Monstruos;
            jefe = Jefe;
            completada = false;
        }

        public bool IniciarMazmorra(Personaje personaje)
        {
            Console.WriteLine($"¡Bienvenido a la mazmorra {nombre}!");
            foreach (var monstruo in monstruos)
            {
                Console.WriteLine($"<<<---APARECE UN {monstruo.Tipo}, CUIDADO!--->>>");
                if (!(Combate(personaje, monstruo)))
                {
                    return false;
                }
                Console.WriteLine($"Salud luego del combate: {personaje.Salud}");
                Console.WriteLine("Presione una tecla para el siguiente combate...");
                Console.ReadKey();
                Console.Clear();

            }
            Console.WriteLine("SALUD AL 100% POR LLEGAR A LA SALA DEL JEFE");
            personaje.Salud = 100;
            if (!(Combate(personaje, jefe)))
            {
                return false;
            }
            completada = true;
            return true;
        }

        public bool Combate(Personaje jugador, Monstruo monstruo)
        {
            Random random = new Random();
            int ataqueJugador = jugador.Destreza * jugador.Fuerza * jugador.Nivel;
            int defensaJugador = jugador.Armadura * jugador.Velocidad;
            int ataqueMonstruo = monstruo.Destreza * monstruo.Fuerza * monstruo.Nivel;
            int defensaMonstruo = monstruo.Armadura * monstruo.Velocidad;


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