using SFML.System;
using System;
using Pulse.Grid;

namespace Pulse.World
{
    public class GameWorld
    {
        public const int AmountOfElements = 8;
        private static Vector2f offset;

        public static Element[,] Elements = null;

        private static Random random = null;

        public GameWorld()
        {
            
        }

        public void Destroy()
        {
            for (int y = 0; y < AmountOfElements; y++)
                for (int x = 0; x < AmountOfElements; x++)
                {
                    if (Elements[y, x] != null)
                    {
                        Elements[y, x].Destroy();
                        Elements[y, x] = null;
                    }
                }
            Elements = null;
            
            random = null;
        }

        public void Update()
        {
            for (int y = 0; y < AmountOfElements; y++)
                for (int x = 0; x < AmountOfElements; x++)
                {
                    if (Elements[y, x] == null) { continue; }

                    Elements[y, x].Update();
                }
        }

        public void Draw()
        {
            for (int y = 0; y < AmountOfElements; y++)
                for (int x = 0; x < AmountOfElements; x++)
                {
                    if (Elements[y, x] == null) { continue; }

                    Elements[y, x].Draw();
                }
        }

        public void GenerateElements()
        {
            Elements = new Element[AmountOfElements, AmountOfElements];
            offset = new Vector2f(0, Element.ElementSize + GameGrid.CoordinateShift);
            random = new Random();

            for (int y = 0 ;y < AmountOfElements; y++)
                for (int x = 0; x < AmountOfElements; x++)
                    SetElement((ElementType)random.Next(1, 6), x, y);
        }

        public static void SwapElements(int x1, int y1, int x2, int y2)
        {
            Element element;

            element = Elements[y1, x1];
            
            Elements[y1, x1] = Elements[y2, x2];
            Elements[y2, x2] = element;
        }

        public static void SpawnElement(Cell cell)
        {
            SetUpElement((ElementType)random.Next(1, 6), cell.Position, cell.Indices.X, cell.Indices.Y);
                    
            cell.BindElement(Elements[cell.Indices.Y, cell.Indices.X]);
        }

        public static void SetUpElement(ElementType type, Vector2f Position, int x, int y)
        {
            Elements[y, x] = new Element(type, Position - offset, Position,MoveType.Down);
        }

        public void SetElement(ElementType type, int x, int y)
        {
            Elements[y, x] = new Element(type, GameGrid.get_position(x, y));
        }

        public static void DeleteElement(int x, int y)
        {
            Elements[y, x] = null;
        }

        public Element[,] GetElements()
        {
            return Elements;
        }

        public Element GetElement(int x, int y)
        {
            return Elements[y, x];
        }
    }
}
