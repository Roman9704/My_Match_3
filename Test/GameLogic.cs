using System.Collections.Generic;
using SFML.Window;
using SFML.Graphics;
using SFML.System;
using System;
using Test.Grid;

namespace Test
{
    class GameLogic
    {
        public static bool AreElementsMove = false;
        public static bool DoEmptyCellsExist = false;
        public static int Score = 0;

        List<List<Cell>> _verticalChainCells = null;
        List<List<Cell>> _horizontalChainCells = null;
        List<Cell> _emptyCells = null;
        List<Cell> _notEmptyCells = null;

        PlayerActions _playerActions = null;

        public GameLogic()
        {
            
        }

        public void Generate()
        {
            _verticalChainCells = new List<List<Cell>>();
            for (int i = 0; i < World.AmountOfElements; i++)
            {
                _verticalChainCells.Add(new List<Cell>());
            }

            _horizontalChainCells = new List<List<Cell>>();
            for (int i = 0; i < World.AmountOfElements; i++)
            {
                _horizontalChainCells.Add(new List<Cell>());
            }

            _emptyCells = new List<Cell>();
            _notEmptyCells = new List<Cell>();

            _playerActions = new PlayerActions();
            _playerActions.Generate();

            Score = 0;
        }

        public void Destroy()
        {
            AreElementsMove = false;
            DoEmptyCellsExist = false;

            _verticalChainCells.Clear();
            _verticalChainCells = null;

            _horizontalChainCells.Clear();
            _horizontalChainCells = null;

            _emptyCells.Clear();
            _emptyCells = null;

            _notEmptyCells.Clear();
            _notEmptyCells = null;

            _playerActions.Destroy();
            _playerActions = null;
        }

        public void Update()
        {
            updateAreElementsMove();

            if (AreElementsMove == false)
            {
                updateDoEmptyCellsExist();

                if (DoEmptyCellsExist)
                {
                    moveCellsToHoles();
                }
                else
                {
                    checkCellsOnChains();

                    updateDoEmptyCellsExist();
                }
            }

            _playerActions.Update();
        }

        private void updateDoEmptyCellsExist()
        {
            DoEmptyCellsExist = false;

            for (int y = 0; y < World.AmountOfElements; y++)
            {
                for (int x = 0; x < World.AmountOfElements; x++)
                {
                    if (GameGrid.Cells[y, x].get_element() == null)
                    {
                        DoEmptyCellsExist = true; 
                        break;
                    }
                }
                if (DoEmptyCellsExist) { break; }
            }
        }

        private void moveCellsToHoles()
        {
            for (int x = 0; x < World.AmountOfElements; x++)
            {
                moveCellsToHolesOnVertical(x);
            }
        }

        private void moveCellsToHolesOnVertical(int x)
        {
            _emptyCells.Clear();
            _notEmptyCells.Clear();

            for (int y =  0; y < World.AmountOfElements; y++) // В конце списка будут нижние элементы
            {
                if (GameGrid.Cells[y, x].get_element() == null)
                {
                    _emptyCells.Add(GameGrid.Cells[y, x]);
                }
                else
                {
                    _notEmptyCells.Add(GameGrid.Cells[y, x]);
                }
            }
            if (_emptyCells.Count > 0)
            {
                for (int i = _notEmptyCells.Count - 1; i >= 0; i--)
                    {
                        if (_emptyCells[_emptyCells.Count - 1].get_indicesY() > _notEmptyCells[i].get_indicesY())
                        {
                            _notEmptyCells[i].get_element().set_newPosition(_emptyCells[_emptyCells.Count - 1].get_position());
                            _notEmptyCells[i].get_element().set_moveType(MoveType.DOWN);

                            _emptyCells[_emptyCells.Count - 1].changeBind_element(_notEmptyCells[i].get_element());

                            _notEmptyCells[i].unbind_element();

                            World.swapElements(_notEmptyCells[i].get_indicesX(), _notEmptyCells[i].get_indicesY(), _emptyCells[_emptyCells.Count - 1].get_indicesX(), _emptyCells[_emptyCells.Count - 1].get_indicesY());

                            _emptyCells.Remove(_emptyCells[_emptyCells.Count - 1]);
                            break;
                        }
                    }
                if (_emptyCells.Count > 0)
                {
                    if (GameGrid.Cells[0, x].get_element() == null)
                    {
                        World.spawnElement(GameGrid.Cells[0, x]);
                    }
                    moveCellsToHolesOnVertical(x);
                }
            }
        }

