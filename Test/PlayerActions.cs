using System.Collections.Generic;

namespace Test
{
    class PlayerActions
    {
        bool _actionOccurred = false;

        public static List<Cell> ChosenCells = null;

        public PlayerActions()
        {
            
        }

        public void Update()
        {
            updateChosenCells();
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
        private void updateChosenCells() 
        {
            if (GameLogic.AreElementsMove == false && GameLogic.DoEmptyCellsExist == false && _actionOccurred == false)
            {
                if (ChosenCells.Count > 1)
                {
                    if (ChosenCells[0].get_indicesX() == ChosenCells[1].get_indicesX()) // Элементы на одной вертикали
                    {
                        if (ChosenCells[0].get_indicesY() - ChosenCells[1].get_indicesY() == 1) // нулевой ниже, чем первый
                        { // меняем элементы местами по вертикали и чекаем после их перемещения
                            swapElementsInChosenCells(MoveType.UP, MoveType.DOWN);
                            rebindElementsInChosenCells();
                            _actionOccurred = true;
                        }
                        else
                        {
                            if (ChosenCells[0].get_indicesY() - ChosenCells[1].get_indicesY() == -1) // нулевой выше, чем первый
                            { // меняем элементы местами по вертикали и чекаем после их перемещения
                                swapElementsInChosenCells(MoveType.DOWN, MoveType.UP);
                                rebindElementsInChosenCells();
                                _actionOccurred = true;
                            }
                            else
                            {
                                unchosedAndRemoveChosenCell(1);
                            }
                        }
                    }
                    else
                    {
                        if (ChosenCells[0].get_indicesY() == ChosenCells[1].get_indicesY()) // Элементы на одной горизонтали
                        {
                            if (ChosenCells[0].get_indicesX() - ChosenCells[1].get_indicesX() == 1) // нулевой правее, чем первый
                            { // меняем элементы местами по вертикали и чекаем после их перемещения
                                swapElementsInChosenCells(MoveType.LEFT, MoveType.RIGHT);
                                rebindElementsInChosenCells();
                                _actionOccurred = true;
                            }
                            else
                            {
                                if (ChosenCells[0].get_indicesX() - ChosenCells[1].get_indicesX() == -1) // нулевой левее, чем первый
                                { // меняем элементы местами по вертикали и чекаем после их перемещения
                                    swapElementsInChosenCells(MoveType.RIGHT, MoveType.LEFT);
                                    rebindElementsInChosenCells();
                                    _actionOccurred = true;
                                }
                                else
                                {
                                    unchosedAndRemoveChosenCell(1);
                                }
                            }
                        }
                        else
                        {
                            unchosedAndRemoveChosenCell(1);
                        }
                    }
                }

            }
            else
            {
                if (_actionOccurred && GameLogic.AreElementsMove == false)
                {
                    if (GameLogic.DoEmptyCellsExist)
                    {
                        unchosedAndRemoveChosenCell(1);
                        unchosedAndRemoveChosenCell(0);
                        _actionOccurred = false;
                    }
                    else
                    {
                        unswapCellsAndElements();
                        unchosedAndRemoveChosenCell(1);
                        unchosedAndRemoveChosenCell(0);
                        _actionOccurred = false;
                    }
                }
            }
        }

        private void unswapCellsAndElements()
        {
            if (ChosenCells[0].get_indicesX() == ChosenCells[1].get_indicesX()) // Элементы на одной вертикали
            {
                if (ChosenCells[0].get_indicesY() > ChosenCells[1].get_indicesY()) // нулевой ниже, чем первый
                {
                    swapElementsInChosenCells(MoveType.UP, MoveType.DOWN);
                    rebindElementsInChosenCells();
                }
                else // нулевой выше, чем первый
                {
                    swapElementsInChosenCells(MoveType.DOWN, MoveType.UP);
                    rebindElementsInChosenCells();
                }
            }
            else // Элементы на одной горизонтали
            {
                if (ChosenCells[0].get_indicesX() > ChosenCells[1].get_indicesX()) // нулевой правее, чем первый
                {
                    swapElementsInChosenCells(MoveType.LEFT, MoveType.RIGHT);
                    rebindElementsInChosenCells();
                }
                else // нулевой левее, чем первый
                {
                    swapElementsInChosenCells(MoveType.RIGHT, MoveType.LEFT);
                    rebindElementsInChosenCells();
                }
            }
        }

        private void unchosedAndRemoveChosenCell(int i)
        {
            if (ChosenCells[i].get_element() != null)
            {
                ChosenCells[i].get_element().set_pressed(false);
            }
            ChosenCells.RemoveAt(i);
        }

        private void swapElementsInChosenCells(MoveType type0, MoveType type1)
        {
            ChosenCells[0].get_element().set_newPosition(ChosenCells[1].get_position());
            ChosenCells[1].get_element().set_newPosition(ChosenCells[0].get_position());

            ChosenCells[0].get_element().set_MoveType(type0);
            ChosenCells[1].get_element().set_MoveType(type1);

            World.swapElements(ChosenCells[0].get_indicesX(), ChosenCells[0].get_indicesY(), ChosenCells[1].get_indicesX(), ChosenCells[1].get_indicesY());
        }

        private void rebindElementsInChosenCells()
        {
            Element element;

            element = ChosenCells[0].get_element();
            ChosenCells[0].changeBind_element(ChosenCells[1].get_element());
            ChosenCells[1].changeBind_element(element);
        }
    }
}
