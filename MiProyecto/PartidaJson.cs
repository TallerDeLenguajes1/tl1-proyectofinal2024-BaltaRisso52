using Protagonista;
using Mazmorras;
using System.Text.Json;
using System.Security.Cryptography.X509Certificates;

namespace Partida
{
    class PartidaJson
    {
        private Personaje personaje;
        private List<Mazmorra> mazmorras;

        public PartidaJson(Personaje personaje, List<Mazmorra> mazmorras)
        {
            this.personaje = personaje;
            this.mazmorras = mazmorras;
        }

        public Personaje Personaje { get => personaje; set => personaje = value; }
        public List<Mazmorra> Mazmorras { get => mazmorras; set => mazmorras = value; }

        public static void GuardarPartida(Personaje personaje, List<Mazmorra> mazmorras, string nombreArchivo)
        {

            PartidaJson partida = new PartidaJson(personaje, mazmorras);
            string jsonString = JsonSerializer.Serialize(partida);

            string rutaRelativa = @"..\Partidas Guardadas";
            string rutaAbsolutaCarpeta = Path.GetFullPath(rutaRelativa);

            if (!Directory.Exists(rutaAbsolutaCarpeta))
            {
                try
                {
                    // Crear la carpeta
                    Directory.CreateDirectory(rutaAbsolutaCarpeta);

                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error al crear la carpeta: {e.Message}");
                }
            }


            string rutaAbsolutaArchivo = Path.Combine(rutaAbsolutaCarpeta, nombreArchivo + ".json");

            File.WriteAllText(rutaAbsolutaArchivo, jsonString);
            Console.WriteLine("Guardada con exito!!!");

        }

        public static PartidaJson CargarPartida(string nombreArchivo)
        {
            string rutaRelativa = @"..\Partidas Guardadas";
            string rutaAbsolutaCarpeta = Path.GetFullPath(rutaRelativa);
            string rutaAbsolutaArchivo = Path.Combine(rutaAbsolutaCarpeta, nombreArchivo + ".json");

            string json = File.ReadAllText(rutaAbsolutaArchivo);

            PartidaJson partida = JsonSerializer.Deserialize<PartidaJson>(json);

            return partida;
        }

        public static void AgregarHistorialDeGanadores(Personaje personaje)
        {

            string rutaRelativa = @"..\Historial de Ganadores";
            string rutaAbsolutaCarpeta = Path.GetFullPath(rutaRelativa);

            if (!Directory.Exists(rutaAbsolutaCarpeta))
            {
                try
                {
                    // Crear la carpeta
                    Directory.CreateDirectory(rutaAbsolutaCarpeta);

                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error al crear la carpeta: {e.Message}");
                }
            }

            string rutaAbsolutaArchivo = Path.Combine(rutaAbsolutaCarpeta, "ListaGanadores.json");

            if (!File.Exists(rutaAbsolutaArchivo))
            {
                List<Personaje> personajes = new List<Personaje>();
                personajes.Add(personaje);

                string jsonString = JsonSerializer.Serialize(personajes);

                File.WriteAllText(rutaAbsolutaArchivo, jsonString);
                Console.WriteLine("Se agrego al historial de ganadores con exito!!");


            }
            else
            {
                string json = File.ReadAllText(rutaAbsolutaArchivo);

                List<Personaje> personajes = JsonSerializer.Deserialize<List<Personaje>>(json);
                personajes.Add(personaje);

                string jsonString = JsonSerializer.Serialize(personajes);

                File.WriteAllText(rutaAbsolutaArchivo, jsonString);
                Console.WriteLine("Se agrego al historial de ganadores con exito!!");
            }

        }

        public static void MostrarHistorialGanadores()
        {

            string rutaRelativa = @"..\Historial de Ganadores";
            string rutaAbsolutaCarpeta = Path.GetFullPath(rutaRelativa);
            string rutaAbsolutaArchivo = Path.Combine(rutaAbsolutaCarpeta, "ListaGanadores.json");

            Console.Clear();
            if (File.Exists(rutaAbsolutaArchivo))
            {
                string json = File.ReadAllText(rutaAbsolutaArchivo);

                List<Personaje> personajes = JsonSerializer.Deserialize<List<Personaje>>(json);
                int n = 1;
                foreach (var item in personajes)
                {
                    
                    Console.WriteLine($"--------{n}--------");
                    Console.WriteLine($"Nombre del personaje: {item.Nombre}");
                    item.MostrarCaracteristicas();
                    n++;
                }
            }else
            {
                Console.WriteLine("Aun no hay ganadores en el historial");
            }


        }




    }
}