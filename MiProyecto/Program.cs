// See https://aka.ms/new-console-template for more information
using Protagonista;
using Monstruos;

Console.Write("Ingrese el nombre de su personaje: ");
string nombre = Console.ReadLine();
Personaje protagonista = new Personaje(nombre);
Monstruo globin = new Monstruo(Tipos.Goblin);

protagonista.MostrarCaracteristicas();
globin.MostrarCaracteristicas();




