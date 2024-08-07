using Funciones;

namespace Protagonista
{
    public class Personaje
    {
        private string nombre;
        private DateTime fechanac;
        private int edad;
        private int velocidad;
        private int destreza;
        private int fuerza;
        private int nivel;
        private int armadura;
        private int salud;
        private int experiencia;

        public string Nombre { get => nombre; set => nombre = value; }
        public DateTime Fechanac { get => fechanac; set => fechanac = value; }
        public int Edad { get => edad; set => edad = value; }
        public int Velocidad { get => velocidad; set => velocidad = value; }
        public int Destreza { get => destreza; set => destreza = value; }
        public int Fuerza { get => fuerza; set => fuerza = value; }
        public int Nivel { get => nivel; set => nivel = value; }
        public int Armadura { get => armadura; set => armadura = value; }
        public int Salud { get => salud; set => salud = (value < 0) ? 0 : value; }
        public int Experiencia { get => experiencia; set => experiencia = value; }

        public Personaje(string Nombre)
        {
            this.Nombre = Nombre;
            Random random = new Random();
            Edad = random.Next(18, 31);
            DateTime hoy = DateTime.Today; // obtener la fecha actual
            int anioNac = hoy.Year - Edad; // anio de nacimiento
            int dia = random.Next(1, 366); // numero aleatorio para el dia de nacimiento
            Fechanac = new DateTime(anioNac, 1, 1).AddDays(dia - 1);

            Salud = 100;
            Velocidad = random.Next(1, 6);
            Destreza = random.Next(2, 5);
            Fuerza = random.Next(2, 8);
            Nivel = random.Next(2, 8);
            Armadura = random.Next(1, 6);
            Experiencia = 0;
        }

        public void GanarExp(int ExpGanada)
        {
            Experiencia += ExpGanada;

            int ExpParaSigNivel = Nivel * 100;

            if (Experiencia >= ExpParaSigNivel)
            {
                Nivel++;
                Experiencia -= ExpParaSigNivel;
                Console.WriteLine($"***HAS ALCANZADO EL NIVEL ===>{Nivel}<===***");
            }
        }

        public void Entrenar()
        {
            Console.Clear();
            Console.Write($"{Nombre} está entrenando");
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

            int velo = Velocidad;
            int dest = Destreza;
            int fuer = Fuerza;
            int armad = Armadura;
            int niv = Nivel;
            int exp = Experiencia;

            Random random = new Random();
            Velocidad += random.Next(1, 4);
            Destreza += random.Next(1, 4);
            Fuerza += random.Next(1, 4);
            Armadura += random.Next(1, 4);

            Console.WriteLine();
            GanarExp(10);

            Console.WriteLine("--------------------");
            Console.WriteLine("-----RESULTADOS-----");
            Console.WriteLine($"Salud: {Salud} ==> {Salud}");
            Console.WriteLine($"Nivel: {niv} ==> {Nivel}");
            Console.WriteLine($"Exp: {exp}/{niv * 100} ==> {Experiencia}/{Nivel * 100}");
            Console.WriteLine($"Fuerza: {fuer} ==> {Fuerza}");
            Console.WriteLine($"Velocidad: {velo} ==> {Velocidad}");
            Console.WriteLine($"Destreza: {dest} ==> {Destreza}");
            Console.WriteLine($"Armadura: {armad} ==> {Armadura}");
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
            Console.WriteLine($"Salud: {Salud}");
            Console.WriteLine($"Nivel: {Nivel}");
            Console.WriteLine($"Exp: {Experiencia}/{nivel * 100}");
            Console.WriteLine($"Fuerza: {Fuerza}");
            Console.WriteLine($"Velocidad: {Velocidad}");
            Console.WriteLine($"Destreza: {Destreza}");
            Console.WriteLine($"Armadura: {Armadura}");
            Console.WriteLine("--------------------");

        }


    }
}