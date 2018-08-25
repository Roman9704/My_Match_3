using SFML.Graphics;
using SFML.System;

namespace Pulse.GUI.GUIObject
{
    public class Inscription : AbstractGUIObject
    {
        private Text text = null;

        public override Vector2f Position
        {
            get
            {
                return text.Position;
            }
            set
            {
                text.Position = value;
            }
        }

        public string DisplayedString
        {
            get
            {
                return text.DisplayedString;
            }
            set
            {
                text.DisplayedString = value;
            }
        }

        public Font Font
        {
            get
            {
                return text.Font;
            }
            set
            {
                text.Font = value;
            }
        }

        public Text.Styles Style
        {
            get
            {
                return text.Style;
            }
            set
            {
                text.Style = value;
            }
        }

        public uint CharacterSize
        {
            get
            {
                return text.CharacterSize;
            }
            set
            {
                text.CharacterSize = value;
            }
        }

        public Color Color
        {
            get
            {
                return text.Color;
            }
            set
            {
                text.Color = value;
            }

        }

        public Inscription(string String, Font font, uint size)
        {
            text = new Text(String, font, size);
        }

        public Inscription(string String, Font font)
        {
            text = new Text(String, font);
        }

        public Inscription()
        {
            text = new Text();
        }

        public Inscription(Inscription copy)
        {
            text = new Text(copy.DisplayedString, copy.Font, copy.CharacterSize);
            text.Color = copy.Color;
            text.Style = copy.Style;
        }
        
        public override void Draw()
        {
            Initializer.Window.Draw(text);
        }

        public override void Update()
        {

        }
    }
}
