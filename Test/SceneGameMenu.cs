using SFML.Graphics;

namespace Test
{
    class SceneGameMenu : AScene
    {
        MenuButton menuButton = null;

        public SceneGameMenu(RenderWindow window, SceneHandler sceneHandler)
        {
            set_Window(window);
            set_SceneHandler(sceneHandler);
        }

        public override void Generate()
        {
            menuButton = new MenuButton(window);
            menuButton.Clicked += Transition;

            background = new Background(window);
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
            sceneHandler.set_CurrentScene(SceneType.Game);
        }
    }
}
