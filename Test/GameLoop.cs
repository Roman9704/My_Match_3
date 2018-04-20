using SFML.Graphics;
using SFML.System;

namespace Test
{
    class GameLoop
    {
        Clock clock;
        public static float dt = 0;
        //const float DENOMINATOR = 1;

        public GameLoop()
        {
            clock = new Clock();
        }

        public void Update()
        {
            while (Initializer.window.IsOpen)
            {
                Initializer.window.DispatchEvents();

                if (Initializer.window.HasFocus())
                {
                    update_time();

                    Initializer.sceneHandler.Update();

                    Initializer.sceneHandler.Draw();

                    Initializer.window.Display();
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
