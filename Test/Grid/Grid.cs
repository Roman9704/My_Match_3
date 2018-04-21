using SFML.System;
using System.Collections.Generic;

namespace Test
{
    class Grid
    {
        public const int partitionWidth = 5;
        public const int coordinateShift = 5;

        public static Cell[,] cells = null;
        
        public Grid()
        {
            
        }

        public void Destroy()
        {
            for (int y = 0; y < World.AmountOfElements; y++)
                for (int x = 0; x < World.AmountOfElements; x++)
                {
                    cells[y, x].Destroy();
                    cells[y, x] = null;
                }
            cells = null;
        }

        public void generate_cells()
        {
            cells = new Cell[World.AmountOfElements, World.AmountOfElements];

            int X, Y;
            for (int y = 0; y < World.AmountOfElements; y++)
                for (int x = 0; x < World.AmountOfElements; x++)
                {
                    X = x * ((int)Element.elementSize + partitionWidth) + coordinateShift;
                    Y = y * ((int)Element.elementSize + partitionWidth) + coordinateShift;

                    cells[y, x] = new Cell(x, y, X, Y);
                }
        }

        public void bind_Elements_to_Cells()
        {
            for (int y = 0; y < World.AmountOfElements; y++)
                for (int x = 0; x < World.AmountOfElements; x++)
                {
                    cells[y, x].bind_element(World.Elements[y, x]);
                }
        }

        public static Vector2f get_position(int x, int y)
        {
            return cells[y, x].get_position();
        }

        public static float get_positionX(int x, int y)
        {
            return cells[y, x].get_positionX();
        }

        public static float get_positionY(int x, int y)
        {
            return cells[y, x].get_positionY();
        }
    }
}
