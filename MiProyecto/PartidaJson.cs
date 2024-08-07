using Protagonista;
using Mazmorras;
using System.Text.Json;

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
            try
            {
                PartidaJson partida = new PartidaJson(personaje, mazmorras);
                string jsonString = JsonSerializer.Serialize(partida);

                string rutaRelativa = @"..\Partidas Guardadas";
                string rutaAbsolutaCarpeta = Path.GetFullPath(rutaRelativa);

                // si el nombre del archivo está vacío lanzo la excepcion
                // y la agarro en el catch
                if (string.IsNullOrWhiteSpace(nombreArchivo))
                {
                    throw new Exception($"El nombre de archivo no puede estar vacío");
                }

                if (!Directory.Exists(rutaAbsolutaCarpeta))
                {
                    // Crear la carpeta
                    Directory.CreateDirectory(rutaAbsolutaCarpeta);
                }


                string rutaAbsolutaArchivo = Path.Combine(rutaAbsolutaCarpeta, nombreArchivo + ".json");

                File.WriteAllText(rutaAbsolutaArchivo, jsonString);
                Console.WriteLine("Guardada con exito!!!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ha ocurrido un error guardando la partida: {e.Message}");
            }


        }

        public static PartidaJson CargarPartida(string nombreArchivo)
        {
            try
            {
                string rutaRelativa = @"..\Partidas Guardadas";
                string rutaAbsolutaCarpeta = Path.GetFullPath(rutaRelativa);
                string rutaAbsolutaArchivo = Path.Combine(rutaAbsolutaCarpeta, nombreArchivo + ".json");

                string json = File.ReadAllText(rutaAbsolutaArchivo);

                PartidaJson partida = JsonSerializer.Deserialize<PartidaJson>(json);

                return partida;
            }
            catch (Exception e)
            {
                System.Console.WriteLine($"Ha ocurrido un error leyendo la partida: {e.Message}");
                return null;
            }
        }

        public static bool MostrarNombreDePartidasGuardadas()
        {

            // Ruta de la carpeta que deseas explorar
            string rutaRelativa = @"..\Partidas Guardadas";


            try
            {
                string rutaAbsolutaCarpeta = Path.GetFullPath(rutaRelativa);

                if (Directory.Exists(rutaAbsolutaCarpeta))
                {
                    // Obtener todos los nombres de archivo en la carpeta
                    string[] archivos = Directory.GetFiles(rutaAbsolutaCarpeta);

                    // Mostrar los nombres de los archivos
                    Console.WriteLine($"Partidas Guardadas:");
                    int n = 1;
                    foreach (string archivo in archivos)
                    {

                        Console.WriteLine($"{n}: "+ Path.GetFileNameWithoutExtension(archivo)); // Obtener solo el nombre del archivo sin la extensión
                        n++;
                    }
                    return true;
                }else
                {
                    Console.WriteLine("Aun no hay partidas guardadas");
                    return false;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer archivos: {ex.Message}");
                return false;
            }


        }

    }
}