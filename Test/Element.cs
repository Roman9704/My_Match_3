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

    class Element : ARectangularButton
    {
        public const float ELEMENT_MOVE_SPEED = 155f;
        const int POINTS = 50;

        ElementType type = ElementType.NONE;
        MoveType moveType = MoveType.NONE;
        Vector2f newPosition;

        public Element(ElementType type, Vector2f Position)
        {
            set_Window(Initializer.window);
            set_WIDTH(60);
            set_HEIGHT(60);
            set_ElementType(type);


            set_Sprite(Content.ElementSprite[(int)type]);
            set_SelectSprite(Content.SelectSprite);
            set_Position(Position);

            window.MouseMoved += update_Selected;
            window.MouseButtonPressed += update_Clicked;
        }

        public Element(ElementType type, Vector2f Position, Vector2f newPosition, MoveType moveType)
        {
            set_Window(Initializer.window);
            set_WIDTH(60);
            set_HEIGHT(60);
            set_ElementType(type);

            set_Sprite(Content.ElementSprite[(int)type]);
            set_SelectSprite(Content.SelectSprite);
            set_Position(Position);
            set_newPosition(newPosition);
            set_MoveType(moveType);

            window.MouseMoved += update_Selected;
            window.MouseButtonPressed += update_Clicked;
        }

        ~Element()
        {
            window.MouseMoved -= update_Selected;
            window.MouseButtonPressed -= update_Clicked;
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
            set_PositionY(Position.Y - GameLoop.dt * ELEMENT_MOVE_SPEED);

            if (Position.Y <= newPosition.Y)
            {
                moveType = MoveType.NONE;
                set_PositionY(newPosition.Y);
            }
        }

        private void Move_DOWN()
        {
            set_PositionY(Position.Y + GameLoop.dt * ELEMENT_MOVE_SPEED);

            if (Position.Y >= newPosition.Y)
            {
                moveType = MoveType.NONE;
                set_PositionY(newPosition.Y);
            }
        }

        private void Move_LEFT()
        {
            set_PositionX(Position.X - GameLoop.dt * ELEMENT_MOVE_SPEED);

            if (Position.X <= newPosition.X)
            {
                moveType = MoveType.NONE;
                set_PositionX(newPosition.X);
            }
        }

        private void Move_RIGHT()
        {
            set_PositionX(Position.X + GameLoop.dt * ELEMENT_MOVE_SPEED);

            if (Position.X >= newPosition.X)
            {
                moveType = MoveType.NONE;
                set_PositionX(newPosition.X);
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
            return POINTS;
        }

        public override void Draw()
        {
            window.Draw(Sprite);
            if (SELECTED || PRESSED)
            {
                window.Draw(SelectSprite);
            }
        }
    }
}
