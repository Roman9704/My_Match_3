using System.Collections.Generic;
using Pulse.Grid;
using Pulse.World;

namespace Pulse
{
    public class GameLogic
    {
        public static bool AreElementsMove = false;
        public static bool DoEmptyCellsExist = false;
        public static int Score = 0;

        private List<List<Cell>> verticalChainCells = null;
        private List<List<Cell>> horizontalChainCells = null;
        private List<Cell> emptyCells = null;
        private List<Cell> notEmptyCells = null;

        private PlayerActions playerActions = null;

        public GameLogic()
        {
            
        }

        public void Generate()
        {
            verticalChainCells = new List<List<Cell>>();
            for (int i = 0; i < GameWorld.AmountOfElements; i++)
            {
                verticalChainCells.Add(new List<Cell>());
            }

            horizontalChainCells = new List<List<Cell>>();
            for (int i = 0; i < GameWorld.AmountOfElements; i++)
            {
                horizontalChainCells.Add(new List<Cell>());
            }

            emptyCells = new List<Cell>();
            notEmptyCells = new List<Cell>();

            playerActions = new PlayerActions();
            playerActions.Generate();

            Score = 0;
        }

        public void Destroy()
        {
            AreElementsMove = false;
            DoEmptyCellsExist = false;

            verticalChainCells.Clear();
            verticalChainCells = null;

            horizontalChainCells.Clear();
            horizontalChainCells = null;

            emptyCells.Clear();
            emptyCells = null;

            notEmptyCells.Clear();
            notEmptyCells = null;

            playerActions.Destroy();
            playerActions = null;
        }

        public void Update()
        {
            UpdateAreElementsMove();

            if (AreElementsMove == false)
            {
                UpdateDoEmptyCellsExist();

                if (DoEmptyCellsExist)
                {
                    MoveCellsToHoles();
                }
                else
                {
                    CheckCellsOnChains();

                    UpdateDoEmptyCellsExist();
                }
            }

            playerActions.Update();
        }

        private void UpdateDoEmptyCellsExist()
        {
            DoEmptyCellsExist = false;

            for (int y = 0; y < GameWorld.AmountOfElements; y++)
            {
                for (int x = 0; x < GameWorld.AmountOfElements; x++)
                {
                    if (GameGrid.Cells[y, x].Element == null)
                    {
                        DoEmptyCellsExist = true; 
                        break;
                    }
                }
                if (DoEmptyCellsExist) { break; }
            }
        }

        private void MoveCellsToHoles()
        {
            for (int x = 0; x < GameWorld.AmountOfElements; x++)
            {
                MoveCellsToHolesOnVertical(x);
            }
        }

        private void MoveCellsToHolesOnVertical(int x)
        {
            emptyCells.Clear();
            notEmptyCells.Clear();

            // В конце списка будут нижние элементы
            for (int y =  0; y < GameWorld.AmountOfElements; y++) 
            {
                if (GameGrid.Cells[y, x].Element == null)
                {
                    emptyCells.Add(GameGrid.Cells[y, x]);
                }
                else
                {
                    notEmptyCells.Add(GameGrid.Cells[y, x]);
                }
            }
            if (emptyCells.Count > 0)
            {
                for (int i = notEmptyCells.Count - 1; i >= 0; i--)
                    {
                        if (emptyCells[emptyCells.Count - 1].Indices.Y > notEmptyCells[i].Indices.Y)
                        {
                            notEmptyCells[i].Element.NewPosition = emptyCells[emptyCells.Count - 1].Position;
                            notEmptyCells[i].Element.MoveType = MoveType.Down;

                            emptyCells[emptyCells.Count - 1].ChangeBindElement(notEmptyCells[i].Element);

                            notEmptyCells[i].UnbindElement();

                            GameWorld.SwapElements(notEmptyCells[i].Indices.X, notEmptyCells[i].Indices.Y, emptyCells[emptyCells.Count - 1].Indices.X, emptyCells[emptyCells.Count - 1].Indices.Y);

                            emptyCells.Remove(emptyCells[emptyCells.Count - 1]);
                            break;
                        }
                    }
                if (emptyCells.Count > 0)
                {
                    if (GameGrid.Cells[0, x].Element == null)
                    {
                        GameWorld.SpawnElement(GameGrid.Cells[0, x]);
                    }
                    MoveCellsToHolesOnVertical(x);
                }
            }
        }

