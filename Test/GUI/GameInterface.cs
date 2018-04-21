using SFML.Graphics;
using SFML.System;
using System;

namespace Test
{
    class GameInterface : AbstractGUI
    {
        public const uint heightTimerAndScore = World.AmountOfElements * 10;

        AbstractScene _scene = null;

        Text textScore = null;
        Text textTimer = null;
        float timerTime = 240;

        const int sizeText = World.AmountOfElements * 4;
        Color textColor = new Color(48, 10, 36);

        public GameInterface(AbstractScene scene)
        {
            set_Scene(scene);
        }

        public override void Generate()
        {
            textScore = new Text("Score: ", Content.Font, sizeText);
            textScore.Position = new Vector2f(Initializer.WindowWidth / 2 + 45, Initializer.WindowHeight - sizeText * 2);
            textScore.Color = textColor;

            textTimer = new Text("Timer: ", Content.Font, sizeText);
            textTimer.Position = new Vector2f(15, Initializer.WindowHeight - sizeText * 2);
            textTimer.Color = textColor;
        }

        public override void Destroy()
        {
            _scene = null;

            textScore = null;
            textTimer = null;
        }

        public override void Update()
        {
            textScore.DisplayedString = "Score: " + GameLogic.Score.ToString();
            timerTime -= GameLoop.dt;
            textTimer.DisplayedString = "Timer: " + Convert.ToInt32(timerTime).ToString() + "sec.";
            if (timerTime <= 0)
            {
                _scene.Transition();
            }
        }

        public override void Draw()
        {
            Initializer.Window.Draw(textTimer);
            Initializer.Window.Draw(textScore);
        }

        private void set_Scene(AbstractScene scene)
        {
            this._scene = scene;
        }
    }
}
