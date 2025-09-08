using System;
using System.Text;
using System.Threading;


namespace Ucu.Poo.GameOfLife;

public static class PrintBoard
{
    public static void Print(bool[,] b, int width, int height)
    
        // SRP: PrintBoard solo se encarga de mostrar el tablero.
        // La lógica de evolución de las células está delegada a otra clase (DesarrolloDeCelulas),
        // manteniendo separadas las responsabilidades.

        // Expert (GRASP): PrintBoard recibe la matriz del tablero y conoce sus dimensiones,
        // por lo tanto es la clase experta en cómo recorrer e imprimir el estado de cada celda.
        // No depende de otras clases para saber cómo mostrar el tablero.

    {
        while (true)
        {
            Console.Clear();
            StringBuilder s = new StringBuilder();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (b[x, y])
                    {
                        s.Append("|X|");
                    }
                    else
                    {
                        s.Append("___");
                    }
                }

                s.Append("\n");
            }

            Console.WriteLine(s.ToString());
            b = DesarrolloDeCelulas.ControlarCelulas(b);
            Thread.Sleep(300);
        }
    }
}