using SFML.System;
using Pulse.GUI.GUIObject.Button;

namespace Pulse.GUI
{
    public class GameMenuInterface : AbstractGUI
    {
        private RectangularButton menuButton = null;

        public GameMenuInterface(Pulse.Scene.AbstractScene scene)
        {
            Scene = scene;
        }

        public override void Generate()
        {
            var position = new Vector2f(Initializer.WindowWidth / 2 - 120 / 2, Initializer.WindowHeight / 2 - 60 / 2);
            var size = new Vector2f(120, 60);
            menuButton = new RectangularButton(size, Content.ButtonSprite0, Content.ButtonSprite1, position);
            menuButton.Clicked += Scene.Transition;
        }

        public override void Destroy()
        {
            menuButton.Clicked -= Scene.Transition;
            menuButton.Destroy();
            menuButton = null;
        }

        public override void Update()
        {
        }

        public override void Draw()
        {
            menuButton.Draw();
        }
    }
}
