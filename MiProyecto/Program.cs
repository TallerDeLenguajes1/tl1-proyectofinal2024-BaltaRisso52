﻿// See https://aka.ms/new-console-template for more information
using Protagonista;
using Mazmorras;
using Funciones;
using Partida;
using Historial;

// MOSTRAR LA INTRODUCCION DEJ JUEGO
FuncionesPartida.MostrarIntro();



bool salir = false;
while (!salir)
{
    FuncionesPartida.LimpiarBuffer();
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
            Personaje jugador = FuncionesPersonaje.CrearPersonaje();

            Console.WriteLine();
            // CREO UNA LISTA DE 11 MAZMORRAS
            List<Mazmorra> mazmorras = await FuncionesMazmorra.CrearLista11Mazmorras();

            Console.Clear();
            FuncionesPartida.Menu(jugador, mazmorras); // MOSTRAR MENU 

            break;

        case "2":
            Console.Clear();


            if (PartidaJson.MostrarNombreDePartidasGuardadas()) // Se encarga de mostrar las partidas guardadas y en el caso de que existan permite ingresar nombre.
            {
                Console.Write("Ingrese el nombre de su partida: ");
                string nombre = Console.ReadLine();
                string rutaRelativa = @"..\Partidas Guardadas";
                string rutaAbsolutaCarpeta = Path.GetFullPath(rutaRelativa);
                string rutaAbsolutaArchivo = Path.Combine(rutaAbsolutaCarpeta, nombre + ".json");
                if (File.Exists(rutaAbsolutaArchivo)) // si existe el archivo comienza el juego
                {
                    PartidaJson partida = PartidaJson.CargarPartida(nombre);

                    if (partida != null)
                    {
                        Console.WriteLine("Partida cargada exitosamente!!!");
                        Console.WriteLine("---DATOS DE LA PARTIDA---");
                        Console.WriteLine($"Nombre del Personaje: {partida.Personaje.Datos.Nombre}");
                        Console.WriteLine($"Edad: {partida.Personaje.Datos.Edad}");
                        string fecha = partida.Personaje.Datos.Fechanac.ToString("dd MMMM yyyy");
                        Console.WriteLine($"Fecha de nacimiento: {fecha}");
                        partida.Personaje.MostrarCaracteristicas();
                        Console.WriteLine($"Cantidad de mazmorras conquistadas: {11 - partida.Mazmorras.Count}");
                        FuncionesPartida.Menu(partida.Personaje, partida.Mazmorras);
                    }
                }
                else
                {
                    Console.WriteLine("El nombre ingresado no coincide con una partida guardada.");
                }
            }

            break;

        case "3":
            HistorialJson.MostrarHistorialGanadores();
            break;

        case "4":
            Console.WriteLine("Gracias por jugar. ¡Hasta la próxima!");
            Console.WriteLine("Presione enter para salir...");
            Console.ReadKey();
            salir = true;
            break;

        default:
            Console.Clear();
            Console.WriteLine("Opción no válida. Por favor, selecciona una opción del 1 al 4.");
            break;

    }
}
