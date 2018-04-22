using SFML.System;
using SFML.Graphics;
using SFML.Window;
using Test.Button;

namespace Test
{
    enum ElementType
    {
        NONE,
        BLUE,
        GREEN,
        ORANGE,
        PINK,
        YELLOW
    }

    enum MoveType
    {
        NONE,
        UP,
        DOWN,
        LEFT,
        RIGHT
    }

    class Element : AbstractRectangularButton
    {
        public const int ElementSize = 60;
        public const float ElementMoveSpeed = 200f;
        const int Points = 1;

        ElementType _type = ElementType.NONE;
        MoveType _moveType = MoveType.NONE;
        Vector2f _newPosition;

        public Element(ElementType type, Vector2f Position)
        {
            set_width(ElementSize);
            set_height(ElementSize);
            set_elementType(type);


            set_sprite(Content.ElementSprite[(int)type]);
            set_selectSprite(Content.SelectSprite);
            set_position(Position);

            Initializer.Window.MouseMoved += update_selected;
            Initializer.Window.MouseButtonPressed += updateClicked;
        }

        public Element(ElementType type, Vector2f Position, Vector2f newPosition, MoveType moveType)
        {
            set_width(ElementSize);
            set_height(ElementSize);
            set_elementType(type);

            set_sprite(Content.ElementSprite[(int)type]);
            set_selectSprite(Content.SelectSprite);
            set_position(Position);
            set_newPosition(newPosition);
            set_moveType(moveType);

            Initializer.Window.MouseMoved += update_selected;
            Initializer.Window.MouseButtonPressed += updateClicked;
        }

        public void Destroy()
        {
            Initializer.Window.MouseMoved -= update_selected;
            Initializer.Window.MouseButtonPressed -= updateClicked;
        }

        ~Element()
        {
            Initializer.Window.MouseMoved -= update_selected;
            Initializer.Window.MouseButtonPressed -= updateClicked;
        }

        public override void Update()
        {
            updateMove();
        }

        private void updateMove()
        {
            if (_moveType != MoveType.NONE)
            {
                switch (_moveType)
                {
                    case MoveType.UP:
                        moveUP();
                        break;
                    case MoveType.DOWN:
                        moveDOWN();
                        break;
                    case MoveType.LEFT:
                        moveLEFT();
                        break;
                    case MoveType.RIGHT:
                        moveRIGHT();
                        break;
                }
            }
        }

        private void moveUP()
        {
            set_positionY(_position.Y - GameLoop.dt * ElementMoveSpeed);

            if (_position.Y <= _newPosition.Y)
            {
                _moveType = MoveType.NONE;
                set_positionY(_newPosition.Y);
            }
        }

        private void moveDOWN()
        {
            set_positionY(_position.Y + GameLoop.dt * ElementMoveSpeed);

            if (_position.Y >= _newPosition.Y)
            {
                _moveType = MoveType.NONE;
                set_positionY(_newPosition.Y);
            }
        }

        private void moveLEFT()
        {
            set_positionX(_position.X - GameLoop.dt * ElementMoveSpeed);

            if (_position.X <= _newPosition.X)
            {
                _moveType = MoveType.NONE;
                set_positionX(_newPosition.X);
            }
        }

        private void moveRIGHT()
        {
            set_positionX(_position.X + GameLoop.dt * ElementMoveSpeed);

            if (_position.X >= _newPosition.X)
            {
                _moveType = MoveType.NONE;
                set_positionX(_newPosition.X);
            }
        }

        public void set_newPosition(Vector2f newPosition)
        {
            this._newPosition = newPosition;
        }

        public void set_newPositionX(float x)
        {
            this._newPosition.X = x;
        }

        public void set_newPositionY(float y)
        {
            this._newPosition.Y = y;
        }

        public float get_newPositionX()
        {
            return _newPosition.X;
        }

        public float get_newPositionY()
        {
            return _newPosition.Y;
        }

        public void set_moveType(MoveType moveType)
        {
            this._moveType = moveType;
        }

        public MoveType get_moveType()
        {
            return _moveType;
        }

        public void set_elementType(ElementType type)
        {
            this._type = type;
        }

        public ElementType get_elementType()
        {
            return _type;
        }

        public int getPoints()
        {
            return Points;
        }

        public override void Draw()
        {
            Initializer.Window.Draw(_sprite);
            if (_selected || _pressed)
            {
                Initializer.Window.Draw(_selectSprite);
            }
        }
    }
}
