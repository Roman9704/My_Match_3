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

            _background = new Background(BackgroundType.DarkPurple);
        }

        public override void Destroy()
        {
            menuButton.Clicked -= Transition;
            menuButton = null;

            _background = null;
        }

        public override void Update()
        {

        }

        public override void Draw()
        {
            _background.Draw();
            menuButton.Draw();
        }

        public override void Transition()
        {
            menuButton.Clicked -= Transition;
            Initializer.SceneHandler.Transition();
        }
    }
}
