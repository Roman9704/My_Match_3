using SFML.System;

namespace Pulse.Grid
{
    public class Cell
    {
        public Vector2f Position { get; set; }
        public Vector2i Indices { get; set; }
        public Element Element { get; set; }

        public Cell(int X, int Y, float x, float y)
        {
            Indices = new Vector2i(X, Y);
            Position = new Vector2f(x, y);
        }

        public void Destroy()
        {
            UnbindElement();
        }

        public void ChangeBindElement(Element newElement)
        {
            UnbindElement();
            BindElement(newElement);
        }

        public void AddCellToChosenCells()
        {
            if (GameLogic.AreElementsMove == false && PlayerActions.ChosenCells.Count < 2)
            {
                PlayerActions.ChosenCells.Add(this);
            }
            else
            {
                Element.Pressed = false;
            }
        }

        public void RemoveCellInChosenCells()
        {
            PlayerActions.ChosenCells.Remove(this);
        }

        public void BindElement(Element element)
        {
            Element = element;

            Element.Clicked += AddCellToChosenCells;
            Element.UnClicked += RemoveCellInChosenCells;
        }

        public void UnbindElement()
        {
            if (Element != null)
            {
                Element.Clicked -= AddCellToChosenCells;
                Element.UnClicked -= RemoveCellInChosenCells;

                Element = null;
            }
        }

        public ElementType get_elementType()
        {
            if (Element == null)
            {
                return ElementType.None;
            }
            return Element.Type;
        }
    }
}
