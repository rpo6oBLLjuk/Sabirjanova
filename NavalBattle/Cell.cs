namespace NavalBattle
{
    public enum CellType
    {
        empty,
        ship,
        hit,
        destroy
    }

    public class Cell
    {
        public CellType Type { get; private set; }

        public string CellVisual { get; private set; }

        public void SetCellType(CellType type)
        {
            Type = type;

            switch (type)
            {
                case CellType.empty:
                {
                    CellVisual = "🗌 ";
                    break;
                }

                case CellType.ship:
                {
                    CellVisual = "𓊝 ";
                    break;
                }

                case CellType.hit:
                {
                    CellVisual = "💥";
                    break;
                }

                case CellType.destroy:
                {
                    CellVisual = "~ ";
                    break;
                }
            }
        }

        public Cell()
        {
            SetCellType(CellType.empty);
        }
    }
}
