using SFML.Graphics;

namespace Test.Scene
{
    abstract class AbstractScene
    {
        protected Background _background = null;
        protected Test.GUI.AbstractGUI _gui = null;

        public abstract void Generate();
        public abstract void Destroy();
        public abstract void Update();
        public abstract void Draw();
        public abstract void Transition();

    }
}
