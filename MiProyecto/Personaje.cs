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

        public string Nombre { get => nombre; }
        public DateTime Fechanac { get => fechanac;}
        public int Edad { get => edad;}
        public int Velocidad { get => velocidad;}
        public int Destreza { get => destreza;}
        public int Fuerza { get => fuerza;}
        public int Nivel { get => nivel;}
        public int Armadura { get => armadura;}
        public int Salud { get => salud;}
        public int Experiencia { get => experiencia;}

        public Personaje(string Nombre)
        {
            this.nombre = Nombre;
            Random random = new Random();
            edad = random.Next(18,31);
            DateTime hoy = DateTime.Today; // obtener la fecha actual
            int anioNac = hoy.Year - edad; // anio de nacimiento
            int dia = random.Next(1,366); // numero aleatorio para el dia de nacimiento
            fechanac = new DateTime(anioNac, 1, 1).AddDays(dia - 1); 

            velocidad = 2;
            destreza = 1;
            fuerza = 2;
            nivel = 1;
            armadura = 1;
            salud = 100;  
            experiencia = 0;
        }

        private void GanarExp(int ExpGanada){
            experiencia += ExpGanada;

            int ExpParaSigNivel = nivel * 100;

            if (experiencia >= ExpParaSigNivel)
            {
                nivel++;
                experiencia -= ExpParaSigNivel;
                Console.WriteLine($"***HAS ALCANZADO EL NIVEL >{nivel}<***");
            }
        }

        public void Entrenar(){
            Random random = new Random();
            velocidad += random.Next(1,4);
            destreza += random.Next(1,4);
            fuerza += random.Next(1,4);
            armadura += random.Next(1,4);
            GanarExp(10);
        }

        

        public void MostrarCaracteristicas(){
            Console.WriteLine("**CARACTERISTICAS**");
            Console.WriteLine($"Salud: {salud}");
            Console.WriteLine($"Nivel: {nivel}");
            Console.WriteLine($"Exp: {experiencia}");
            Console.WriteLine($"Fuerza: {fuerza}");
            Console.WriteLine($"Velocidad: {velocidad}");
            Console.WriteLine($"Destreza: {destreza}");
            Console.WriteLine($"Armadura: {armadura}");
            
        }


    }
}