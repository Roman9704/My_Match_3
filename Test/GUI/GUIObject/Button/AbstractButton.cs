using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Pulse.GUI.GUIObject.Button
{
    public abstract class AbstractButton : AbstractGUIObject
    {
        public delegate void MethodContainer();
        public event MethodContainer Clicked = delegate { };
        public event MethodContainer UnClicked = delegate { };

        private Vector2f position;
        public override Vector2f Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
                UpdateSpritesPosition();
            }
        }
        private Sprite sprite = null;
        public Sprite Sprite
        {
            get
            {
                return sprite;
            }
            set
            {
                sprite = new Sprite(value);
            }
        }
        private Sprite selectSprite = null;
        public Sprite SelectSprite
        {
            get
            {
                return selectSprite;
            }
            set
            {
                selectSprite = new Sprite(value);
            }
        }
        public bool Selected = false;
        public bool Pressed = false;

        public AbstractButton(Sprite sprite, Sprite selectSprite, Vector2f position)
        {
            Sprite = sprite;
            SelectSprite = selectSprite;
            Position = position;
            
            Initializer.Window.MouseMoved += UpdateSelected;
            Initializer.Window.MouseButtonPressed += UpdateClicked;
        }

        public virtual void Destroy()
        {
            Initializer.Window.MouseMoved -= UpdateSelected;
            Initializer.Window.MouseButtonPressed -= UpdateClicked;
        }

        protected abstract void UpdateSelected(object sender, MouseMoveEventArgs e);

        protected void UpdateClicked(object sender, MouseButtonEventArgs e)
        {
            if (Selected)
            {
                if (Pressed == false)
                {
                    Pressed = true;
                    Clicked();
                }
                else
                {
                    Pressed = false;
                    UnClicked();
                }
            }
        }

        public override void Draw()
        {
            if (Selected)
            {
                Initializer.Window.Draw(SelectSprite);
            }
            else
            {
                Initializer.Window.Draw(Sprite);
            }
        }

        protected void UpdateSpritesPosition()
        {
            Sprite.Position = Position;
            SelectSprite.Position = Position;
        }
    }
}
