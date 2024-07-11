// See https://aka.ms/new-console-template for more information
using Protagonista;
using Monstruos;
using Mazmorras;
using Funciones;

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
            // CREAR EL PERSONAJE DEL JUGADOR
            Personaje protagonista = FuncionesVarias.CrearPersonaje();

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





