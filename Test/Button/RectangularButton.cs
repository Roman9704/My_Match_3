using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace Test.Button
{
    class RectangularButton : AbstractButton
    {
        protected Vector2f _downRightCorner;
        protected float _width = 0;
        protected float _height = 0;

        public RectangularButton(float windth, float height, Sprite sprite, Sprite selectSprite, Vector2f position)
            : base(sprite, selectSprite, position)
        {
            set_width(windth);
            set_height(height);

            update_downRightCorner();
        }

        public RectangularButton(float windth, float height, Sprite sprite, Sprite selectSprite, float positionX, float positionY)
            : base(sprite, selectSprite, positionX, positionY)
        {
            set_width(windth);
            set_height(height);

            update_downRightCorner();
        }

        protected override void update_selected(object sender, MouseMoveEventArgs e)
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

        public override void set_position(Vector2f Position)
        {
            this._position = Position;

            update_spritesPosition();
            update_downRightCorner();
        }

        public override void set_position(float x, float y)
        {
            _position.X = x;
            _position.Y = y;

            update_spritesPosition();
            update_downRightCorner();
        }

        public override void set_positionX(float x)
        {
            _position.X = x;

            update_spritesPosition();
            update_downRightCorner();
        }

        public override void set_positionY(float y)
        {
            _position.Y = y;

            update_spritesPosition();
            update_downRightCorner();
        }
    }
}
