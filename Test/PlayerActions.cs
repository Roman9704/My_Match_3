using System.Collections.Generic;

namespace Test
{
    class PlayerActions
    {
        bool ActionOccurred = false;

        public static List<Cell> ChosenCells = null;

        public PlayerActions()
        {
            
        }

        public void Update()
        {
            update_ChosenCells();
        }

        public void Generate()
        {
            ChosenCells = new List<Cell>();
        }

        public void Destroy()
        {
            ChosenCells.Clear();
            ChosenCells = null;
        }

        // Обновление списка выбранных элементов
        private void update_ChosenCells() 
        {
            if (GameLogic.AreElementsMove == false && GameLogic.DoEmptyCellsExist == false && ActionOccurred == false)
            {
                if (ChosenCells.Count > 1)
                {
                    if (ChosenCells[0].get_IndicesX() == ChosenCells[1].get_IndicesX()) // Элементы на одной вертикали
                    {
                        if (ChosenCells[0].get_IndicesY() - ChosenCells[1].get_IndicesY() == 1) // нулевой ниже, чем первый
                        { // меняем элементы местами по вертикали и чекаем после их перемещения
                            swap_ChosenElements(MoveType.UP, MoveType.DOWN);
                            rebind_ChosenElements_in_Cells();
                            ActionOccurred = true;
                        }
                        else
                        {
                            if (ChosenCells[0].get_IndicesY() - ChosenCells[1].get_IndicesY() == -1) // нулевой выше, чем первый
                            { // меняем элементы местами по вертикали и чекаем после их перемещения
                                swap_ChosenElements(MoveType.DOWN, MoveType.UP);
                                rebind_ChosenElements_in_Cells();
                                ActionOccurred = true;
                            }
                            else
                            {
                                unchosed_and_remove_ChosenCell(1);
                            }
                        }
                    }
                    else
                    {
                        if (ChosenCells[0].get_IndicesY() == ChosenCells[1].get_IndicesY()) // Элементы на одной горизонтали
                        {
                            if (ChosenCells[0].get_IndicesX() - ChosenCells[1].get_IndicesX() == 1) // нулевой правее, чем первый
                            { // меняем элементы местами по вертикали и чекаем после их перемещения
                                swap_ChosenElements(MoveType.LEFT, MoveType.RIGHT);
                                rebind_ChosenElements_in_Cells();
                                ActionOccurred = true;
                            }
                            else
                            {
                                if (ChosenCells[0].get_IndicesX() - ChosenCells[1].get_IndicesX() == -1) // нулевой левее, чем первый
                                { // меняем элементы местами по вертикали и чекаем после их перемещения
                                    swap_ChosenElements(MoveType.RIGHT, MoveType.LEFT);
                                    rebind_ChosenElements_in_Cells();
                                    ActionOccurred = true;
                                }
                                else
                                {
                                    unchosed_and_remove_ChosenCell(1);
                                }
                            }
                        }
                        else
                        {
                            unchosed_and_remove_ChosenCell(1);
                        }
                    }
                }

            }
            else
            {
                if (ActionOccurred && GameLogic.AreElementsMove == false)
                {
                    if (GameLogic.DoEmptyCellsExist)
                    {
                        unchosed_and_remove_ChosenCell(1);
                        unchosed_and_remove_ChosenCell(0);
                        ActionOccurred = false;
                    }
                    else
                    {
                        unswap_Cells_and_Elements();
                        unchosed_and_remove_ChosenCell(1);
                        unchosed_and_remove_ChosenCell(0);
                        ActionOccurred = false;
                    }
                }
            }
        }

        private void unswap_Cells_and_Elements()
        {
            if (ChosenCells[0].get_IndicesX() == ChosenCells[1].get_IndicesX()) // Элементы на одной вертикали
            {
                if (ChosenCells[0].get_IndicesY() > ChosenCells[1].get_IndicesY()) // нулевой ниже, чем первый
                {
                    swap_ChosenElements(MoveType.UP, MoveType.DOWN);
                    rebind_ChosenElements_in_Cells();
                }
                else // нулевой выше, чем первый
                {
                    swap_ChosenElements(MoveType.DOWN, MoveType.UP);
                    rebind_ChosenElements_in_Cells();
                }
            }
            else // Элементы на одной горизонтали
            {
                if (ChosenCells[0].get_IndicesX() > ChosenCells[1].get_IndicesX()) // нулевой правее, чем первый
                {
                    swap_ChosenElements(MoveType.LEFT, MoveType.RIGHT);
                    rebind_ChosenElements_in_Cells();
                }
                else // нулевой левее, чем первый
                {
                    swap_ChosenElements(MoveType.RIGHT, MoveType.LEFT);
                    rebind_ChosenElements_in_Cells();
                }
            }
        }

        private void unchosed_and_remove_ChosenCell(int i)
        {
            if (ChosenCells[i].get_Element() != null)
            {
                ChosenCells[i].get_Element().set_PRESSED(false);
            }
            ChosenCells.RemoveAt(i);
        }

        private void swap_ChosenElements(MoveType type0, MoveType type1)
        {
            ChosenCells[0].get_Element().set_newPosition(ChosenCells[1].get_Position());
            ChosenCells[1].get_Element().set_newPosition(ChosenCells[0].get_Position());

            ChosenCells[0].get_Element().set_MoveType(type0);
            ChosenCells[1].get_Element().set_MoveType(type1);

            World.swap_Elements(ChosenCells[0].get_IndicesX(), ChosenCells[0].get_IndicesY(), ChosenCells[1].get_IndicesX(), ChosenCells[1].get_IndicesY());
        }

        private void rebind_ChosenElements_in_Cells()
        {
            Element element;

            element = ChosenCells[0].get_Element();
            ChosenCells[0].change_bind_Element(ChosenCells[1].get_Element());
            ChosenCells[1].change_bind_Element(element);
        }

        public List<Cell> get_ChosenCells()
        {
            return ChosenCells;
        }
    }
}
