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
                // asi como tu mamá me agarra esta
                if (string.IsNullOrWhiteSpace(nombreArchivo))
                {
                    throw new Exception($"el nombre de archivo no puede estar vacío");
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
                System.Console.WriteLine($"Ha ocurrido un error guardando la partida: {e.Message}");
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
        
    }
}