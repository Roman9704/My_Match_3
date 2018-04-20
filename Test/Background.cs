using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;

namespace Test
{
    enum BackgroundType
    {
        DarkPurple,
        Turquoise
    }

    class Background
    {
        BackgroundType type;

        Color ClearColor;
        Color colorDarkPurple = new Color(48, 10, 36);
        Color colorTurquoise = new Color(207, 245, 219);
        
        public Background()
        {
            set_BackgroundType(BackgroundType.DarkPurple);
            set_ClearColor(colorDarkPurple);
        }
        public Background(BackgroundType type)
        {
            set_BackgroundType(type);
        }

        public void set_BackgroundType(BackgroundType type)
        {
            this.type = type;

            switch (type)
            {
                case BackgroundType.DarkPurple:
                    ClearColor = colorDarkPurple;
                    break;
                case BackgroundType.Turquoise:
                    ClearColor = colorTurquoise;
                    break;
            }
        }
        public BackgroundType get_BackgroundType()
        {
            return type;
        }
        public void change_BackgroundType()
        {
            if (type == BackgroundType.DarkPurple)
            {
                set_BackgroundType(BackgroundType.Turquoise);
                ClearColor = colorDarkPurple;
            }
            else
            {
                set_BackgroundType(BackgroundType.DarkPurple);
                ClearColor = colorTurquoise;
            }
        }
        public void set_ClearColor(Color ClearColor)
        {
            this.ClearColor = ClearColor;
        }
        public Color get_ClearColor()
        {
            return ClearColor;
        }

        public void Draw()
        {
            Initializer.window.Clear(ClearColor);
        }
    }
}
