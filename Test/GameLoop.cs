using SFML.Graphics;
using SFML.System;

namespace Test
{
    class GameLoop
    {
        Clock _clock;
        public static float dt = 0;
        //const float DENOMINATOR = 1;

        public GameLoop()
        {
            _clock = new Clock();
        }

        public void Update()
        {
            while (Initializer.Window.IsOpen)
            {
                Initializer.Window.DispatchEvents();

                update_dt();

                if (Initializer.Window.HasFocus())
                {
                    Initializer.SceneHandler.Update();

                    Initializer.SceneHandler.Draw();

                    Initializer.Window.Display();
                }
            }
        }

        private void update_dt()
        {
            dt = _clock.ElapsedTime.AsSeconds();
            _clock.Restart();
            //dt /= DENOMINATOR; // Скорость игры
        }
    }
}
