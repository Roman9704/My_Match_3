using SFML.Graphics;

namespace Test
{
    abstract class AbstractScene
    {
        protected Background _background = null;

        public abstract void Generate();
        public abstract void Destroy();
        public abstract void Update();
        public abstract void Draw();
        public abstract void Transition();

    }
}
