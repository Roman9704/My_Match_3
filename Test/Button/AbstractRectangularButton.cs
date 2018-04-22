using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace Test.Button
{
    abstract class AbstractRectangularButton
    {
        public delegate void MethodContainer();
        public event MethodContainer Clicked = delegate { };
        public event MethodContainer UnClicked = delegate { };

        protected Vector2f _position;
        protected Vector2f _downRightCorner;
        protected Sprite _sprite = null;
        protected Sprite _selectSprite = null;
        protected float _width = 0;
        protected float _height = 0;
        protected bool _selected = false;
        protected bool _pressed = false;

        abstract public void Draw();
        abstract public void Update();
        protected void updateClicked(object sender, MouseButtonEventArgs e)
        {
            if (_selected)
            {
                if (_pressed == false)
                {
                    _pressed = true;
                    Clicked();
                }
                else
                {
                    _pressed = false;
                    UnClicked();
                }
            }
        }

        protected void update_selected(object sender, MouseMoveEventArgs e)
        {
            if (Mouse.GetPosition(Initializer.Window).X >= _position.X && Mouse.GetPosition(Initializer.Window).Y >= _position.Y &&
                Mouse.GetPosition(Initializer.Window).X <= _downRightCorner.X && Mouse.GetPosition(Initializer.Window).Y <= _downRightCorner.Y)
            {
                _selected = true;

            }
            else
            {
                _selected = false;
            }
        }

        protected void update_spritesPosition()
        {
            _sprite.Position = _position;
            _selectSprite.Position = _position;
        }

        protected void update_downRightCorner()
        {
            _downRightCorner.X = _position.X + _width;
            _downRightCorner.Y = _position.Y + _height;
        }

        protected void set_width(float width)
        {
            this._width = width;
        }

        protected void set_width(int width)
        {
            this._width = width;
        }

        protected void set_height(float height)
        {
            this._height = height;
        }

        protected void set_height(int height)
        {
            this._height = height;
        }

        public void set_pressed(bool pressed)
        {
            this._pressed = pressed;
        }

        public bool get_pressed()
        {
            return _pressed;
        }

        protected void set_sprite(Sprite sprite)
        {
            this._sprite = new Sprite(sprite);
        }

        protected void set_selectSprite(Sprite selectSprite)
        {
            this._selectSprite = new Sprite(selectSprite);
        }

        public void set_position(Vector2f Position)
        {
            this._position = Position;

            update_spritesPosition();
            update_downRightCorner();
        }

        public void set_position(float x, float y)
        {
            _position.X = x;
            _position.Y = y;

            update_spritesPosition();
            update_downRightCorner();
        }

        public void set_positionX(float x)
        {
            _position.X = x;

            update_spritesPosition();
            update_downRightCorner();
        }

        public void set_positionY(float y)
        {
            _position.Y = y;

            update_spritesPosition();
            update_downRightCorner();
        }

        public float get_positionX()
        {
            return _position.X;
        }
        public float get_positionY()
        {
            return _position.Y;
        }

    }
}
