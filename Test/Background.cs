using SFML.Graphics;

namespace Pulse
{
    public enum BackgroundType
    {
        DarkPurple,
        Turquoise
    }

    public class Background
    {
        private BackgroundType type;
        public BackgroundType Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
                Color = Content.ListOfColors[(int)value];
            }
        }
        public Color Color { get; private set; }

        public Background(BackgroundType type)
        {
            Type = type;
        }

        public void Draw()
        {
            Initializer.Window.Clear(Color);
        }
    }
}
