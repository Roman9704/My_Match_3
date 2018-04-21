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
        BackgroundType _type;

        Color _clearColor;

        public Background(BackgroundType type)
        {
            set_BackgroundType(type);
        }

        public void set_BackgroundType(BackgroundType type)
        {
            this._type = type;

            _clearColor = Content.ListOfColors[(int)type];
        }
        public BackgroundType get_BackgroundType()
        {
            return _type;
        }
        public void change_BackgroundType()
        {
            if (_type == BackgroundType.DarkPurple)
            {
                set_BackgroundType(BackgroundType.Turquoise);
                _clearColor = Content.ListOfColors[(int)BackgroundType.Turquoise];
            }
            else
            {
                set_BackgroundType(BackgroundType.DarkPurple);
                _clearColor = Content.ListOfColors[(int)BackgroundType.DarkPurple];
            }
        }
        public void set_clearColor(Color ClearColor)
        {
            this._clearColor = ClearColor;
        }
        public Color get_clearColor()
        {
            return _clearColor;
        }

        public void Draw()
        {
            Initializer.Window.Clear(_clearColor);
        }
    }
}
