namespace NavalBattle
{
    public class Board
    {
        public float ShipSpawnChance = 0.1f;

        public Cell[,] BoardMatrix { get; private set; }

        public ConsoleColor color;

        /// <summary>
        /// Метод возвращает true, если игрок может продолжать ход, и false если игрок промахнулся
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool SetHit(int x, int y)
        {
            x = x - 1;
            y = y - 1;
            Cell cell = BoardMatrix[x, y];

            switch (cell.Type)
            {
                case CellType.empty:
                {
                    cell.SetCellType(CellType.destroy);
                    return false;
                }
                case CellType.ship:
                {
                    cell.SetCellType(CellType.hit);
                    return true;
                }
                case CellType.hit:
                {
                    Console.WriteLine("Совершён ход в подбитую ранее ячейку");
                    return true;
                }
                case CellType.destroy:
                {
                    Console.WriteLine("Совершён ход в уничтоженную ранее ячейку");
                    return true;
                }
                default:
                return false;
            }
        }

        public bool CheckBoardFill()
        {
            return BoardMatrix
                .Cast<Cell>()
                .Where(cell => cell.Type == CellType.ship)
                .Count() > 0;
        }

        public void VisualizeBoard()
        {
            Console.ForegroundColor = color;

            Console.WriteLine();

            for (int i = 0; i < BoardMatrix.GetLength(1); i++)
                Console.Write(" —");
            Console.WriteLine();

            for (int x = 0; x < BoardMatrix.GetLength(0); x++)
            {
                Console.Write("|");
                for (int y = 0; y < BoardMatrix.GetLength(1); y++)
                {
                    Console.Write(BoardMatrix[x, y].CellVisual);
                }
                Console.Write("|");

                Console.WriteLine();
            }

            for (int i = 0; i < BoardMatrix.GetLength(1); i++)
                Console.Write(" —");
            Console.WriteLine("\n");

            Console.ResetColor();
        }

        public Board(int boardWidth, int boardHeight)
        {
            BoardMatrix = new Cell[boardWidth, boardHeight];

            float chance = (float)GameController.width * (float)GameController.height * ShipSpawnChance;

            for (int i = 0; i < BoardMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < BoardMatrix.GetLength(1); j++)
                {
                    BoardMatrix[i, j] = new Cell();
                    if (new Random().Next(0, 100) < chance)
                        BoardMatrix[i, j].SetCellType(CellType.ship);
                }
            }
        }
    }
}
