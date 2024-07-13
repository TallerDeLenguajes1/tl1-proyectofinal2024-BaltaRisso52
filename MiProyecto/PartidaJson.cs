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
            

            string rutaAbsolutaArchivo = Path.Combine(rutaAbsolutaCarpeta, nombreArchivo+".json");

            File.WriteAllText(rutaAbsolutaArchivo, jsonString);
            Console.WriteLine("Guardada con exito!!!");

        }

        public static PartidaJson CargarPartida(string nombreArchivo)
        {
            string rutaRelativa = @"..\Partidas Guardadas";
            string rutaAbsolutaCarpeta = Path.GetFullPath(rutaRelativa);
            string rutaAbsolutaArchivo = Path.Combine(rutaAbsolutaCarpeta, nombreArchivo+".json");

            string json = File.ReadAllText(rutaAbsolutaArchivo);

            PartidaJson partida = JsonSerializer.Deserialize<PartidaJson>(json);

            return partida;
        }





    }
}