using SFML.System;
using System.Collections.Generic;

namespace Test
{
    class Grid
    {
        public const int PARTITION_WIDTH = 5;
        public const int COORDINATE_SHIFT = 5;

        int AMOUNT_OF_ELEMENTS;
        int ELEMENT_SIZE;

        Cell[,] cells = null;
        Element[,] elements = null;
        
        public Grid()
        {
            AMOUNT_OF_ELEMENTS = World.AMOUNT_OF_ELEMENTS;
            ELEMENT_SIZE = 60;
            cells = new Cell[AMOUNT_OF_ELEMENTS, AMOUNT_OF_ELEMENTS];
        }

        public void generate_Cells(GameLogic gameLogic)
        {
            int X, Y;
            for (int y = 0; y < AMOUNT_OF_ELEMENTS; y++)
                for (int x = 0; x < AMOUNT_OF_ELEMENTS; x++)
                {
                    X = x * (ELEMENT_SIZE + PARTITION_WIDTH) + COORDINATE_SHIFT;
                    Y = y * (ELEMENT_SIZE + PARTITION_WIDTH) + COORDINATE_SHIFT;

                    cells[y, x] = new Cell(x, y, X, Y, gameLogic);
                }
        }

        public void bind_Elements_to_Cells(World world)
        {
            set_Elements(world);

            for (int y = 0; y < AMOUNT_OF_ELEMENTS; y++)
                for (int x = 0; x < AMOUNT_OF_ELEMENTS; x++)
                {
                    cells[y, x].bind_Element(elements[y, x]);
                }
        }

        private void set_Elements(Element[,] elements)
        {
            this.elements = elements;
        }

        private void set_Elements(World world)
        {
            set_Elements(world.get_Elements());
        }

        public Vector2f get_Position(int x, int y)
        {
            return cells[y, x].get_Position();
        }

        public float get_PositionX(int x, int y)
        {
            return cells[y, x].get_PositionX();
        }

        public float get_PositionY(int x, int y)
        {
            return cells[y, x].get_PositionY();
        }

        public Cell[,] get_Cells()
        {
            return cells;
        }
    }
}
