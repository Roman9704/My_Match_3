using SFML.Graphics;
using SFML.System;

namespace Test
{
    class Inscription : AbstractGUIElement
    {
        Text text = null;

        Inscription(string String, Font font, uint size)
        {
            text = new Text(String, font, size);
        }
        Inscription(string String, Font font)
        {
            text = new Text(String, font);
        }
        Inscription()
        {
            text = new Text();
        }
        Inscription(Inscription copy)
        {
            text = new Text(copy.get_String(), copy.get_Font(), copy.get_Size());
            text.Color = copy.get_Color();
            text.Style = copy.get_Style();
        }

        public void set_String(string text){
            this.text.DisplayedString = text;
        }
        public string get_String()
        {
            return text.DisplayedString;
        }
        public void set_Color(Color color)
        {
            text.Color = color;
        }
        public Color get_Color()
        {
            return text.Color;
        }
        public override void set_Position(Vector2f vector2f)
        {
            text.Position = vector2f;
        }
        public override Vector2f get_Position()
        {
            return text.Position;
        }
        public override void set_PositionX(float X)
        {
            text.Position = new Vector2f(X, text.Position.Y);
        }
        public override float get_PositionX()
        {
            return text.Position.X;
        }
        public override void set_PositionY(float Y)
        {
            text.Position = new Vector2f(text.Position.X, Y);
        }
        public override float get_PositionY()
        {
            return text.Position.Y;
        }
        public void set_Font(Font font)
        {
            text.Font = font;
        }
        public Font get_Font()
        {
            return text.Font;
        }
        public void set_Style(Text.Styles style)
        {
            text.Style = style;
        }
        public Text.Styles get_Style()
        {
            return text.Style;
        }
        public void set_Size(uint size)
        {
            text.CharacterSize = size;
        }
        public uint get_Size()
        {
            return text.CharacterSize;
        }

        public override void Draw()
        {
            Initializer.window.Draw(text);
        }
        public override void Update()
        {
            
        }
    }
}
