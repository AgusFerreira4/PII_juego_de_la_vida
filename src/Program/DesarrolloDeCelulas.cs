namespace Ucu.Poo.GameOfLife;

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