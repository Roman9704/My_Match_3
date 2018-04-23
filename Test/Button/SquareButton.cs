using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace Test.Button
{
    class SquareButton : AbstractButton
    {
        protected float _size = 0;
        protected Vector2f _downRightCorner;

        public SquareButton(float size, Sprite sprite, Sprite selectSprite, Vector2f position)
            : base(sprite, selectSprite, position)
        {
            set_size(size);

            update_downRightCorner();
        }

        public SquareButton(float size, Sprite sprite, Sprite selectSprite, float positionX, float positionY)
            : base(sprite, selectSprite, positionX, positionY)
        {
            set_size(size);

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

        protected void set_size(float size)
        {
            _size = size;
        }

        protected void update_downRightCorner()
        {
            _downRightCorner.X = _position.X + _size;
            _downRightCorner.Y = _position.Y + _size;
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
