using SFML.Graphics;

namespace Test.Scene
{
    class SceneGameMenu : AbstractScene
    {
        

        public SceneGameMenu()
        {

        }

        public override void Generate()
        {
            _background = new Background(BackgroundType.DarkPurple);

            _gui = new GUI.GameMenuInterface(this);
            _gui.Generate();
        }

        public override void Destroy()
        {
             _background = null;

            _gui.Destroy();
            _gui = null;
        }

        public override void Update()
        {
            _gui.Update();
        }

        public override void Draw()
        {
            _background.Draw();
            _gui.Draw();
        }

        public override void Transition()
        {
            Initializer.SceneHandler.Transition();
        }
    }
}
