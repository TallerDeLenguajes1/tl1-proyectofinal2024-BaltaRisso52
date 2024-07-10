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
        public int Salud { get => salud; set => salud = value; }
        public int Experiencia { get => experiencia; set => experiencia = value; }

        public Personaje(string Nombre)
        {
            this.Nombre = Nombre;
            Random random = new Random();
            Edad = random.Next(18,31);
            DateTime hoy = DateTime.Today; // obtener la fecha actual
            int anioNac = hoy.Year - Edad; // anio de nacimiento
            int dia = random.Next(1,366); // numero aleatorio para el dia de nacimiento
            Fechanac = new DateTime(anioNac, 1, 1).AddDays(dia - 1); 

            Velocidad = 2;
            Destreza = 1;
            Fuerza = 2;
            Nivel = 1;
            Armadura = 1;
            Salud = 100;  
            Experiencia = 0;
        }

        public void GanarExp(int ExpGanada){
            Experiencia += ExpGanada;

            int ExpParaSigNivel = Nivel * 100;

            if (Experiencia >= ExpParaSigNivel)
            {
                Nivel++;
                Experiencia -= ExpParaSigNivel;
                Console.WriteLine($"***HAS ALCANZADO EL NIVEL >{Nivel}<***");
            }
        }

        public void Entrenar(){
            Random random = new Random();
            Velocidad += random.Next(1,4);
            Destreza += random.Next(1,4);
            Fuerza += random.Next(1,4);
            Armadura += random.Next(1,4);
            GanarExp(10);
        }

        

        public void MostrarCaracteristicas(){
            Console.WriteLine("**CARACTERISTICAS**");
            Console.WriteLine($"Salud: {Salud}");
            Console.WriteLine($"Nivel: {Nivel}");
            Console.WriteLine($"Exp: {Experiencia}");
            Console.WriteLine($"Fuerza: {Fuerza}");
            Console.WriteLine($"Velocidad: {Velocidad}");
            Console.WriteLine($"Destreza: {Destreza}");
            Console.WriteLine($"Armadura: {Armadura}");
            
        }


    }
}