        private void checkCellsOnChains()
        {
            if (AreElementsMove != true)
            {
                for (int y = 0; y < World.AmountOfElements; y++)
                {
                    checkHorizontalOnChains(y);
                }
                for (int x = 0; x < World.AmountOfElements; x++)
                {
                    checkVerticalOnChains(x);
                }

                deleteCellsInChainCells();
            }
        }

        private void checkVerticalOnChains(int x)
        {
            for (int y = World.AmountOfElements - 1; y > 1; y--)
            {
                if (GameGrid.Cells[y, x].get_elementType() != ElementType.NONE)
                {
                    if (GameGrid.Cells[y, x].get_elementType() == GameGrid.Cells[y - 1, x].get_elementType() && GameGrid.Cells[y, x].get_elementType() == GameGrid.Cells[y - 2, x].get_elementType())
                    {
                        if (!_verticalChainCells[x].Contains(GameGrid.Cells[y, x]))
                        {
                            _verticalChainCells[x].Add(GameGrid.Cells[y, x]);
                        }
                        if (!_verticalChainCells[x].Contains(GameGrid.Cells[y - 1, x]))
                        {
                            _verticalChainCells[x].Add(GameGrid.Cells[y - 1, x]);
                        }
                        _verticalChainCells[x].Add(GameGrid.Cells[y - 2, x]);
                    }
                }
            }
        }

        private void checkHorizontalOnChains(int y)
        {
            for (int x = World.AmountOfElements - 1; x > 1; x--)
            {
                if (GameGrid.Cells[y, x].get_elementType() != ElementType.NONE)
                {
                    if (GameGrid.Cells[y, x].get_elementType() == GameGrid.Cells[y, x - 1].get_elementType() && GameGrid.Cells[y, x].get_elementType() == GameGrid.Cells[y, x - 2].get_elementType())
                    {
                        if (!_horizontalChainCells[y].Contains(GameGrid.Cells[y, x]))
                        {
                            _horizontalChainCells[y].Add(GameGrid.Cells[y, x]);
                        }
                        if (!_horizontalChainCells[y].Contains(GameGrid.Cells[y, x - 1]))
                        {
                            _horizontalChainCells[y].Add(GameGrid.Cells[y, x - 1]);
                        }
                        _horizontalChainCells[y].Add(GameGrid.Cells[y, x - 2]);
                    }
                }
            }
        }

        private void deleteCellsInChainCells()
        {
            for (int i = _verticalChainCells.Count - 1; i >= 0 ; i--)
            {
                for (int j = _verticalChainCells[i].Count - 1; j >= 0; j--)
                {
                    if (_verticalChainCells[i][j].get_element() != null)
                    {
                        Score += _verticalChainCells[i][j].get_element().getPoints();
                        _verticalChainCells[i][j].unbind_element();
                        World.deleteElement(_verticalChainCells[i][j].get_indicesX(), _verticalChainCells[i][j].get_indicesY());
                    }
                }
                _verticalChainCells[i].Clear();
            }

            for (int i = _horizontalChainCells.Count - 1; i >= 0; i--)
            {
                for (int j = _horizontalChainCells[i].Count - 1; j >= 0; j--)
                {
                    if (_horizontalChainCells[i][j].get_element() != null)
                    {
                        Score += _horizontalChainCells[i][j].get_element().getPoints();
                        _horizontalChainCells[i][j].unbind_element();
                        World.deleteElement(_horizontalChainCells[i][j].get_indicesX(), _horizontalChainCells[i][j].get_indicesY());
                    }
                }
                _horizontalChainCells[i].Clear();
            }
        }

        private void updateAreElementsMove()
        {
            AreElementsMove = false;

            for (int y = 0; y < World.AmountOfElements; y++)
            {
                for (int x = 0; x <World.AmountOfElements; x++)
                {
                    if (GameGrid.Cells[y, x].get_element() == null) { continue; }

                    if (GameGrid.Cells[y, x].get_element().get_moveType() != MoveType.NONE)
                    {
                        AreElementsMove = true;
                        break;
                    }
                }
                if (AreElementsMove) { break; }
            }
        }
    }
}
