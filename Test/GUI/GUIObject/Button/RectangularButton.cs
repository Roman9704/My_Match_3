using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Pulse.GUI.GUIObject.Button
{
    public class RectangularButton : AbstractButton
    {
        public Vector2f Size;
        public float Width
        {
            get
            {
                return Size.X;
            }
            set
            {
                Size.X = value;
            }
        }
        public float Height
        {
            get
            {
                return Size.Y;
            }
            set
            {
                Size.Y = value;
            }
        }
        public Vector2f DownRightCorner { get; private set; }
        public override Vector2f Position
        {
            get
            {
                return base.Position;
            }
            set
            {
                base.Position = value;
                UpdateDownRightCorner();
            }
        }

        public RectangularButton(Vector2f size, Sprite sprite, Sprite selectSprite, Vector2f position)
            : base(sprite, selectSprite, position)
        {
            Size = size;
            UpdateDownRightCorner();
        }

        protected override void UpdateSelected(object sender, MouseMoveEventArgs e)
        {
            if (Mouse.GetPosition(Initializer.Window).X >= Position.X && Mouse.GetPosition(Initializer.Window).Y >= Position.Y &&
                Mouse.GetPosition(Initializer.Window).X <= DownRightCorner.X && Mouse.GetPosition(Initializer.Window).Y <= DownRightCorner.Y)
            {
                Selected = true;
            }
            else
            {
                Selected = false;
            }
        }

        private void UpdateDownRightCorner()
        {
            DownRightCorner = Position + Size;
        }
    }
}
