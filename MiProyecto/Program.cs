// See https://aka.ms/new-console-template for more information
using Protagonista;
using Monstruos;
using Mazmorras;
using Funciones;
using Partida;



// Personaje protagonista = FuncionesVarias.CrearPersonaje();
// List<Mazmorra> mazmorras1 = await FuncionesVarias.CrearLista11Mazmorras();
// PartidaJson.GuardarPartida(protagonista, mazmorras1, "baltari");
// Console.ReadKey();
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
            Console.Clear();
            // CREAR EL PERSONAJE DEL JUGADOR
            Personaje jugador = FuncionesVarias.CrearPersonaje();

            Console.WriteLine();
            // CREO UNA LISTA DE 10 MAZMORRAS
            List<Mazmorra> mazmorras = await FuncionesVarias.CrearLista11Mazmorras();

            Console.Clear();
            FuncionesVarias.Menu(jugador, mazmorras);






            break;

        case "2":
            Console.Write("Ingrese el nombre de su partida: ");
            string nombre = Console.ReadLine();
            string rutaRelativa = @"..\Partidas Guardadas";
            string rutaAbsolutaCarpeta = Path.GetFullPath(rutaRelativa);
            string rutaAbsolutaArchivo = Path.Combine(rutaAbsolutaCarpeta, nombre + ".json");
            if (File.Exists(rutaAbsolutaArchivo))
            {
                PartidaJson partida = PartidaJson.CargarPartida(nombre);
                Console.WriteLine("Partida cargada exitosamente!!!");
                Console.WriteLine("---DATOS DE LA PARTIDA---");
                partida.Personaje.MostrarCaracteristicas();
                Console.WriteLine($"Cantidad de mazmorras conquistadas: {11 - partida.Mazmorras.Count}");
                FuncionesVarias.Menu(partida.Personaje, partida.Mazmorras);
            }
            else
            {
                Console.WriteLine("El nombre ingresado no coincide con una partida guardada.");
            }
            break;

        case "3":
            Console.WriteLine("Gracias por jugar. ¡Hasta la próxima!");
            Console.WriteLine("Presione una tecla para salir...");
            Console.ReadKey();
            salir = true;
            break;

        default:
            Console.Clear();
            Console.WriteLine("Opción no válida. Por favor, selecciona una opción del 1 al 3.");
            break;

    }
}





