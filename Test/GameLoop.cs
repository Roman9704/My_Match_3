using SFML.Graphics;
using SFML.System;

namespace Test
{
    class GameLoop
    {
        Clock clock;
        public static float dt = 0;
        //const float DENOMINATOR = 1;

        RenderWindow window = null;
        SceneHandler sceneHandler = null;

        public GameLoop(RenderWindow window, SceneHandler sceneHandler)
        {
            this.window = window;
            this.sceneHandler = sceneHandler;
            clock = new Clock();
        }

        public void Update()
        {
            while (window.IsOpen)
            {
                window.DispatchEvents();

                if (window.HasFocus())
                {
                    update_time();

                    sceneHandler.Update();

                    sceneHandler.Draw();

                    window.Display();
                }
            }
        }

        private void update_time()
        {
            dt = clock.ElapsedTime.AsSeconds();
            clock.Restart();
            //dt /= DENOMINATOR; // Скорость игры
        }
    }
}
