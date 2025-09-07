using System;
using System.IO;
namespace Ucu.Poo.GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
           
        }
    }
}
/*
 * Clase dedicada a obtener el tablero de donde sea que tenga que obtenerlo, en este caso un archivo.
 * Cumple con SRP porque su unica funcion es obtener el contenido necesario paar crear un archivo de donde deba,
 * si en un futuro cambia la forma de obtener el contenido para crear el archivo, por ejemplo se obtienen archivos de un gestor externo,
 * se cambia esta clase.
 * Cumple con Expert porque tiene la informacion necesaria para obtener el contenido del archivo, que en este caso es la url de donde esta.
 */
    public class ObtenerTablero
    {
        public string UrlDelArchivo { get;}
        public string Content { get; private set; }

        public ObtenerTablero(string unaDireccion)
        {
            UrlDelArchivo = unaDireccion;
        }

        public string ObtenerContenido()
        {
            Content = File.ReadAllText(UrlDelArchivo);
            
            return Content;
        }
        
    }
    
/*
 * Se crea la clase tablero en donde se porcesa el contenido del archivo, guardandolo en forma de tablero.
 * Cumple con expert ya que tiene la info necesaria para procesar el archivo, el cual se le brinda al construir la tabla.
 * Cumple con SRP ya que esta clase solo se encarga de crear el tablero, si en un futuro cambia ese metodo se cambia esta clase.
 */
    public class Tablero
    {
        public bool[,] Board { get; private set; }

        public Tablero(string content)
        {
            CrearTablero(content);
        }
        
        private void CrearTablero(string content)
        {
            string[] contentLines = content.Split('\n');
            Board = new bool[contentLines.Length, contentLines[0].Length];
            for (int y = 0; y < contentLines.Length; y++)
            {
                for (int x = 0; x < contentLines[y].Length; x++)
                {
                    if (contentLines[y][x] == '1')
                    {
                        Board[x, y] = true;
                    }
                }
            }
            
        }
    }
