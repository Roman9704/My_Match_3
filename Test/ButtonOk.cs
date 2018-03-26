using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class ButtonOk : ARectangularButton
    {
        public ButtonOk(RenderWindow window)
        {
            set_Window(window);
            set_WIDTH(60);
            set_HEIGHT(60);
            set_Sprite(Content.ButtonOkSprite);
            set_SelectSprite(Content.ButtonOkSelectSprite);

            window.MouseMoved += update_Selected;
            window.MouseButtonPressed += update_Clicked;
        }

        ~ButtonOk()
        {
            window.MouseMoved -= update_Selected;
            window.MouseButtonPressed -= update_Clicked;
        }

        public override void Update()
        {

        }

        public override void Draw()
        {
            if (SELECTED)
            {
                window.Draw(SelectSprite);
            }
            else
            {
                window.Draw(Sprite);
            }
        }
    }
}
