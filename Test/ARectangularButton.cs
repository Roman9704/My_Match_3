using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace Test
{
    abstract class ARectangularButton
    {
        public delegate void MethodContainer();
        public event MethodContainer Clicked = delegate { };
        public event MethodContainer UnClicked = delegate { };

        protected RenderWindow window = null;
        protected Vector2f Position;
        protected Vector2f DownRightCorner;
        protected Sprite Sprite = null;
        protected Sprite SelectSprite = null;
        protected float WIDTH = 0;
        protected float HEIGHT = 0;
        protected bool SELECTED = false;
        protected bool PRESSED = false;

        abstract public void Draw();

        abstract public void Update();

        protected void update_Clicked(object sender, MouseButtonEventArgs e)
        {
            if (SELECTED)
            {
                if (PRESSED == false)
                {
                    PRESSED = true;
                    Clicked();
                }
                else
                {
                    PRESSED = false;
                    UnClicked();
                }
            }
        }

        protected void update_Selected(object sender, MouseMoveEventArgs e)
        {
            if (Mouse.GetPosition(window).X >= Position.X && Mouse.GetPosition(window).Y >= Position.Y &&
                Mouse.GetPosition(window).X <= DownRightCorner.X && Mouse.GetPosition(window).Y <= DownRightCorner.Y)
            {
                SELECTED = true;
            }
            else
            {
                SELECTED = false;
            }
        }

        protected void update_SpritesPosition()
        {
            Sprite.Position = Position;
            SelectSprite.Position = Position;
        }

        protected void update_DownRightCorner()
        {
            DownRightCorner.X = Position.X + WIDTH;
            DownRightCorner.Y = Position.Y + HEIGHT;
        }

        public void set_Window(RenderWindow window)
        {
            this.window = window;
        }

        protected void set_WIDTH(float width)
        {
            WIDTH = width;
        }

        protected void set_WIDTH(int width)
        {
            WIDTH = width;
        }

        protected void set_HEIGHT(float height)
        {
            HEIGHT = height;
        }

        protected void set_HEIGHT(int height)
        {
            HEIGHT = height;
        }

        public void set_PRESSED(bool pressed)
        {
            PRESSED = pressed;
        }

        public bool get_PRESSSED()
        {
            return PRESSED;
        }

        protected void set_Sprite(Sprite sprite)
        {
            Sprite = new Sprite(sprite);
        }

        protected void set_SelectSprite(Sprite selectSprite)
        {
            SelectSprite = new Sprite(selectSprite);
        }

        public void set_Position(Vector2f Position)
        {
            this.Position = Position;

            update_SpritesPosition();
            update_DownRightCorner();
        }

        public void set_Position(float x, float y)
        {
            Position.X = x;
            Position.Y = y;

            update_SpritesPosition();
            update_DownRightCorner();
        }

        public void set_PositionX(float x)
        {
            Position.X = x;

            update_SpritesPosition();
            update_DownRightCorner();
        }

        public void set_PositionY(float y)
        {
            Position.Y = y;

            update_SpritesPosition();
            update_DownRightCorner();
        }

        public float get_PositionX()
        {
            return Position.X;
        }
        public float get_PositionY()
        {
            return Position.Y;
        }

    }
}
