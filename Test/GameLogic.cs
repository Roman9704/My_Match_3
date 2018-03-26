using System.Collections.Generic;
using SFML.Window;
using SFML.Graphics;
using SFML.System;
using System;

namespace Test
{
    class GameLogic
    {
        int AMOUNT_OF_ELEMENTS;
        bool AreElementsMove = false;
        bool DoEmptyCellsExist = false;
        public static int SCORE = 0;

        List<List<Cell>> VerticalChainCells = null;
        List<List<Cell>> HorizontalChainCells = null;
        List<Cell> EmptyCells = null;
        List<Cell> NotEmptyCells = null;
        Cell[,] cells = null;

        PlayerActions playerActions = null;
        World world = null;

        public GameLogic(Grid grid, World world)
        {
            AMOUNT_OF_ELEMENTS = World.AMOUNT_OF_ELEMENTS;

            SCORE = 0;

            set_Cells(grid);
            this.world = world;

            VerticalChainCells = new List<List<Cell>>();
            for (int i = 0; i < AMOUNT_OF_ELEMENTS; i++)
            {
                VerticalChainCells.Add(new List<Cell>());
            }

            HorizontalChainCells = new List<List<Cell>>();
            for (int i = 0; i < AMOUNT_OF_ELEMENTS; i++)
            {
                HorizontalChainCells.Add(new List<Cell>());
            }

            EmptyCells = new List<Cell>();
            NotEmptyCells = new List<Cell>();


            playerActions = new PlayerActions(this, world);
        }

        public void Update()
        {
            update_AreElementsMove();

            if (AreElementsMove == false)
            {
                update_DoEmptyCellsExist();

                if (DoEmptyCellsExist)
                {
                    move_Cells_to_Holes();
                }
                else
                {
                    check_Cells_on_Chains();

                    update_DoEmptyCellsExist();
                }
            }

            playerActions.Update();
        }

        private void update_DoEmptyCellsExist()
        {
            DoEmptyCellsExist = false;

            for (int y = 0; y < AMOUNT_OF_ELEMENTS; y++)
            {
                for (int x = 0; x < AMOUNT_OF_ELEMENTS; x++)
                {
                    if (cells[y, x].get_Element() == null)
                    {
                        DoEmptyCellsExist = true; 
                        break;
                    }
                }
                if (DoEmptyCellsExist) { break; }
            }
        }

        private void move_Cells_to_Holes()
        {
            for (int x = 0; x < AMOUNT_OF_ELEMENTS; x++)
            {
                move_Cells_to_Holes_on_Vertical(x);
            }
        }

        private void move_Cells_to_Holes_on_Vertical(int x)
        {
            EmptyCells.Clear();
            NotEmptyCells.Clear();

            for (int y =  0; y < AMOUNT_OF_ELEMENTS; y++) // В конце списка будут нижние элементы
            {
                if (cells[y, x].get_Element() == null)
                {
                    EmptyCells.Add(cells[y, x]);
                }
                else
                {
                    NotEmptyCells.Add(cells[y, x]);
                }
            }
            if (EmptyCells.Count > 0)
            {
                for (int i = NotEmptyCells.Count - 1; i >= 0; i--)
                    {
                        if (EmptyCells[EmptyCells.Count - 1].get_IndicesY() > NotEmptyCells[i].get_IndicesY())
                        {
                            NotEmptyCells[i].get_Element().set_newPosition(EmptyCells[EmptyCells.Count - 1].get_Position());
                            NotEmptyCells[i].get_Element().set_MoveType(MoveType.DOWN);

                            EmptyCells[EmptyCells.Count - 1].change_bind_Element(NotEmptyCells[i].get_Element());

                            NotEmptyCells[i].unbind_Element();

                            world.swap_Elements(NotEmptyCells[i].get_IndicesX(), NotEmptyCells[i].get_IndicesY(), EmptyCells[EmptyCells.Count - 1].get_IndicesX(), EmptyCells[EmptyCells.Count - 1].get_IndicesY());

                            EmptyCells.Remove(EmptyCells[EmptyCells.Count - 1]);
                            break;
                        }
                    }
                if (EmptyCells.Count > 0)
                {
                    if (cells[0, x].get_Element() == null)
                    {
                        world.spawn_Element(cells[0, x]);
                    }
                    move_Cells_to_Holes_on_Vertical(x);
                }
            }
        }

