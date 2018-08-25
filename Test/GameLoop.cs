using SFML.System;

namespace Pulse
{
    class GameLoop
    {
        private Clock clock;
        public static float Dt = 0;
        // Control the speed of the game
        //const float denominator = 1; 

        public GameLoop()
        {
            clock = new Clock();
        }

        public void Update()
        {
            while (Initializer.Window.IsOpen)
            {
                Initializer.Window.DispatchEvents();

                UpdateDt();

                if (Initializer.Window.HasFocus())
                {
                    Initializer.SceneHandler.Update();

                    Initializer.SceneHandler.Draw();

                    Initializer.Window.Display();
                }
            }
        }

        private void UpdateDt()
        {
            Dt = clock.ElapsedTime.AsSeconds();
            clock.Restart();
            //Dt /= denominator;
        }
    }
}
