// See https://aka.ms/new-console-template for more information
using Protagonista;
using Monstruos;
using Mazmorras;
using Funciones;

// Personaje protagonista = FuncionesVarias.CrearPersonaje();
// List<Mazmorra> mazmorras1 = await FuncionesVarias.CrearLista11Mazmorras();

// int nume = 1;
// foreach (var item in mazmorras1)
// {
//     Console.WriteLine($"mazmorra numero {nume}");
//     Console.WriteLine($"nombre: {item.Nombre}");
//     foreach (var item2 in item.Monstruos)
//     {
//         Console.WriteLine($"tipo de monstruo: {item2.Tipo}");
//     }
//     Console.WriteLine($"jefe: {item.Jefe.Tipo}");
//     Console.WriteLine("--------------------");
//     nume++;
// }
// protagonista.Entrenar();
// protagonista.Entrenar();
// protagonista.Entrenar();
// List<Monstruo> monstruos = new List<Monstruo>();
// Monstruo globin = new Monstruo(Tipos.Goblin);
// Monstruo globin2 = new Monstruo(Tipos.Goblin);
// Monstruo lobo = new Monstruo((Tipos)2);
// monstruos.Add(globin);
// monstruos.Add(globin2);
// var nombre = await Mazmorra.NombreMazmorraAsync();
// Console.WriteLine(nombre.name);
// Console.WriteLine(nombre.climate);
// Console.WriteLine(nombre.terrain);

// Mazmorra mazmorra = new Mazmorra(nombre.name, monstruos, lobo);
// mazmorra.IniciarMazmorra(protagonista);

// MOSTRAR LA INTRODUCCION DEJ JUEGO
FuncionesVarias.MostrarIntro();


bool salir = false;
while (!salir)
{
    Console.WriteLine("╔════════════════════════════════════════════╗");
    Console.WriteLine("║--------------------MENU--------------------║");
    Console.WriteLine("╠════════════════════════════════════════════╣");
    Console.WriteLine("║ 1. Nueva Partida                           ║");
    Console.WriteLine("║ 2. Cargar Partida                          ║");
    Console.WriteLine("║ 3. Salir                                   ║");
    Console.WriteLine("╚════════════════════════════════════════════╝");
    Console.Write("Ingrese su respuesta: ");
    string respuesta = Console.ReadLine();

    switch (respuesta)
    {
        case "1":
            //  CREAR EL PERSONAJE DEL JUGADOR
             Personaje jugador = FuncionesVarias.CrearPersonaje();

            //  CREO UNA LISTA DE 10 MAZMORRAS
             List<Mazmorra> mazmorras = await FuncionesVarias.CrearLista11Mazmorras();

            FuncionesVarias.Menu(jugador, mazmorras);



            


            break;

        case "2":
            break;

        case "3":
            Console.WriteLine("Gracias por jugar. ¡Hasta la próxima!");
            salir = true;
            break;

        default:
            Console.WriteLine("Opción no válida. Por favor, selecciona una opción del 1 al 3.");
            break;

    }
}





