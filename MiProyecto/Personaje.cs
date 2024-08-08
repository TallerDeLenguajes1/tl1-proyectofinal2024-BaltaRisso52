using Funciones;
using System.Text.Json.Serialization;

namespace Protagonista
{

    public class Datos
    {
        private string nombre;
        private DateTime fechanac;
        private int edad;

        public Datos(string nombre, DateTime fechanac, int edad)
        {
            this.nombre = nombre;
            this.fechanac = fechanac;
            this.edad = edad;
        }

        public string Nombre { get => nombre; }
        public DateTime Fechanac { get => fechanac; }
        public int Edad { get => edad; }
    }

    public class Estadisticas
    {
        private int velocidad;
        private int destreza;
        private int fuerza;
        private int nivel;
        private int armadura;
        private int salud;
        private int experiencia;

        public Estadisticas(int velocidad, int destreza, int fuerza, int nivel, int armadura, int salud, int experiencia)
        {
            this.velocidad = velocidad;
            this.destreza = destreza;
            this.fuerza = fuerza;
            this.nivel = nivel;
            this.armadura = armadura;
            this.salud = salud;
            this.experiencia = experiencia;
        }

        public void ModificarEstadisticas(int velocidad, int destreza, int fuerza, int nivel, int armadura, int salud, int experiencia)
        {

            this.velocidad = Velocidad + velocidad;
            this.destreza = Destreza + destreza;
            this.fuerza = Fuerza + fuerza;
            this.nivel = Nivel + nivel;
            this.armadura = Armadura + armadura;
            if (this.salud + salud < 0)
            {
                this.salud = 0;
            }
            else
            {
                this.salud = Salud + salud;
            }

            this.experiencia = Experiencia + experiencia;
        }

        public void Salud100()
        {
            salud = 100;
        }

        public void Salud1()
        {
            salud = 1;
        }

        public int Experiencia { get => experiencia; }
        public int Velocidad { get => velocidad; }
        public int Destreza { get => destreza; }
        public int Fuerza { get => fuerza; }
        public int Nivel { get => nivel; }
        public int Armadura { get => armadura; }
        public int Salud { get => salud; }
    }
    public class Personaje
    {
        private Datos datos;
        private Estadisticas estadisticas;
        public Datos Datos { get => datos; }
        public Estadisticas Estadisticas { get => estadisticas; }

        [JsonConstructor]
        public Personaje(Datos datos, Estadisticas estadisticas)
        {
            this.datos = datos;
            this.estadisticas = estadisticas;
        }

        public Personaje(string Nombre)
        {
            Random random = new Random();
            int edad = random.Next(18, 31);
            DateTime hoy = DateTime.Today; // obtener la fecha actual
            int anioNac = hoy.Year - edad; // anio de nacimiento
            int dia = random.Next(1, 366); // numero aleatorio para el dia de nacimiento
            DateTime fechanac = new DateTime(anioNac, 1, 1).AddDays(dia - 1);

            datos = new Datos(Nombre, fechanac, edad);

            estadisticas = new Estadisticas(random.Next(1, 6), random.Next(2, 5), random.Next(2, 8), 1, random.Next(1, 6), 100, 0);
        }

        public void GanarExp(int ExpGanada)
        {
            Estadisticas.ModificarEstadisticas(0, 0, 0, 0, 0, 0, ExpGanada);

            int ExpParaSigNivel = Estadisticas.Nivel * 100;

            if (Estadisticas.Experiencia >= ExpParaSigNivel)
            {
                Estadisticas.ModificarEstadisticas(0, 0, 0, 1, 0, 0, -ExpParaSigNivel);
                Console.WriteLine($"***HAS ALCANZADO EL NIVEL ===>{Estadisticas.Nivel}<===***");
            }
        }

        public void Entrenar()
        {
            Console.Clear();
            Console.Write($"{Datos.Nombre} está entrenando");
            int cursorLeft = Console.CursorLeft;
            int cursorTop = Console.CursorTop;
            string text = "...";
            for (int i = 0; i < 3; i++)
            {
                foreach (var item in text)
                {
                    Console.Write(item);
                    Thread.Sleep(500);
                }
                Console.SetCursorPosition(cursorLeft, cursorTop);
                Console.WriteLine("   ");
                Console.SetCursorPosition(cursorLeft, cursorTop);
            }

            int velo = Estadisticas.Velocidad;
            int dest = Estadisticas.Destreza;
            int fuer = Estadisticas.Fuerza;
            int armad = Estadisticas.Armadura;
            int niv = Estadisticas.Nivel;
            int exp = Estadisticas.Experiencia;

            Random random = new Random();

            Estadisticas.ModificarEstadisticas(random.Next(1, 4), random.Next(1, 4), random.Next(1, 4), 0, random.Next(1, 4), 0, 0);

            Console.WriteLine();
            GanarExp(10);

            Console.WriteLine("--------------------");
            Console.WriteLine("-----RESULTADOS-----");
            Console.WriteLine($"Salud: {Estadisticas.Salud} ==> {Estadisticas.Salud}");
            Console.WriteLine($"Nivel: {niv} ==> {Estadisticas.Nivel}");
            Console.WriteLine($"Exp: {exp}/{niv * 100} ==> {Estadisticas.Experiencia}/{Estadisticas.Nivel * 100}");
            Console.WriteLine($"Fuerza: {fuer} ==> {Estadisticas.Fuerza}");
            Console.WriteLine($"Velocidad: {velo} ==> {Estadisticas.Velocidad}");
            Console.WriteLine($"Destreza: {dest} ==> {Estadisticas.Destreza}");
            Console.WriteLine($"Armadura: {armad} ==> {Estadisticas.Armadura}");
            Console.WriteLine("--------------------");

            Console.WriteLine("Entrenamiento completo. Estadísticas mejoradas.");
            Console.WriteLine("Presiona enter para continuar...                        ");
            FuncionesPartida.LimpiarBuffer();
            Console.ReadKey();
        }



        public void MostrarCaracteristicas()
        {
            Console.WriteLine("--------------------");
            Console.WriteLine("----ESTADISTICAS----");
            Console.WriteLine($"Salud: {Estadisticas.Salud}");
            Console.WriteLine($"Nivel: {Estadisticas.Nivel}");
            Console.WriteLine($"Exp: {Estadisticas.Experiencia}/{Estadisticas.Nivel * 100}");
            Console.WriteLine($"Fuerza: {Estadisticas.Fuerza}");
            Console.WriteLine($"Velocidad: {Estadisticas.Velocidad}");
            Console.WriteLine($"Destreza: {Estadisticas.Destreza}");
            Console.WriteLine($"Armadura: {Estadisticas.Armadura}");
            Console.WriteLine("--------------------");

        }


    }
}