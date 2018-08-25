using SFML.System;
using Pulse.World;

namespace Pulse.Grid
{
    public class GameGrid
    {
        public const int PartitionWidth = 5;
        public const int CoordinateShift = 5;

        public static Cell[,] Cells = null;
        
        public GameGrid()
        {
            
        }

        public void Destroy()
        {
            for (int y = 0; y < GameWorld.AmountOfElements; y++)
                for (int x = 0; x < GameWorld.AmountOfElements; x++)
                {
                    Cells[y, x].Destroy();
                    Cells[y, x] = null;
                }
            Cells = null;
        }

        public void GenerateCells()
        {
            Cells = new Cell[GameWorld.AmountOfElements, GameWorld.AmountOfElements];

            int X, Y;
            for (int y = 0; y < GameWorld.AmountOfElements; y++)
                for (int x = 0; x < GameWorld.AmountOfElements; x++)
                {
                    X = x * ((int)Element.ElementSize + PartitionWidth) + CoordinateShift;
                    Y = y * ((int)Element.ElementSize + PartitionWidth) + CoordinateShift;

                    Cells[y, x] = new Cell(x, y, X, Y);
                }
        }

        public void BindElementsToCells()
        {
            for (int y = 0; y < GameWorld.AmountOfElements; y++)
                for (int x = 0; x < GameWorld.AmountOfElements; x++)
                {
                    Cells[y, x].BindElement(GameWorld.Elements[y, x]);
                }
        }

        public static Vector2f get_position(int x, int y)
        {
            return Cells[y, x].Position;
        }
    }
}
