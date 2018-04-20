using SFML.Graphics;
using SFML.System;
using System;

namespace Test
{
    class GameInterface : AbstractGUI
    {
        public const uint HEIGHT_Timer_and_Score = World.AMOUNT_OF_ELEMENTS * 10;

        AbstractScene scene = null;

        Text textScore = null;
        Text textTimer = null;
        float timerTime = 240;

        const int sizeText = World.AMOUNT_OF_ELEMENTS * 4;
        Color textColor = new Color(48, 10, 36);

        public GameInterface(AbstractScene scene)
        {
            set_Scene(scene);
        }

        public override void Generate()
        {
            textScore = new Text("Score: ", Content.font, sizeText);
            textScore.Position = new Vector2f(Initializer.WINDOW_WIDTH / 2 + 15, Initializer.WINDOW_HEIGHT - sizeText * 2);
            textScore.Color = textColor;

            textTimer = new Text("Timer: ", Content.font, sizeText);
            textTimer.Position = new Vector2f(15, Initializer.WINDOW_HEIGHT - sizeText * 2);
            textTimer.Color = textColor;
        }

        public override void Destroy()
        {
            scene = null;

            textScore = null;
            textTimer = null;
        }

        public override void Update()
        {
            textScore.DisplayedString = "Score: " + GameLogic.SCORE.ToString();
            timerTime -= GameLoop.dt;
            textTimer.DisplayedString = "Timer: " + Convert.ToInt32(timerTime).ToString() + "sec.";
            if (timerTime <= 0)
            {
                scene.Transition();
            }
        }

        public override void Draw()
        {
            Initializer.window.Draw(textTimer);
            Initializer.window.Draw(textScore);
        }

        private void set_Scene(AbstractScene scene)
        {
            this.scene = scene;
        }
    }
}
