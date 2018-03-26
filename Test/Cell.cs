using SFML.System;

namespace Test
{
    class Cell
    {
        Vector2f Position;
        Vector2i Indices;
        Element element = null;
        GameLogic gameLogic = null;

        public Cell(int X, int Y, float x, float y, GameLogic gameLogic)
        {
            set_Indices(X, Y);
            set_Position(x, y);
            set_GameLogic(gameLogic);
        }

        public void change_bind_Element(Element newElement)
        {
            unbind_Element();
            bind_Element(newElement);
        }

        public void add_Cell_to_ChoosenCells()
        {
            if (gameLogic.get_AreElementsMove() == false && gameLogic.get_PlayerActions().get_ChosenCells().Count < 2)
            {
                gameLogic.get_PlayerActions().get_ChosenCells().Add(this);
            }
            else
            {
                element.set_PRESSED(false);
            }
        }

        public void remove_Cell_to_ChoosenCells()
        {
            gameLogic.get_PlayerActions().get_ChosenCells().Remove(this);
        }

        public void bind_Element(Element element)
        {
            set_Element(element);

            element.Clicked += add_Cell_to_ChoosenCells;
            element.UnClicked += remove_Cell_to_ChoosenCells;
        }

        public void unbind_Element()
        {
            if (element != null)
            {
                element.Clicked -= add_Cell_to_ChoosenCells;
                element.UnClicked -= remove_Cell_to_ChoosenCells;

                set_Element(null);
            }
        }

        public void set_Position(Vector2f Position)
        {
            this.Position = Position;
        }

        public void set_Position(float x, float y)
        {
            Position.X = x;
            Position.Y = y;
        }

        public Vector2f get_Position()
        {
            return Position;
        }

        public float get_PositionX()
        {
            return Position.X;
        }

        public float get_PositionY()
        {
            return Position.Y;
        }

        public void set_Indices(Vector2i Indices)
        {
            this.Indices = Indices;
        }
        public void set_Indices(int x, int y)
        {
            Indices.X = x;
            Indices.Y = y;
        }
        public Vector2i get_Indices()
        {
            return Indices;
        }
        public int get_IndicesX()
        {
            return Indices.X;
        }
        public int get_IndicesY()
        {
            return Indices.Y;
        }

        public void set_Element(Element element)
        {
            this.element = element;
        }

        public Element get_Element()
        {
            return element;
        }

        public ElementType get_ElementType()
        {
            if (element == null)
            {
                return ElementType.NONE;
            }
            return element.get_ElementType();
        }

        private void set_GameLogic(GameLogic gameLogic)
        {
            this.gameLogic = gameLogic;
        }
    }
}
