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
            this.tipo = Tipo;
            this.salud = 100;
            generarAtributos();
        }

        public Tipos Tipo { get => tipo; }
        public int Velocidad { get => velocidad; }
        public int Destreza { get => destreza; }
        public int Fuerza { get => fuerza; }
        public int Nivel { get => nivel; }
        public int Armadura { get => armadura; }
        public int Salud { get => salud; set => salud = (value < 0) ? 0 : value; }

        private void generarAtributos()
        {
            Random random = new Random();

            switch (Tipo)
            {
                case Tipos.Goblin:

                    velocidad = random.Next(1, 6);
                    destreza = random.Next(2, 5);
                    fuerza = random.Next(2, 8);
                    nivel = random.Next(2, 8);
                    armadura = random.Next(1, 6);
                    break;

                case Tipos.Lobo:

                    nivel = random.Next(2, 8);
                    fuerza = random.Next(4, 16);
                    velocidad = random.Next(4, 16);
                    destreza = random.Next(4, 7);
                    armadura = random.Next(4, 16);
                    break;

                case Tipos.HombreLagarto:

                    nivel = random.Next(11, 22);
                    fuerza = random.Next(11, 22);
                    velocidad = random.Next(11, 22);
                    destreza = random.Next(7, 11);
                    armadura = random.Next(11, 22);


                    break;

                case Tipos.Ogro:
                    nivel = random.Next(18, 29);
                    fuerza = random.Next(18, 29);
                    velocidad = random.Next(18, 29);
                    destreza = random.Next(13, 16);
                    armadura = random.Next(18, 29);
                    break;

                case Tipos.Esqueleto:
                    nivel = random.Next(25, 37);
                    fuerza = random.Next(25, 37);
                    velocidad = random.Next(25, 37);
                    destreza = random.Next(14, 18);
                    armadura = random.Next(25, 37);
                    break;

                case Tipos.MagoOscuro:
                    nivel = random.Next(8, 11);
                    fuerza = random.Next(18, 21);
                    velocidad = random.Next(17, 21);
                    destreza = random.Next(20, 27);
                    armadura = random.Next(15, 19);
                    break;

                case Tipos.Minotauro:
                    nivel = random.Next(9, 13);
                    fuerza = random.Next(23, 27);
                    velocidad = random.Next(28, 32);
                    destreza = random.Next(25, 29);
                    armadura = random.Next(25, 30);
                    break;

                case Tipos.Golem:
                    nivel = random.Next(8, 11);
                    fuerza = random.Next(28, 32);
                    velocidad = random.Next(22, 26);
                    destreza = random.Next(22, 26);
                    armadura = random.Next(30, 38);
                    break;

                case Tipos.Lich:
                    nivel = random.Next(11, 14);
                    fuerza = random.Next(27, 30);
                    velocidad = random.Next(27, 32);
                    destreza = random.Next(38, 41);
                    armadura = random.Next(28, 31);
                    break;

                case Tipos.AraniaGigante:
                    nivel = random.Next(12, 15);
                    fuerza = random.Next(30, 34);
                    velocidad = random.Next(28, 34);
                    destreza = random.Next(35, 40);
                    armadura = random.Next(35, 39);
                    break;

                case Tipos.Demonio:
                    nivel = random.Next(13, 17);
                    fuerza = random.Next(32, 38);
                    velocidad = random.Next(30, 34);
                    destreza = random.Next(38, 43);
                    armadura = random.Next(38, 43);
                    break;

                case Tipos.Dragon:
                    nivel = random.Next(15, 19);
                    fuerza = random.Next(38, 44);
                    velocidad = random.Next(38, 44);
                    destreza = random.Next(43, 47);
                    armadura = random.Next(49, 54);
                    break;

                case Tipos.ReyDemonio:

                    nivel = random.Next(27, 31);
                    fuerza = random.Next(37, 41);
                    velocidad = random.Next(85, 91);
                    destreza = random.Next(37, 41);
                    armadura = random.Next(85, 91);
                    break;



                default:
                    break;
            }
        }

        public void MostrarCaracteristicas()
        {
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