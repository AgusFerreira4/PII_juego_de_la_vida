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

// Cumple SRP porque tiene la unica responsabilidad de leer y de parsear.
// Cumple expert porque es la parte del codigo con la que se puede parsear 1/0 en una matriz bool[,] sin necesidad de otras clases
public class LeerArchivo // Creo una clase para el snippet
{
    public  bool[,] Archivo(string url) // Declara una funcion de la que va a retornar un bool[,]
    {
        string content = File.ReadAllText(url); // Lee todo el archivo
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
        } return board; // retorna el tablero
    }   
}
/*
 * Cumple con SRP ya que su unica responsabilidad es seguir la logica del juego, seleccionando que celulas mueren, viven o reviven.
 * Tambien cumple con Expert porque contiene la información necesaria para llevar a cabo el proceso, la cual es el tablero que le
 * llega por parametros.
 *
 * Los unicos cambios que se aplicaron fue encapsularla en una clase y un metodo, el cual recibe la tabla por parametros.
 */
public class DesarrolloDeCelulas()
{
    public static bool[,] ControlarCelulas(bool[,] board)
    {
        bool[,] gameBoard = board;
        int boardWidth = gameBoard.GetLength(0);
        int boardHeight = gameBoard.GetLength(1);

        bool[,] cloneboard = new bool[boardWidth, boardHeight];
        for (int x = 0; x < boardWidth; x++)
        {
            for (int y = 0; y < boardHeight; y++)
            {
                int aliveNeighbors = 0;
                for (int i = x-1; i<=x+1;i++)
                {
                    for (int j = y-1;j<=y+1;j++)
                    {
                        if(i>=0 && i<boardWidth && j>=0 && j < boardHeight && gameBoard[i,j])
                        {
                            aliveNeighbors++;
                        }
                    }
                }
                if(gameBoard[x,y])
                {
                    aliveNeighbors--;
                }
                if (gameBoard[x,y] && aliveNeighbors < 2)
                {
                    //Celula muere por baja población
                    cloneboard[x,y] = false;
                }
                else if (gameBoard[x,y] && aliveNeighbors > 3)
                {
                    //Celula muere por sobrepoblación
                    cloneboard[x,y] = false;
                }
                else if (!gameBoard[x,y] && aliveNeighbors == 3)
                {
                    //Celula nace por reproducción
                    cloneboard[x,y] = true;
                }
                else
                {
                    //Celula mantiene el estado que tenía
                    cloneboard[x,y] = gameBoard[x,y];
                }
            }
        }
        gameBoard = cloneboard;
        return gameBoard;
    }
}