using SFML.Graphics;
using SFML.System;
using System;

namespace Test
{
    class GameInterface
    {
        public const int HEIGHT_Timer_and_Score = World.AMOUNT_OF_ELEMENTS * 10;

        RenderWindow window = null;
        AScene scene = null;

        Text textScore = null;
        Text textTimer = null;
        const float timeLimit = 240;
        float TimerTime = timeLimit;

        const int sizeText = World.AMOUNT_OF_ELEMENTS * 4;
        Color textColor = new Color(48, 10, 36);

        GameLogic gameLogic = null;

        public GameInterface(RenderWindow window, AScene scene, GameLogic gameLogic)
        {
            set_Window(window);
            set_Scene(scene);
            set_GameLogic(gameLogic);

            textScore = new Text("Score: ", Content.font, sizeText);
            textScore.Position = new Vector2f(Initializer.WINDOW_WIDTH / 2 + 15, Initializer.WINDOW_HEIGHT - sizeText * 2);
            textScore.Color = textColor;

            textTimer = new Text("Timer: ", Content.font, sizeText);
            textTimer.Position = new Vector2f(30, Initializer.WINDOW_HEIGHT - sizeText * 2);
            textTimer.Color = textColor;
        }

        public void Update()
        {
            textScore.DisplayedString = "Score: " + gameLogic.get_SCORE().ToString();
            TimerTime -= GameLoop.dt;
            textTimer.DisplayedString = "Timer: " + Convert.ToInt32(TimerTime).ToString();
            if (TimerTime <= 0)
            {
                scene.Transition();
            }
        }

        public void Draw()
        {
            window.Draw(textTimer);
            window.Draw(textScore);
        }

        private void set_Window(RenderWindow window)
        {
            this.window = window;
        }

        private void set_Scene(AScene scene)
        {
            this.scene = scene;
        }

        private void set_GameLogic(GameLogic gameLogic)
        {
            this.gameLogic = gameLogic;
        }
    }
}
