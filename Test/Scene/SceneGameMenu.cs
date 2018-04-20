using SFML.Graphics;

namespace Test
{
    class SceneGameMenu : AbstractScene
    {
        MenuButton menuButton = null;

        public SceneGameMenu()
        {

        }

        public override void Generate()
        {
            menuButton = new MenuButton();
            menuButton.Clicked += Transition;

            background = new Background();
        }

        public override void Destroy()
        {
            menuButton = null;

            background = null;
        }

        public override void Update()
        {

        }

        public override void Draw()
        {
            background.Draw();
            menuButton.Draw();
        }

        public override void Transition()
        {
            menuButton.Clicked -= Transition;
            Initializer.sceneHandler.Transition();
        }
    }
}
