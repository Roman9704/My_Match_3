using SFML.Graphics;
using SFML.System;

namespace Test.GUI.GUIElement
{
    class Inscription : AbstractGUIElement
    {
        Text _text = null;

        public Inscription(string String, Font font, uint size)
        {
            _text = new Text(String, font, size);
        }
        public Inscription(string String, Font font)
        {
            _text = new Text(String, font);
        }
        public Inscription()
        {
            _text = new Text();
        }
        public Inscription(Inscription copy)
        {
            _text = new Text(copy.get_string(), copy.get_font(), copy.get_size());
            _text.Color = copy.get_color();
            _text.Style = copy.get_style();
        }

        public void set_string(string text)
        {
            this._text.DisplayedString = text;
        }
        public string get_string()
        {
            return _text.DisplayedString;
        }
        public void set_color(Color color)
        {
            _text.Color = color;
        }
        public Color get_color()
        {
            return _text.Color;
        }
        public override void set_position(Vector2f vector2f)
        {
            _text.Position = vector2f;
        }
        public override Vector2f get_position()
        {
            return _text.Position;
        }
        public override void set_positionX(float X)
        {
            _text.Position = new Vector2f(X, _text.Position.Y);
        }
        public override float get_positionX()
        {
            return _text.Position.X;
        }
        public override void set_positionY(float Y)
        {
            _text.Position = new Vector2f(_text.Position.X, Y);
        }
        public override float get_positionY()
        {
            return _text.Position.Y;
        }
        public void set_font(Font font)
        {
            _text.Font = font;
        }
        public Font get_font()
        {
            return _text.Font;
        }
        public void set_style(Text.Styles style)
        {
            _text.Style = style;
        }
        public Text.Styles get_style()
        {
            return _text.Style;
        }
        public void set_size(uint size)
        {
            _text.CharacterSize = size;
        }
        public uint get_size()
        {
            return _text.CharacterSize;
        }

        public override void Draw()
        {
            Initializer.Window.Draw(_text);
        }
        public override void Update()
        {

        }
    }
}
