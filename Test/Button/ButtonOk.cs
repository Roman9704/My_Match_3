using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class ButtonOk : AbstractRectangularButton
    {
        public ButtonOk()
        {
            set_WIDTH(60);
            set_HEIGHT(60);
            set_Sprite(Content.ButtonOkSprite);
            set_SelectSprite(Content.ButtonOkSelectSprite);

            Initializer.window.MouseMoved += update_Selected;
            Initializer.window.MouseButtonPressed += update_Clicked;
        }

        ~ButtonOk()
        {
            Initializer.window.MouseMoved -= update_Selected;
            Initializer.window.MouseButtonPressed -= update_Clicked;
        }

        public override void Update()
        {

        }

        public override void Draw()
        {
            if (SELECTED)
            {
                Initializer.window.Draw(SelectSprite);
            }
            else
            {
                Initializer.window.Draw(Sprite);
            }
        }
    }
}
