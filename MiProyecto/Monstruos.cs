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


        public int Velocidad { get => velocidad;}
        public int Destreza { get => destreza;}
        public int Fuerza { get => fuerza;}
        public int Nivel { get => nivel;}
        public int Armadura { get => armadura;}
        public int Salud { get => salud;}
        public Tipos Tipo { get => tipo;}

        public Monstruo(Tipos Tipo)
        {
            Random random = new Random();
            tipo = Tipo;
            switch (Tipo)
            {
                case Tipos.Goblin:
                    
                    velocidad = random.Next(4,7);
                    destreza = random.Next(3,6);
                    fuerza = random.Next(3,6);
                    nivel = random.Next(1,4);
                    armadura = random.Next(1,4);
                    salud = 100;
                break;

                case Tipos.Lobo:
                    
                    nivel = random.Next(2,4);
                    salud= 100;
                    fuerza= random.Next(8,11);
                    velocidad= random.Next(10,13);
                    destreza= random.Next(8,10);
                    armadura= random.Next(8,10);
                break;

                case Tipos.HombreLagarto:
                    
                    nivel = random.Next(4,6);
                    salud= 100;
                    fuerza= random.Next(11,13);
                    velocidad= random.Next(10,13);
                    destreza= random.Next(8,10);
                    armadura= random.Next(8,10);
                break;

                case Tipos.Ogro:
                    nivel = random.Next(4,6);
                    salud= 100;
                    fuerza= random.Next(15,20);
                    velocidad= random.Next(13,16);
                    destreza= random.Next(13,16);
                    armadura= random.Next(15,17);
                break;

                case Tipos.Esqueleto:
                    nivel = random.Next(5,9);
                    salud= 100;
                    fuerza= random.Next(13,17);
                    velocidad= random.Next(17,19);
                    destreza= random.Next(14,18);
                    armadura= random.Next(11,15);
                break;

                case Tipos.MagoOscuro:
                    nivel = random.Next(8,11);
                    salud= 100;
                    fuerza= random.Next(18,21);
                    velocidad= random.Next(17,21);
                    destreza= random.Next(20,27);
                    armadura= random.Next(15,19);
                break;

                case Tipos.Minotauro:
                    nivel = random.Next(9,13);
                    salud= 100;
                    fuerza= random.Next(23,27);
                    velocidad= random.Next(28,32);
                    destreza= random.Next(25,29);
                    armadura= random.Next(25,30);
                break;

                case Tipos.Golem:
                    nivel = random.Next(8,11);
                    salud= 100;
                    fuerza= random.Next(28,32);
                    velocidad= random.Next(22,26);
                    destreza= random.Next(22,26);
                    armadura= random.Next(30,38);
                break;

                case Tipos.Lich:
                    nivel = random.Next(11,14);
                    salud= 100;
                    fuerza= random.Next(27,30);
                    velocidad= random.Next(27,32);
                    destreza= random.Next(38,41);
                    armadura= random.Next(28,31);
                break;

                case Tipos.AraniaGigante:
                    nivel = random.Next(12,15);
                    salud= 100;
                    fuerza= random.Next(30,34);
                    velocidad= random.Next(28,34);
                    destreza= random.Next(35,40);
                    armadura= random.Next(35,39);
                break;

                case Tipos.Demonio:
                    nivel = random.Next(13,17);
                    salud= 100;
                    fuerza= random.Next(32,38);
                    velocidad= random.Next(30,34);
                    destreza= random.Next(38,43);
                    armadura= random.Next(38,43);
                break;

                case Tipos.Dragon:
                    nivel = random.Next(15,19);
                    salud= 100;
                    fuerza= random.Next(38,44);
                    velocidad= random.Next(38,44);
                    destreza= random.Next(43,47);
                    armadura= random.Next(49,54);
                break;

                case Tipos.ReyDemonio:
                    nivel = random.Next(18,23);
                    salud= 100;
                    fuerza= random.Next(45,55);
                    velocidad= random.Next(40,48);
                    destreza= random.Next(44,51);
                    armadura= random.Next(65,75);
                break;

                

                default:
                break;
            }
        }

        public void MostrarCaracteristicas(){
            Console.WriteLine($"TIPO: {tipo}");
            Console.WriteLine("**CARACTERISTICAS**");
            Console.WriteLine($"Salud: {salud}");
            Console.WriteLine($"Nivel: {nivel}");
            Console.WriteLine($"Fuerza: {fuerza}");
            Console.WriteLine($"Velocidad: {velocidad}");
            Console.WriteLine($"Destreza: {destreza}");
            Console.WriteLine($"Armadura: {armadura}");
            
        }
    }
}