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
            set_width(60);
            set_height(60);
            set_sprite(Content.ButtonOkSprite);
            set_selectSprite(Content.ButtonOkSelectSprite);

            Initializer.Window.MouseMoved += update_selected;
            Initializer.Window.MouseButtonPressed += updateClicked;
        }

        ~ButtonOk()
        {
            Initializer.Window.MouseMoved -= update_selected;
            Initializer.Window.MouseButtonPressed -= updateClicked;
        }

        public override void Update()
        {

        }

        public override void Draw()
        {
            if (_selected)
            {
                Initializer.Window.Draw(_selectSprite);
            }
            else
            {
                Initializer.Window.Draw(_sprite);
            }
        }
    }
}
