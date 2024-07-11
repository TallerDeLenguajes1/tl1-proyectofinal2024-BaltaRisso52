// See https://aka.ms/new-console-template for more information
using Protagonista;
using Monstruos;
using Mazmorras;
using Funciones;


FuncionesVarias.MostrarIntro();

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
Console.ReadKey();




