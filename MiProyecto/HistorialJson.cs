using System.Text.Json;
using Protagonista;

namespace Historial
{
    public class HistorialJson
    {
        public static void AgregarHistorialDeGanadores(Personaje personaje)
        {
            string rutaRelativa = @"..\Historial de Ganadores";

            try
            {
                string rutaAbsolutaCarpeta = Path.GetFullPath(rutaRelativa);

                if (!Directory.Exists(rutaAbsolutaCarpeta))
                {
                    // Crear la carpeta
                    Directory.CreateDirectory(rutaAbsolutaCarpeta);
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
            catch (Exception e)
            {
                System.Console.WriteLine($"Ha ocurrido un error agregando un ganador al historial: {e.Message}");
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
                try
                {
                    string json = File.ReadAllText(rutaAbsolutaArchivo);

                    List<Personaje> personajes = JsonSerializer.Deserialize<List<Personaje>>(json);
                    
                    if (!personajes.Any())
                    {
                        Console.WriteLine("Aun no hay ganadores en el historial");
                    }
                    else
                    {
                        int n = 1;
                        foreach (var item in personajes)
                        {
                            
                            Console.WriteLine($"--------{n}--------");
                            Console.WriteLine($"Nombre del personaje: {item.Datos.Nombre}");
                            item.MostrarCaracteristicas();
                            n++;
                        }
                    }
                }
                catch (Exception e)
                {
                    System.Console.WriteLine($"Ha ocurrido un error leyendo el historial: {e.Message}");
                }
            }
            else
            {
                Console.WriteLine("Aun no hay ganadores en el historial");
            }


        }
    }
}