using SFML.System;
using SFML.Graphics;
using SFML.Window;

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
        public const int elementSize = 60;
        public const float elementMoveSpeed = 200f;
        const int points = 1;

        ElementType type = ElementType.NONE;
        MoveType moveType = MoveType.NONE;
        Vector2f newPosition;

        public Element(ElementType type, Vector2f Position)
        {
            set_width(elementSize);
            set_height(elementSize);
            set_ElementType(type);


            set_sprite(Content.ElementSprite[(int)type]);
            set_selectSprite(Content.SelectSprite);
            set_position(Position);

            Initializer.Window.MouseMoved += update_selected;
            Initializer.Window.MouseButtonPressed += updateClicked;
        }

        public Element(ElementType type, Vector2f Position, Vector2f newPosition, MoveType moveType)
        {
            set_width(elementSize);
            set_height(elementSize);
            set_ElementType(type);

            set_sprite(Content.ElementSprite[(int)type]);
            set_selectSprite(Content.SelectSprite);
            set_position(Position);
            set_newPosition(newPosition);
            set_MoveType(moveType);

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
            update_Move();
        }

        private void update_Move()
        {
            if (moveType != MoveType.NONE)
            {
                switch (moveType)
                {
                    case MoveType.UP:
                        Move_UP();
                        break;
                    case MoveType.DOWN:
                        Move_DOWN();
                        break;
                    case MoveType.LEFT:
                        Move_LEFT();
                        break;
                    case MoveType.RIGHT:
                        Move_RIGHT();
                        break;
                }
            }
        }

        private void Move_UP()
        {
            set_positionY(_position.Y - GameLoop.dt * elementMoveSpeed);

            if (_position.Y <= newPosition.Y)
            {
                moveType = MoveType.NONE;
                set_positionY(newPosition.Y);
            }
        }

        private void Move_DOWN()
        {
            set_positionY(_position.Y + GameLoop.dt * elementMoveSpeed);

            if (_position.Y >= newPosition.Y)
            {
                moveType = MoveType.NONE;
                set_positionY(newPosition.Y);
            }
        }

        private void Move_LEFT()
        {
            set_positionX(_position.X - GameLoop.dt * elementMoveSpeed);

            if (_position.X <= newPosition.X)
            {
                moveType = MoveType.NONE;
                set_positionX(newPosition.X);
            }
        }

        private void Move_RIGHT()
        {
            set_positionX(_position.X + GameLoop.dt * elementMoveSpeed);

            if (_position.X >= newPosition.X)
            {
                moveType = MoveType.NONE;
                set_positionX(newPosition.X);
            }
        }

        public void set_newPosition(Vector2f newPosition)
        {
            this.newPosition = newPosition;
        }

        public void set_newPositionX(float x)
        {
            this.newPosition.X = x;
        }

        public void set_newPositionY(float y)
        {
            this.newPosition.Y = y;
        }

        public float get_newPositionX()
        {
            return newPosition.X;
        }

        public float get_newPositionY()
        {
            return newPosition.Y;
        }

        public void set_MoveType(MoveType moveType)
        {
            this.moveType = moveType;
        }

        public MoveType get_MoveType()
        {
            return moveType;
        }

        public void set_ElementType(ElementType type)
        {
            this.type = type;
        }

        public ElementType get_ElementType()
        {
            return type;
        }

        public int get_POINTS()
        {
            return points;
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
