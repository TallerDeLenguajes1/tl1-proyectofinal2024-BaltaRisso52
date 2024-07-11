namespace Monstruos
{
    public enum Tipos
    {
        Goblin,
        Lobo,
        HombreLagarto,
        Ogro,
        Esqueleto,
        MagoOscuro,
        Minotauro,
        Golem,
        Lich,
        AraniaGigante,
        Demonio,
        Dragon,
        ReyDemonio

    }
    public class Monstruo
    {
        private Tipos tipo;
        private int velocidad;
        private int destreza;
        private int fuerza;
        private int nivel;
        private int armadura;
        private int salud;


        

        public Monstruo(Tipos Tipo)
        {
            Random random = new Random();
            this.Tipo = Tipo;
            switch (Tipo)
            {
                case Tipos.Goblin:
                    
                    Velocidad = random.Next(4,7);
                    Destreza = random.Next(3,6);
                    Fuerza = random.Next(3,6);
                    Nivel = random.Next(1,4);
                    Armadura = random.Next(1,4);
                    Salud = 100;
                break;

                case Tipos.Lobo:
                    
                    Nivel = random.Next(2,4);
                    Salud= 100;
                    Fuerza= random.Next(8,11);
                    Velocidad= random.Next(10,13);
                    Destreza= random.Next(8,10);
                    Armadura= random.Next(8,10);
                break;

                case Tipos.HombreLagarto:
                    
                    Nivel = random.Next(4,6);
                    Salud= 100;
                    Fuerza= random.Next(11,13);
                    Velocidad= random.Next(10,13);
                    Destreza= random.Next(8,10);
                    Armadura= random.Next(8,10);
                break;

                case Tipos.Ogro:
                    Nivel = random.Next(4,6);
                    Salud= 100;
                    Fuerza= random.Next(15,20);
                    Velocidad= random.Next(13,16);
                    Destreza= random.Next(13,16);
                    Armadura= random.Next(15,17);
                break;

                case Tipos.Esqueleto:
                    Nivel = random.Next(5,9);
                    Salud= 100;
                    Fuerza= random.Next(13,17);
                    Velocidad= random.Next(17,19);
                    Destreza= random.Next(14,18);
                    Armadura= random.Next(11,15);
                break;

                case Tipos.MagoOscuro:
                    Nivel = random.Next(8,11);
                    Salud= 100;
                    Fuerza= random.Next(18,21);
                    Velocidad= random.Next(17,21);
                    Destreza= random.Next(20,27);
                    Armadura= random.Next(15,19);
                break;

                case Tipos.Minotauro:
                    Nivel = random.Next(9,13);
                    Salud= 100;
                    Fuerza= random.Next(23,27);
                    Velocidad= random.Next(28,32);
                    Destreza= random.Next(25,29);
                    Armadura= random.Next(25,30);
                break;

                case Tipos.Golem:
                    Nivel = random.Next(8,11);
                    Salud= 100;
                    Fuerza= random.Next(28,32);
                    Velocidad= random.Next(22,26);
                    Destreza= random.Next(22,26);
                    Armadura= random.Next(30,38);
                break;

                case Tipos.Lich:
                    Nivel = random.Next(11,14);
                    Salud= 100;
                    Fuerza= random.Next(27,30);
                    Velocidad= random.Next(27,32);
                    Destreza= random.Next(38,41);
                    Armadura= random.Next(28,31);
                break;

                case Tipos.AraniaGigante:
                    Nivel = random.Next(12,15);
                    Salud= 100;
                    Fuerza= random.Next(30,34);
                    Velocidad= random.Next(28,34);
                    Destreza= random.Next(35,40);
                    Armadura= random.Next(35,39);
                break;

                case Tipos.Demonio:
                    Nivel = random.Next(13,17);
                    Salud= 100;
                    Fuerza= random.Next(32,38);
                    Velocidad= random.Next(30,34);
                    Destreza= random.Next(38,43);
                    Armadura= random.Next(38,43);
                break;

                case Tipos.Dragon:
                    Nivel = random.Next(15,19);
                    Salud= 100;
                    Fuerza= random.Next(38,44);
                    Velocidad= random.Next(38,44);
                    Destreza= random.Next(43,47);
                    Armadura= random.Next(49,54);
                break;

                case Tipos.ReyDemonio:
                    Nivel = random.Next(18,23);
                    Salud= 100;
                    Fuerza= random.Next(45,55);
                    Velocidad= random.Next(40,48);
                    Destreza= random.Next(44,51);
                    Armadura= random.Next(65,75);
                break;

                

                default:
                break;
            }
        }

        public Tipos Tipo { get => tipo; set => tipo = value; }
        public int Velocidad { get => velocidad; set => velocidad = value; }
        public int Destreza { get => destreza; set => destreza = value; }
        public int Fuerza { get => fuerza; set => fuerza = value; }
        public int Nivel { get => nivel; set => nivel = value; }
        public int Armadura { get => armadura; set => armadura = value; }
        public int Salud { get => salud; set => salud = (value < 0) ? 0 : value; }

        public void MostrarCaracteristicas(){
            Console.WriteLine($"TIPO: {Tipo}");
            Console.WriteLine("**CARACTERISTICAS**");
            Console.WriteLine($"Salud: {Salud}");
            Console.WriteLine($"Nivel: {Nivel}");
            Console.WriteLine($"Fuerza: {Fuerza}");
            Console.WriteLine($"Velocidad: {Velocidad}");
            Console.WriteLine($"Destreza: {Destreza}");
            Console.WriteLine($"Armadura: {Armadura}");
            
        }
    }
}