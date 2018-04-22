using SFML.Graphics;

namespace Test.Button
{
    class MenuButton : AbstractRectangularButton
    {
        public MenuButton()
        {
            set_width(120);
            set_height(60);
            set_sprite(Content.ButtonSprite0);
            set_selectSprite(Content.ButtonSprite1);
            set_position(Initializer.WindowWidth / 2 - _width / 2, Initializer.WindowHeight / 2 - _height / 2);

            Initializer.Window.MouseMoved += update_selected;
            Initializer.Window.MouseButtonPressed += updateClicked;
        }

        ~MenuButton()
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
