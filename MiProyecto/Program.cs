// See https://aka.ms/new-console-template for more information
using Protagonista;

Console.Write("Ingrese el nombre de su personaje: ");
string nombre = Console.ReadLine();
Personaje protagonista = new Personaje(nombre);

protagonista.MostrarCaracteristicas();


