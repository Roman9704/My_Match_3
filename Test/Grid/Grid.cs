using SFML.System;
using System.Collections.Generic;

namespace Test
{
    class Grid
    {
        public const int PARTITION_WIDTH = 5;
        public const int COORDINATE_SHIFT = 5;

        public static Cell[,] cells = null;
        
        public Grid()
        {
            
        }

        public void Destroy()
        {
            for (int y = 0; y < World.AMOUNT_OF_ELEMENTS; y++)
                for (int x = 0; x < World.AMOUNT_OF_ELEMENTS; x++)
                    cells[y, x].Destroy();

            cells = null;
        }

        public void generate_Cells()
        {
            cells = new Cell[World.AMOUNT_OF_ELEMENTS, World.AMOUNT_OF_ELEMENTS];

            int X, Y;
            for (int y = 0; y < World.AMOUNT_OF_ELEMENTS; y++)
                for (int x = 0; x < World.AMOUNT_OF_ELEMENTS; x++)
                {
                    X = x * ((int)Element.ELEMENT_SIZE + PARTITION_WIDTH) + COORDINATE_SHIFT;
                    Y = y * ((int)Element.ELEMENT_SIZE + PARTITION_WIDTH) + COORDINATE_SHIFT;

                    cells[y, x] = new Cell(x, y, X, Y);
                }
        }

        public void bind_Elements_to_Cells()
        {
            for (int y = 0; y < World.AMOUNT_OF_ELEMENTS; y++)
                for (int x = 0; x < World.AMOUNT_OF_ELEMENTS; x++)
                {
                    cells[y, x].bind_Element(World.elements[y, x]);
                }
        }

        public static Vector2f get_Position(int x, int y)
        {
            return cells[y, x].get_Position();
        }

        public static float get_PositionX(int x, int y)
        {
            return cells[y, x].get_PositionX();
        }

        public static float get_PositionY(int x, int y)
        {
            return cells[y, x].get_PositionY();
        }
    }
}
