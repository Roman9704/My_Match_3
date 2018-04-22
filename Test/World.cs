using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Grid;

namespace Test
{
    class World
    {
        public const int AmountOfElements = 8;
        static Vector2f _offset;

        public static Element[,] Elements = null;

        static Random _random = null;

        public World()
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
            
            _random = null;
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

        public void generateElements()
        {
            Elements = new Element[AmountOfElements, AmountOfElements];
            _offset = new Vector2f(0, Element.ElementSize + GameGrid.CoordinateShift);
            _random = new Random();

            for (int y = 0 ;y < AmountOfElements; y++)
                for (int x = 0; x < AmountOfElements; x++)
                    setElement((ElementType)_random.Next(1, 6), x, y);
        }

        public static void swapElements(int x1, int y1, int x2, int y2)
        {
            Element element;

            element = Elements[y1, x1];
            
            Elements[y1, x1] = Elements[y2, x2];
            Elements[y2, x2] = element;
        }

        public static void spawnElement(Cell cell)
        {
            setUpElement((ElementType)_random.Next(1, 6), cell.get_position(), cell.get_indicesX(), cell.get_indicesY());
                    
            cell.bind_element(Elements[cell.get_indicesY(), cell.get_indicesX()]);
        }

        public static void setUpElement(ElementType type, Vector2f Position, int x, int y)
        {
            Elements[y, x] = new Element(type, Position - _offset, Position,MoveType.DOWN);
        }

        public void setElement(ElementType type, int x, int y)
        {
            Elements[y, x] = new Element(type, GameGrid.get_position(x, y));
        }

        public static void deleteElement(int x, int y)
        {
            Elements[y, x] = null;
        }

        public Element[,] getElements()
        {
            return Elements;
        }

        public Element getElement(int x, int y)
        {
            return Elements[y, x];
        }
    }
}
