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
// Cumple SRP porque tiene la unica responsabilidad de leer y de parsear.
// Cumple expert porque es la parte del codigo con la que se puede parsear 1/0 en una matriz bool[,] sin necesidad de otras clases
public class LeerArchivo
{
    public  bool[,] Archivo(string url)
    {
        string content = File.ReadAllText(url);
        string[] contentLines = content.Split('\n');
        bool[,] board = new bool[contentLines.Length, contentLines[0].Length];
        for (int y=0; y<contentLines.Length;y++)
        {
            for (int x=0; x<contentLines[y].Length; x++)
            {
                if(contentLines[y][x]=='1')
                {
                    board[x,y]=true;
                }
            }
        } return board;
    }   
}