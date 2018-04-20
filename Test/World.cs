using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class World
    {
        public const int AMOUNT_OF_ELEMENTS = 8;
        static Vector2f Offset;

        public static Element[,] elements = null;

        static Random random = null;

        public World()
        {
            
        }

        public void Destroy()
        {
            for (int y = 0; y < AMOUNT_OF_ELEMENTS; y++)
                for (int x = 0; x < AMOUNT_OF_ELEMENTS; x++)
                    elements[y, x] = null;
            elements = null;
            
            random = null;
        }

        public void Update()
        {
            for (int y = 0; y < AMOUNT_OF_ELEMENTS; y++)
                for (int x = 0; x < AMOUNT_OF_ELEMENTS; x++)
                {
                    if (elements[y, x] == null) { continue; }

                    elements[y, x].Update();
                }
        }

        public void Draw()
        {
            for (int y = 0; y < AMOUNT_OF_ELEMENTS; y++)
                for (int x = 0; x < AMOUNT_OF_ELEMENTS; x++)
                {
                    if (elements[y, x] == null) { continue; }

                    elements[y, x].Draw();
                }
        }

        public void generate_Elements()
        {
            elements = new Element[AMOUNT_OF_ELEMENTS, AMOUNT_OF_ELEMENTS];
            Offset = new Vector2f(0, 60 + Grid.COORDINATE_SHIFT);
            random = new Random();

            for (int y = 0 ;y < AMOUNT_OF_ELEMENTS; y++)
                for (int x = 0; x < AMOUNT_OF_ELEMENTS; x++)
                    switch (random.Next(1, 6))
                    {
                        case 1:
                            set_Element(ElementType.BLUE, x, y);
                            break;
                        case 2:
                            set_Element(ElementType.GREEN, x, y);
                            break;
                        case 3:
                            set_Element(ElementType.ORANGE, x, y);
                            break;
                        case 4:
                            set_Element(ElementType.PINK, x, y);
                            break;
                        case 5:
                            set_Element(ElementType.YELLOW, x, y);
                            break;
                    }
        }

        public static void swap_Elements(int x1, int y1, int x2, int y2)
        {
            Element element;

            element = elements[y1, x1];
            
            elements[y1, x1] = elements[y2, x2];
            elements[y2, x2] = element;
        }

        public static void spawn_Element(Cell cell)
        {
            switch (random.Next(1, 6))
            {
                case 1:
                    set_up_Element(ElementType.BLUE, cell.get_Position(), cell.get_IndicesX(), cell.get_IndicesY());
                    break;
                case 2:
                    set_up_Element(ElementType.GREEN, cell.get_Position(), cell.get_IndicesX(), cell.get_IndicesY());
                    break;
                case 3:
                    set_up_Element(ElementType.ORANGE, cell.get_Position(), cell.get_IndicesX(), cell.get_IndicesY());
                    break;
                case 4:
                    set_up_Element(ElementType.PINK, cell.get_Position(), cell.get_IndicesX(), cell.get_IndicesY());
                    break;
                case 5:
                    set_up_Element(ElementType.YELLOW, cell.get_Position(), cell.get_IndicesX(), cell.get_IndicesY());
                    break;
            }

            cell.bind_Element(elements[cell.get_IndicesY(), cell.get_IndicesX()]);
        }

        public Element[,] get_Elements()
        {
            return elements;
        }

        public static void set_up_Element(ElementType type, Vector2f Position, int x, int y)
        {
            elements[y, x] = new Element(type, Position - Offset, Position,MoveType.DOWN);
        }

        public void set_Element(ElementType type, int x, int y)
        {
            elements[y, x] = new Element(type, Grid.get_Position(x, y));
        }

        public static void delete_Element(int x, int y)
        {
            elements[y, x] = null;
        }

        public Element get_Element(int x, int y)
        {
            return elements[y, x];
        }
    }
}
