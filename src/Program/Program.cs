using System;
using System.IO;
namespace Ucu.Poo.GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            LeerArchivo archivo = new LeerArchivo();
            bool[,] tableroInicial = archivo.Archivo("board.txt");
            int width = tableroInicial.GetLength(0);
            int height = tableroInicial.GetLength(1);
            PrintBoard.Print(tableroInicial, width, height);
        }
    }
}
