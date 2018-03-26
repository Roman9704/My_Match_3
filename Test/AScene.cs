using SFML.Graphics;

namespace Test
{
    abstract class AScene
    {
        protected bool SceneGenerate = false;
        protected Background background = null;
        protected RenderWindow window = null;
        protected SceneHandler sceneHandler = null;

        public abstract void Generate();
        public abstract void Update();
        public abstract void Draw();
        public abstract void Transition();

        public void set_Window(RenderWindow window)
        {
            this.window = window;
        }

        public void set_SceneHandler(SceneHandler sceneHandler)
        {
            this.sceneHandler = sceneHandler;
        }

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
