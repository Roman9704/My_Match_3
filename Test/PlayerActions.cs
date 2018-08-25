using System.Collections.Generic;
using Pulse.Grid;
using Pulse.World;

namespace Pulse
{
    public class PlayerActions
    {
        private bool actionOccurred = false;

        public static List<Cell> ChosenCells = null;

        public PlayerActions()
        {
            
        }

        public void Update()
        {
            UpdateChosenCells();
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
        private void UpdateChosenCells() 
        {
            if (GameLogic.AreElementsMove == false && GameLogic.DoEmptyCellsExist == false && actionOccurred == false)
            {
                if (ChosenCells.Count > 1)
                {
                    // Элементы на одной вертикали
                    if (ChosenCells[0].Indices.X == ChosenCells[1].Indices.X) 
                    {
                        // нулевой ниже, чем первый
                        if (ChosenCells[0].Indices.Y - ChosenCells[1].Indices.Y == 1) 
                        { 
                            // меняем элементы местами по вертикали и чекаем после их перемещения
                            swapElementsInChosenCells(MoveType.Up, MoveType.Down);
                            RebindElementsInChosenCells();
                            actionOccurred = true;
                        }
                        else
                        {
                            // нулевой выше, чем первый
                            if (ChosenCells[0].Indices.Y - ChosenCells[1].Indices.Y == -1) 
                            { // меняем элементы местами по вертикали и чекаем после их перемещения
                                swapElementsInChosenCells(MoveType.Down, MoveType.Up);
                                RebindElementsInChosenCells();
                                actionOccurred = true;
                            }
                            else
                            {
                                UnchosedAndRemoveChosenCell(1);
                            }
                        }
                    }
                    else
                    {
                        // Элементы на одной горизонтали
                        if (ChosenCells[0].Indices.Y == ChosenCells[1].Indices.Y) 
                        {
                            // нулевой правее, чем первый
                            if (ChosenCells[0].Indices.X - ChosenCells[1].Indices.X == 1) 
                            { // меняем элементы местами по вертикали и чекаем после их перемещения
                                swapElementsInChosenCells(MoveType.Left, MoveType.Right);
                                RebindElementsInChosenCells();
                                actionOccurred = true;
                            }
                            else
                            {
                                // нулевой левее, чем первый
                                if (ChosenCells[0].Indices.X - ChosenCells[1].Indices.X == -1) 
                                { // меняем элементы местами по вертикали и чекаем после их перемещения
                                    swapElementsInChosenCells(MoveType.Right, MoveType.Left);
                                    RebindElementsInChosenCells();
                                    actionOccurred = true;
                                }
                                else
                                {
                                    UnchosedAndRemoveChosenCell(1);
                                }
                            }
                        }
                        else
                        {
                            UnchosedAndRemoveChosenCell(1);
                        }
                    }
                }

            }
            else
            {
                if (actionOccurred && GameLogic.AreElementsMove == false)
                {
                    if (GameLogic.DoEmptyCellsExist)
                    {
                        UnchosedAndRemoveChosenCell(1);
                        UnchosedAndRemoveChosenCell(0);
                        actionOccurred = false;
                    }
                    else
                    {
                        UnswapCellsAndElements();
                        UnchosedAndRemoveChosenCell(1);
                        UnchosedAndRemoveChosenCell(0);
                        actionOccurred = false;
                    }
                }
            }
        }

        private void UnswapCellsAndElements()
        {
            // Элементы на одной вертикали
            if (ChosenCells[0].Indices.X == ChosenCells[1].Indices.X) 
            {
                // нулевой ниже, чем первый
                if (ChosenCells[0].Indices.Y > ChosenCells[1].Indices.Y) 
                {
                    swapElementsInChosenCells(MoveType.Up, MoveType.Down);
                    RebindElementsInChosenCells();
                }
                else // нулевой выше, чем первый
                {
                    swapElementsInChosenCells(MoveType.Down, MoveType.Up);
                    RebindElementsInChosenCells();
                }
            }
            else // Элементы на одной горизонтали
            {
                // нулевой правее, чем первый
                if (ChosenCells[0].Indices.X > ChosenCells[1].Indices.X) 
                {
                    swapElementsInChosenCells(MoveType.Left, MoveType.Right);
                    RebindElementsInChosenCells();
                }
                else // нулевой левее, чем первый
                {
                    swapElementsInChosenCells(MoveType.Right, MoveType.Left);
                    RebindElementsInChosenCells();
                }
            }
        }

        private void UnchosedAndRemoveChosenCell(int i)
        {
            if (ChosenCells[i].Element != null)
            {
                ChosenCells[i].Element.Pressed = false;
            }
            ChosenCells.RemoveAt(i);
        }

        private void swapElementsInChosenCells(MoveType type0, MoveType type1)
        {
            ChosenCells[0].Element.NewPosition = ChosenCells[1].Position;
            ChosenCells[1].Element.NewPosition = ChosenCells[0].Position;

            ChosenCells[0].Element.MoveType = type0;
            ChosenCells[1].Element.MoveType = type1;

            GameWorld.SwapElements(ChosenCells[0].Indices.X, ChosenCells[0].Indices.Y, ChosenCells[1].Indices.X, ChosenCells[1].Indices.Y);
        }

        private void RebindElementsInChosenCells()
        {
            Element element;

            element = ChosenCells[0].Element;
            ChosenCells[0].ChangeBindElement(ChosenCells[1].Element);
            ChosenCells[1].ChangeBindElement(element);
        }
    }
}
