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
            this.Tipo = Tipo;
            this.Salud = 100;
            generarAtributos();
        }

        public Tipos Tipo { get => tipo; set => tipo = value; }
        public int Velocidad { get => velocidad; set => velocidad = value; }
        public int Destreza { get => destreza; set => destreza = value; }
        public int Fuerza { get => fuerza; set => fuerza = value; }
        public int Nivel { get => nivel; set => nivel = value; }
        public int Armadura { get => armadura; set => armadura = value; }
        public int Salud { get => salud; set => salud = (value < 0) ? 0 : value; }

        // puto el que lee
        private void generarAtributos()
        {
            Random random = new Random();

            switch (Tipo)
            {
                case Tipos.Goblin:

                    Velocidad = random.Next(1, 6);
                    Destreza = random.Next(2, 5);
                    Fuerza = random.Next(2, 8);
                    Nivel = random.Next(2, 8);
                    Armadura = random.Next(1, 6);
                    break;

                case Tipos.Lobo:

                    Nivel = random.Next(2, 8);
                    Fuerza = random.Next(4, 16);
                    Velocidad = random.Next(4, 16);
                    Destreza = random.Next(4, 7);
                    Armadura = random.Next(4, 16);
                    break;

                case Tipos.HombreLagarto:

                    Nivel = random.Next(11, 22);
                    Fuerza = random.Next(11, 22);
                    Velocidad = random.Next(11, 22);
                    Destreza = random.Next(7, 11);
                    Armadura = random.Next(11, 22);


                    break;

                case Tipos.Ogro:
                    Nivel = random.Next(18, 29);
                    Fuerza = random.Next(18, 29);
                    Velocidad = random.Next(18, 29);
                    Destreza = random.Next(13, 16);
                    Armadura = random.Next(18, 29);
                    break;

                case Tipos.Esqueleto:
                    Nivel = random.Next(25, 37);
                    Fuerza = random.Next(25, 37);
                    Velocidad = random.Next(25, 37);
                    Destreza = random.Next(14, 18);
                    Armadura = random.Next(25, 37);
                    break;

                case Tipos.MagoOscuro:
                    Nivel = random.Next(8, 11);
                    Fuerza = random.Next(18, 21);
                    Velocidad = random.Next(17, 21);
                    Destreza = random.Next(20, 27);
                    Armadura = random.Next(15, 19);
                    break;

                case Tipos.Minotauro:
                    Nivel = random.Next(9, 13);
                    Fuerza = random.Next(23, 27);
                    Velocidad = random.Next(28, 32);
                    Destreza = random.Next(25, 29);
                    Armadura = random.Next(25, 30);
                    break;

                case Tipos.Golem:
                    Nivel = random.Next(8, 11);
                    Fuerza = random.Next(28, 32);
                    Velocidad = random.Next(22, 26);
                    Destreza = random.Next(22, 26);
                    Armadura = random.Next(30, 38);
                    break;

                case Tipos.Lich:
                    Nivel = random.Next(11, 14);
                    Fuerza = random.Next(27, 30);
                    Velocidad = random.Next(27, 32);
                    Destreza = random.Next(38, 41);
                    Armadura = random.Next(28, 31);
                    break;

                case Tipos.AraniaGigante:
                    Nivel = random.Next(12, 15);
                    Fuerza = random.Next(30, 34);
                    Velocidad = random.Next(28, 34);
                    Destreza = random.Next(35, 40);
                    Armadura = random.Next(35, 39);
                    break;

                case Tipos.Demonio:
                    Nivel = random.Next(13, 17);
                    Fuerza = random.Next(32, 38);
                    Velocidad = random.Next(30, 34);
                    Destreza = random.Next(38, 43);
                    Armadura = random.Next(38, 43);
                    break;

                case Tipos.Dragon:
                    Nivel = random.Next(15, 19);
                    Fuerza = random.Next(38, 44);
                    Velocidad = random.Next(38, 44);
                    Destreza = random.Next(43, 47);
                    Armadura = random.Next(49, 54);
                    break;

                case Tipos.ReyDemonio:

                    Nivel = random.Next(27, 31);
                    Fuerza = random.Next(37, 41);
                    Velocidad = random.Next(85, 91);
                    Destreza = random.Next(37, 41);
                    Armadura = random.Next(85, 91);
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