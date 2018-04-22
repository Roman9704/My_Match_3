using SFML.System;
using System.Collections.Generic;

namespace Test.Grid
{
    class GameGrid
    {
        public const int PartitionWidth = 5;
        public const int CoordinateShift = 5;

        public static Cell[,] Cells = null;
        
        public GameGrid()
        {
            
        }

        public void Destroy()
        {
            for (int y = 0; y < World.AmountOfElements; y++)
                for (int x = 0; x < World.AmountOfElements; x++)
                {
                    Cells[y, x].Destroy();
                    Cells[y, x] = null;
                }
            Cells = null;
        }

        public void generateCells()
        {
            Cells = new Cell[World.AmountOfElements, World.AmountOfElements];

            int X, Y;
            for (int y = 0; y < World.AmountOfElements; y++)
                for (int x = 0; x < World.AmountOfElements; x++)
                {
                    X = x * ((int)Element.ElementSize + PartitionWidth) + CoordinateShift;
                    Y = y * ((int)Element.ElementSize + PartitionWidth) + CoordinateShift;

                    Cells[y, x] = new Cell(x, y, X, Y);
                }
        }

        public void bindElementsToCells()
        {
            for (int y = 0; y < World.AmountOfElements; y++)
                for (int x = 0; x < World.AmountOfElements; x++)
                {
                    Cells[y, x].bind_element(World.Elements[y, x]);
                }
        }

        public static Vector2f get_position(int x, int y)
        {
            return Cells[y, x].get_position();
        }

        public static float get_positionX(int x, int y)
        {
            return Cells[y, x].get_positionX();
        }

        public static float get_positionY(int x, int y)
        {
            return Cells[y, x].get_positionY();
        }
    }
}
