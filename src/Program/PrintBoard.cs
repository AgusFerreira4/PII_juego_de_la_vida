using System;
using System.Text;
using System.Threading;


namespace Ucu.Poo.GameOfLife;

public static class PrintBoard
{
    public static void Print(bool[,] b, int width, int height)
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
            DesarrolloDeCelulas.ControlarCelulas(b);
            Thread.Sleep(300);
        }
    }
}