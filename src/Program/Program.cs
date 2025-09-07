using System;
using System.IO;
using System.Text;
using System.Threading;


namespace Ucu.Poo.GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1️ Carga el tablero desde el archivo board.txt
            LecturaDeArchivo archivoCargado = new LecturaDeArchivo();
            bool[,] tableroInicial = archivoCargado.LoadBoard("board.txt"); // archivo en la misma carpeta que el ejecutable

            // 2️ Inicializa la lógica del juego
            LogicaDelJuego logicaDelJuego = new LogicaDelJuego(tableroInicial);

            // 3️ Crear el impresor de tablero
            BoardPrinter impresion = new BoardPrinter(logicaDelJuego);

            // 4 Iniciar bucle de impresión y actualización
            impresion.ImprimirBucle();        }
    }

    
    // Creación de la clase Lectura de archivo
    class LecturaDeArchivo
    {
        // este constructor toma la ubicación de board.txt. Se puede asignar otros board.txt a futuro
        public bool[,] LoadBoard(string url)
        {
            string content = File.ReadAllText(url);
            string[] contentLines = content.Split('\n');
            bool[,] board = new bool[contentLines.Length, contentLines[0].Length];
            for (int y = 0; y < contentLines.Length; y++)
            {
                for (int x = 0; x < contentLines[y].Length; x++)
                {
                    if (contentLines[y][x] == '1')
                    {
                        board[x, y] = true;
                    }
                }
            }
            // retorna un board para usar en la clase LogicaDelJuego
            return board;
        }
    }

    class LogicaDelJuego
    {
        private bool[,] gameBoard;

        // Constructor que recibe un tablero inicial
        
        public LogicaDelJuego(bool[,] initialBoard)
        {
            gameBoard = initialBoard;
        }

        // Método para calcular la siguiente generación
        public void ProximaGeneración()
        {
            int boardWidth = gameBoard.GetLength(0);
            int boardHeight = gameBoard.GetLength(1);
            bool[,] cloneBoard = new bool[boardWidth, boardHeight];

            for (int x = 0; x < boardWidth; x++)
            {
                for (int y = 0; y < boardHeight; y++)
                {
                    int aliveNeighbors = 0;
                    for (int i = x-1; i <= x+1; i++)
                    {
                        for (int j = y-1; j <= y+1; j++)
                        {
                            if (i >= 0 && i < boardWidth && j >= 0 && j < boardHeight && gameBoard[i,j])
                            {
                                aliveNeighbors++;
                            }
                        }
                    }

                    if (gameBoard[x,y]) aliveNeighbors--;

                    if (gameBoard[x,y] && aliveNeighbors < 2) cloneBoard[x,y] = false;
                    else if (gameBoard[x,y] && aliveNeighbors > 3) cloneBoard[x,y] = false;
                    else if (!gameBoard[x,y] && aliveNeighbors == 3) cloneBoard[x,y] = true;
                    else cloneBoard[x,y] = gameBoard[x,y];
                }
            }

            gameBoard = cloneBoard;
        }

        // Método para obtener el tablero actual
        public bool[,] ObtenerTablero()
        {
            return gameBoard;
        }
    }
    
    class BoardPrinter
    {
        private LogicaDelJuego gameLogic;

        public BoardPrinter(LogicaDelJuego logic)
        {
            gameLogic = logic;
        }

        public void ImprimirBucle()
        {
            while (true)
            {
                Console.Clear();
                bool[,] b = gameLogic.ObtenerTablero();
                int width = b.GetLength(0);
                int height = b.GetLength(1);
                StringBuilder s = new StringBuilder();

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        if (b[x, y])
                            s.Append("|X|");
                        else
                            s.Append("___");
                    }
                    s.Append("\n");
                }

                Console.WriteLine(s.ToString());

                // Avanzar a la siguiente generación
                gameLogic.ProximaGeneración();

                Thread.Sleep(300);
            }
        }
    }


}
    
    
