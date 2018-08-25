using SFML.System;

namespace Pulse.GUI.GUIObject
{
    public abstract class AbstractGUIObject
    {
        public abstract Vector2f Position { get; set; }

        public abstract void Draw();
        public virtual void Update() { }
    }
}
