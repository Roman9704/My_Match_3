using SFML.System;
using Pulse.GUI.GUIObject.Button;

namespace Pulse
{
    public enum ElementType
    {
        None,
        Blue,
        Green,
        Orange,
        Pink,
        Yellow
    }

    public enum MoveType
    {
        None,
        Up,
        Down,
        Left,
        Right
    }

    public class Element : RectangularButton
    {
        public const int ElementSize = 60;
        public const float MoveSpeed = 200f;
        public int Points = 1;

        public ElementType Type = ElementType.None;
        public MoveType MoveType = MoveType.None;
        public Vector2f NewPosition;

        public Element(ElementType type, Vector2f Position)
            : base(new Vector2f(ElementSize, ElementSize), Content.ElementSprite[(int)type], Content.SelectSprite, Position)
        {
            Type = type;
        }

        public Element(ElementType type, Vector2f Position, Vector2f newPosition, MoveType moveType)
            : this(type, Position)
        {
            NewPosition = newPosition;
            MoveType = moveType;
        }

        public override void Update()
        {
            UpdateMove();
        }

        private void UpdateMove()
        {
            if (MoveType != MoveType.None)
            {
                switch (MoveType)
                {
                    case MoveType.Up:
                        MoveUp();
                        break;
                    case MoveType.Down:
                        MoveDown();
                        break;
                    case MoveType.Left:
                        MoveLeft();
                        break;
                    case MoveType.Right:
                        MoveRight();
                        break;
                }
            }
        }

        private void MoveUp()
        {
            Position = new Vector2f(Position.X, Position.Y - GameLoop.Dt * MoveSpeed);

            if (Position.Y <= NewPosition.Y)
            {
                MoveType = MoveType.None;
                Position = NewPosition;
            }
        }

        private void MoveDown()
        {
            Position = new Vector2f(Position.X, Position.Y + GameLoop.Dt * MoveSpeed);

            if (Position.Y >= NewPosition.Y)
            {
                MoveType = MoveType.None;
                Position = NewPosition;
            }
        }

        private void MoveLeft()
        {
            Position = new Vector2f(Position.X - GameLoop.Dt * MoveSpeed, Position.Y);

            if (Position.X <= NewPosition.X)
            {
                MoveType = MoveType.None;
                Position = NewPosition;
            }
        }

        private void MoveRight()
        {
            Position = new Vector2f(Position.X + GameLoop.Dt * MoveSpeed, Position.Y);

            if (Position.X >= NewPosition.X)
            {
                MoveType = MoveType.None;
                Position = NewPosition;
            }
        }

        public override void Draw()
        {
            Initializer.Window.Draw(Sprite);
            if (Selected || Pressed)
            {
                Initializer.Window.Draw(SelectSprite);
            }
        }
    }
}
