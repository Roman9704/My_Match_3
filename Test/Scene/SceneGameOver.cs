namespace Pulse.Scene
{
    public class SceneGameOver : AbstractScene
    {
        public SceneGameOver()
        {

        }

        public override void Generate()
        {
            background = new Background(BackgroundType.DarkPurple);

            gui = new GUI.GameOverInterface(this);
            gui.Generate();
        }

        public override void Destroy()
        {
            background = null;

            gui.Destroy();
            gui = null;
        }

        public override void Update()
        {
            gui.Update();
        }

        public override void Draw()
        {
            background.Draw();
            gui.Draw();
        }

        public override void Transition()
        {
            Initializer.SceneHandler.Transition();
        }
    }
}
