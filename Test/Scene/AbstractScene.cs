namespace Pulse.Scene
{
    public abstract class AbstractScene
    {
        protected Background background = null;
        protected GUI.AbstractGUI gui = null;

        public abstract void Generate();
        public abstract void Destroy();
        public abstract void Update();
        public abstract void Draw();
        public abstract void Transition();

    }
}
