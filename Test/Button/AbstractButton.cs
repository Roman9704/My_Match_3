using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Button
{
    abstract class AbstractButton
    {
        public delegate void MethodContainer();
        public event MethodContainer Clicked = delegate { };
        public event MethodContainer UnClicked = delegate { };

        protected Vector2f _position;
        protected Sprite _sprite = null;
        protected Sprite _selectSprite = null;
        protected bool _selected = false;
        protected bool _pressed = false;

        public AbstractButton(Sprite sprite, Sprite selectSprite, Vector2f position)
        {
            set_sprite(sprite);
            set_selectSprite(selectSprite);
            set_position(position);

            Initializer.Window.MouseMoved += update_selected;
            Initializer.Window.MouseButtonPressed += updateClicked;
        }

        public AbstractButton(Sprite sprite, Sprite selectSprite, float positionX, float positionY)
        {
            set_sprite(sprite);
            set_selectSprite(selectSprite);
            set_position(positionX, positionY);

            Initializer.Window.MouseMoved += update_selected;
            Initializer.Window.MouseButtonPressed += updateClicked;
        }

        public virtual void Destroy()
        {
            Initializer.Window.MouseMoved -= update_selected;
            Initializer.Window.MouseButtonPressed -= updateClicked;
        }

        protected abstract void update_selected(object sender, MouseMoveEventArgs e);

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

        public virtual void Draw()
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

        public virtual void Update() { }

        protected void update_spritesPosition()
        {
            _sprite.Position = _position;
            _selectSprite.Position = _position;
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

        public virtual void set_position(Vector2f Position)
        {
            this._position = Position;

            update_spritesPosition();
        }

        public virtual void set_position(float x, float y)
        {
            _position.X = x;
            _position.Y = y;

            update_spritesPosition();
        }

        public virtual void set_positionX(float x)
        {
            _position.X = x;

            update_spritesPosition();
        }

        public virtual void set_positionY(float y)
        {
            _position.Y = y;

            update_spritesPosition();
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
