using Monstruos;
using Protagonista;
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
                Console.WriteLine($"Aparece un {monstruo.Tipo}, CUIDADO!");
                if (!(Combate(personaje, monstruo)))
                {
                    return false;
                }

            }
            Console.WriteLine("Salud al 100% por llegar al jefe");
            personaje.Salud = 100;
            if (!(Combate(personaje, jefe)))
            {
                return false;
            }
            return true;
        }

        public bool Combate(Personaje jugador, Monstruo monstruo)
        {
            Random random = new Random();
            int ataqueJugador = jugador.Destreza * jugador.Fuerza * jugador.Nivel;
            int defensaJugador = jugador.Armadura * jugador.Velocidad;
            int ataqueMonstruo = monstruo.Destreza * monstruo.Fuerza * monstruo.Nivel;
            int defensaMonstruo = monstruo.Armadura * monstruo.Velocidad;
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
                    Console.WriteLine($"Danio provoca jugador: {danioJugador}");
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
                    Console.WriteLine($"Danio provoca jugador: {danioJugador}");
                    monstruo.Salud -= danioJugador;
                    if (monstruo.Salud <= 0)
                    {
                        Console.WriteLine($"{monstruo.Tipo} ha sido derrotado.");
                        jugador.GanarExp(monstruo.Nivel * 15);
                        return true;
                    }
                }

                Console.WriteLine($"Salud jugador: {jugador.Salud}");
                Console.WriteLine($"Salud Monstruo: {monstruo.Salud}");

            }
            return false;
        }
    }
}