        private void CheckCellsOnChains()
        {
            if (AreElementsMove != true)
            {
                for (int y = 0; y < GameWorld.AmountOfElements; y++)
                {
                    CheckHorizontalOnChains(y);
                }
                for (int x = 0; x < GameWorld.AmountOfElements; x++)
                {
                    CheckVerticalOnChains(x);
                }

                DeleteCellsInChainCells();
            }
        }

        private void CheckVerticalOnChains(int x)
        {
            for (int y = GameWorld.AmountOfElements - 1; y > 1; y--)
            {
                if (GameGrid.Cells[y, x].get_elementType() != ElementType.None)
                {
                    if (
                        GameGrid.Cells[y, x].get_elementType() == GameGrid.Cells[y - 1, x].get_elementType() &&
                        GameGrid.Cells[y, x].get_elementType() == GameGrid.Cells[y - 2, x].get_elementType()
                    ) {
                        if (!verticalChainCells[x].Contains(GameGrid.Cells[y, x])) {
                            verticalChainCells[x].Add(GameGrid.Cells[y, x]);
                        }
                        if (!verticalChainCells[x].Contains(GameGrid.Cells[y - 1, x])) {
                            verticalChainCells[x].Add(GameGrid.Cells[y - 1, x]);
                        }
                        verticalChainCells[x].Add(GameGrid.Cells[y - 2, x]);
                    }
                }
            }
        }

        private void CheckHorizontalOnChains(int y)
        {
            for (int x = GameWorld.AmountOfElements - 1; x > 1; x--)
            {
                if (GameGrid.Cells[y, x].get_elementType() != ElementType.None)
                {
                    if (GameGrid.Cells[y, x].get_elementType() == GameGrid.Cells[y, x - 1].get_elementType() && GameGrid.Cells[y, x].get_elementType() == GameGrid.Cells[y, x - 2].get_elementType())
                    {
                        if (!horizontalChainCells[y].Contains(GameGrid.Cells[y, x]))
                        {
                            horizontalChainCells[y].Add(GameGrid.Cells[y, x]);
                        }
                        if (!horizontalChainCells[y].Contains(GameGrid.Cells[y, x - 1]))
                        {
                            horizontalChainCells[y].Add(GameGrid.Cells[y, x - 1]);
                        }
                        horizontalChainCells[y].Add(GameGrid.Cells[y, x - 2]);
                    }
                }
            }
        }

        private void DeleteCellsInChainCells()
        {
            for (int i = verticalChainCells.Count - 1; i >= 0 ; i--)
            {
                for (int j = verticalChainCells[i].Count - 1; j >= 0; j--)
                {
                    if (verticalChainCells[i][j].Element != null)
                    {
                        Score += verticalChainCells[i][j].Element.Points;
                        verticalChainCells[i][j].UnbindElement();
                        GameWorld.DeleteElement(verticalChainCells[i][j].Indices.X, verticalChainCells[i][j].Indices.Y);
                    }
                }
                verticalChainCells[i].Clear();
            }

            for (int i = horizontalChainCells.Count - 1; i >= 0; i--)
            {
                for (int j = horizontalChainCells[i].Count - 1; j >= 0; j--)
                {
                    if (horizontalChainCells[i][j].Element != null)
                    {
                        Score += horizontalChainCells[i][j].Element.Points;
                        horizontalChainCells[i][j].UnbindElement();
                        GameWorld.DeleteElement(horizontalChainCells[i][j].Indices.X, horizontalChainCells[i][j].Indices.Y);
                    }
                }
                horizontalChainCells[i].Clear();
            }
        }

        private void UpdateAreElementsMove()
        {
            AreElementsMove = false;

            for (int y = 0; y < GameWorld.AmountOfElements; y++)
            {
                for (int x = 0; x <GameWorld.AmountOfElements; x++)
                {
                    if (GameGrid.Cells[y, x].Element == null) {
                        continue;
                    }
                    if (GameGrid.Cells[y, x].Element.MoveType != MoveType.None)
                    {
                        AreElementsMove = true;
                        break;
                    }
                }
                if (AreElementsMove) {
                    break;
                }
            }
        }
    }
}
