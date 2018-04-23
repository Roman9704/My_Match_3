using SFML.System;
using System;

namespace Test.Grid
{
    class Cell
    {
        Vector2f _position;
        Vector2i _indices;
        Element _element = null;

        public Cell(int X, int Y, float x, float y)
        {
            set_indices(X, Y);
            set_position(x, y);
        }

        public void Destroy()
        {
            unbind_element();
        }

        public void changeBind_element(Element newElement)
        {
            unbind_element();
            bind_element(newElement);
        }

        public void addCellToChosenCells()
        {
            if (GameLogic.AreElementsMove == false && PlayerActions.ChosenCells.Count < 2)
            {
                PlayerActions.ChosenCells.Add(this);
            }
            else
            {
                _element.set_pressed(false);
            }
        }

        public void removeCellInChosenCells()
        {
            PlayerActions.ChosenCells.Remove(this);
        }

        public void bind_element(Element element)
        {
            set_element(element);

            element.Clicked += addCellToChosenCells;
            element.UnClicked += removeCellInChosenCells;
        }

        public void unbind_element()
        {
            if (_element != null)
            {
                _element.Clicked -= addCellToChosenCells;
                _element.UnClicked -= removeCellInChosenCells;

                set_element(null);
            }
        }

        public void set_position(Vector2f Position)
        {
            this._position = Position;
        }

        public void set_position(float x, float y)
        {
            _position.X = x;
            _position.Y = y;
        }

        public Vector2f get_position()
        {
            return _position;
        }

        public float get_positionX()
        {
            return _position.X;
        }

        public float get_positionY()
        {
            return _position.Y;
        }

        public void set_indices(Vector2i Indices)
        {
            this._indices = Indices;
        }
        public void set_indices(int x, int y)
        {
            _indices.X = x;
            _indices.Y = y;
        }
        public Vector2i get_indices()
        {
            return _indices;
        }
        public int get_indicesX()
        {
            return _indices.X;
        }
        public int get_indicesY()
        {
            return _indices.Y;
        }

        public void set_element(Element element)
        {
            this._element = element;
        }

        public Element get_element()
        {
            return _element;
        }

        public ElementType get_elementType()
        {
            if (_element == null)
            {
                return ElementType.NONE;
            }
            return _element.get_elementType();
        }
    }
}
