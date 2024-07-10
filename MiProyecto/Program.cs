// See https://aka.ms/new-console-template for more information
using Protagonista;
using Monstruos;
using Mazmorras;
string texto = @"   ___  _                                   _      _             
  / __\(_)  ___  _ __  __   __  ___  _ __  (_)  __| |  ___   ___ 
 /__\//| | / _ \| '_ \ \ \ / / / _ \| '_ \ | | / _` | / _ \ / __|
/ \/  \| ||  __/| | | | \ V / |  __/| | | || || (_| || (_) |\__ \
\_____/|_| \___||_| |_|  \_/   \___||_| |_||_| \__,_| \___/ |___/
Ingrese el nombre de su personaje:";

foreach (var item in texto)
{
    Console.Write(item);
    Thread.Sleep(1);
}
// Console.WriteLine();

string nombre = Console.ReadLine();
Personaje protagonista = new Personaje(nombre);
Monstruo globin = new Monstruo(Tipos.Goblin);
Monstruo globin1 = new Monstruo(Tipos.Goblin);
Monstruo lobo = new Monstruo(Tipos.Lobo);
List<Monstruo> monstruos = new List<Monstruo>();
monstruos.Add(globin);
monstruos.Add(globin1);
Mazmorra prueba = new Mazmorra("balta", monstruos, lobo);
protagonista.Entrenar();
protagonista.Entrenar();
protagonista.Entrenar();
protagonista.Entrenar();
bool probando = prueba.IniciarMazmorra(protagonista);
if (probando)
{
    Console.WriteLine("Mazmorra superada");

}
else
{
    Console.WriteLine("Mazmorra NO superada");
}

protagonista.MostrarCaracteristicas();
globin.MostrarCaracteristicas();