        private void check_Cells_on_Chains()
        {
            if (AreElementsMove != true)
            {
                for (int y = 0; y < AMOUNT_OF_ELEMENTS; y++)
                {
                    check_Horizontal_on_Chains(y);
                }
                for (int x = 0; x < AMOUNT_OF_ELEMENTS; x++)
                {
                    check_Vertical_on_Chains(x);
                }

                delete_Cells_in_ChainCells();
            }
        }

        private void check_Vertical_on_Chains(int x)
        {
            for (int y = AMOUNT_OF_ELEMENTS - 1; y > 1; y--)
            {
                if (cells[y, x].get_ElementType() != ElementType.NONE)
                {
                    if (cells[y, x].get_ElementType() == cells[y - 1, x].get_ElementType() && cells[y, x].get_ElementType() == cells[y - 2, x].get_ElementType())
                    {
                        if (!VerticalChainCells[x].Contains(cells[y, x]))
                        {
                            VerticalChainCells[x].Add(cells[y, x]);
                        }
                        if (!VerticalChainCells[x].Contains(cells[y - 1, x]))
                        {
                            VerticalChainCells[x].Add(cells[y - 1, x]);
                        }
                        VerticalChainCells[x].Add(cells[y - 2, x]);
                    }
                }
            }
        }

        private void check_Horizontal_on_Chains(int y)
        {
            for (int x = AMOUNT_OF_ELEMENTS - 1; x > 1; x--)
            {
                if (cells[y, x].get_ElementType() != ElementType.NONE)
                {
                    if (cells[y, x].get_ElementType() == cells[y, x - 1].get_ElementType() && cells[y, x].get_ElementType() == cells[y, x - 2].get_ElementType())
                    {
                        if (!HorizontalChainCells[y].Contains(cells[y, x]))
                        {
                            HorizontalChainCells[y].Add(cells[y, x]);
                        }
                        if (!HorizontalChainCells[y].Contains(cells[y, x - 1]))
                        {
                            HorizontalChainCells[y].Add(cells[y, x - 1]);
                        }
                        HorizontalChainCells[y].Add(cells[y, x - 2]);
                    }
                }
            }
        }

        private void delete_Cells_in_ChainCells()
        {
            for (int i = VerticalChainCells.Count - 1; i >= 0 ; i--)
            {
                for (int j = VerticalChainCells[i].Count - 1; j >= 0; j--)
                {
                    if (VerticalChainCells[i][j].get_Element() != null)
                    {
                        SCORE += VerticalChainCells[i][j].get_Element().get_POINTS();
                        VerticalChainCells[i][j].unbind_Element();
                        world.delete_Element(VerticalChainCells[i][j].get_IndicesX(), VerticalChainCells[i][j].get_IndicesY());
                    }
                }
                VerticalChainCells[i].Clear();
            }

            for (int i = HorizontalChainCells.Count - 1; i >= 0; i--)
            {
                for (int j = HorizontalChainCells[i].Count - 1; j >= 0; j--)
                {
                    if (HorizontalChainCells[i][j].get_Element() != null)
                    {
                        SCORE += HorizontalChainCells[i][j].get_Element().get_POINTS();
                        HorizontalChainCells[i][j].unbind_Element();
                        world.delete_Element(HorizontalChainCells[i][j].get_IndicesX(), HorizontalChainCells[i][j].get_IndicesY());
                    }
                }
                HorizontalChainCells[i].Clear();
            }
        }

        private void update_AreElementsMove()
        {
            AreElementsMove = false;

            for (int y = 0; y < AMOUNT_OF_ELEMENTS; y++)
            {
                for (int x = 0; x < AMOUNT_OF_ELEMENTS; x++)
                {
                    if (cells[y, x].get_Element() == null) { continue; }

                    if (cells[y, x].get_Element().get_MoveType() != MoveType.NONE)
                    {
                        AreElementsMove = true;
                        break;
                    }
                }
                if (AreElementsMove) { break; }
            }
        }

        public bool get_DoEmptyCellsExist()
        {
            return DoEmptyCellsExist;
        }

        public bool get_AreElementsMove()
        {
            return AreElementsMove;
        }

        public Cell[,] get_Cells()
        {
            return cells;
        }

        private void set_Cells(Cell[,] cells)
        {
            this.cells = cells;
        }

        private void set_Cells(Grid grid)
        {
            set_Cells(grid.get_Cells());
        }

        public int get_SCORE()
        {
            return SCORE;
        }

        public PlayerActions get_PlayerActions()
        {
            return playerActions;
        }
    }
}
