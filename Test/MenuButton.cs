using SFML.Graphics;

namespace Test
{
    class MenuButton : ARectangularButton
    {
        public MenuButton(RenderWindow window)
        {
            set_Window(window);
            set_WIDTH(120);
            set_HEIGHT(60);
            set_Sprite(Content.ButtonSprite0);
            set_SelectSprite(Content.ButtonSprite1);
            set_Position(Initializer.WINDOW_WIDTH / 2 - WIDTH / 2, Initializer.WINDOW_HEIGHT / 2 - HEIGHT / 2);

            window.MouseMoved += update_Selected;
            window.MouseButtonPressed += update_Clicked;
        }

        ~MenuButton()
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
