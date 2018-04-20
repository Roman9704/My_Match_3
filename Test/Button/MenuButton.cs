using SFML.Graphics;

namespace Test
{
    class MenuButton : AbstractRectangularButton
    {
        public MenuButton()
        {
            set_WIDTH(120);
            set_HEIGHT(60);
            set_Sprite(Content.ButtonSprite0);
            set_SelectSprite(Content.ButtonSprite1);
            set_Position(Initializer.WINDOW_WIDTH / 2 - WIDTH / 2, Initializer.WINDOW_HEIGHT / 2 - HEIGHT / 2);

            Initializer.window.MouseMoved += update_Selected;
            Initializer.window.MouseButtonPressed += update_Clicked;
        }

        ~MenuButton()
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
