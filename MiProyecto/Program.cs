﻿// See https://aka.ms/new-console-template for more information
using Protagonista;
using Monstruos;
using Mazmorras;
using Funciones;
using Partida;

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
    Console.WriteLine("║ 3. Historial de ganadores                  ║");
    Console.WriteLine("║ 4. Salir                                   ║");
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
            FuncionesVarias.Menu(jugador, mazmorras); // MOSTRAR MENU 
            break;

        case "2":
            Console.Clear();
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
            PartidaJson.MostrarHistorialGanadores();
            break;

        case "4":
            Console.WriteLine("Gracias por jugar. ¡Hasta la próxima!");
            Console.WriteLine("Presione enter para salir...");
            Console.ReadKey();
            salir = true;
            break;

        default:
            Console.Clear();
            Console.WriteLine("Opción no válida. Por favor, selecciona una opción del 1 al 3.");
            break;

    }
}





