using SFML.Graphics;

namespace Test
{
    abstract class AbstractScene
    {
        protected bool SceneGenerate = false;
        protected Background background = null;

        public abstract void Generate();
        public abstract void Destroy();
        public abstract void Update();
        public abstract void Draw();
        public abstract void Transition();

        protected void set_SceneGenerate(bool ScG)
        {
            SceneGenerate = ScG;
        }

        public bool get_SceneGenerate()
        {
            return SceneGenerate;
        }
    }
}
