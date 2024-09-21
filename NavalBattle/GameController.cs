namespace NavalBattle
{
    public static class GameController
    {
        public static int width = 10;
        public static int height = 10;

        public static ConsoleColor firstPlayerColor = ConsoleColor.Yellow;
        public static ConsoleColor secondPlayerColor = ConsoleColor.Blue;

        public static bool firstPlayerTurn = true;

        public static Board FirstPlayerBoard
        {
            get
            {
                if(firstPlayerBoard == null)
                {
                    firstPlayerBoard = new(width, height);
                    firstPlayerBoard.color = firstPlayerColor;
                }

                return firstPlayerBoard;
            }
        }
        private static Board firstPlayerBoard;

        public static Board SecondPlayerBoard
        {
            get
            {
                if (secondPlayerBoard == null)
                {
                    secondPlayerBoard = new(width, height);
                    secondPlayerBoard.color = secondPlayerColor;
                }

                return secondPlayerBoard;
            }
        }
        private static Board secondPlayerBoard;

        public static void GameStart()
        {
            Turn();
        }

        private static void Turn()
        {
            (int, int) CellCortage = AwaitPlayerTurn();

            bool value = GetBoard(!firstPlayerTurn).SetHit(CellCortage.Item1, CellCortage.Item2);

            GetBoard(!firstPlayerTurn).VisualizeBoard();

            if (!GetBoard(!firstPlayerTurn).CheckBoardFill())
            {
                Console.WriteLine("\nИгра завершена");
                return;
            }

            Console.BackgroundColor = ConsoleColor.DarkYellow;
            if (!value)
            {
                firstPlayerTurn = !firstPlayerTurn;

                Console.WriteLine($" - Ход игрока {(firstPlayerTurn ? 1 : 2)}");
            }
            else
            {
                Console.WriteLine($" - Ход игрока {(firstPlayerTurn ? 1 : 2)} продолжается");
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();

            Turn();
        }

        private static (int, int) AwaitPlayerTurn()
        {
            int x = -1;
            int y = -1;

            do
            {
                Console.Write("Введите x-координату: ");
            } while (!int.TryParse(Console.ReadLine(), out y) || y - 1 < 0 || y - 1 > width);

            do
            {
                Console.Write("Введите y-координату: ");
            } while (!int.TryParse(Console.ReadLine(), out x) || x - 1 < 0 || x - 1 > width);

            return (x, y);
        }


        /// <summary>
        /// Возвращает первую доску на true, и вторую доску на false
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static Board GetBoard(bool value)
        {
            return (value) ? FirstPlayerBoard : SecondPlayerBoard;
        }
    }
}
