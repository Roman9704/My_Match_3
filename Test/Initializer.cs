using System;

using SFML.Graphics;
using SFML.Window;

namespace Test
{
    class Initializer
    {
        public const int WINDOW_WIDTH = (60 + Grid.PARTITION_WIDTH) * World.AMOUNT_OF_ELEMENTS + Grid.COORDINATE_SHIFT;
        public const int WINDOW_HEIGHT = WINDOW_WIDTH + GameInterface.HEIGHT_Timer_and_Score;

        public static RenderWindow window = null;
        public static SceneHandler sceneHandler = null;
        public static GameLoop gameLoop = null;

        public static void initialization()
        {
            init_Window();
            init_Content();
            init_SceneHandler();
            init_GameLoop();
        }

        private static void init_Window()
        {
            window = new RenderWindow(new VideoMode(WINDOW_WIDTH, WINDOW_HEIGHT), "Test task for Summer practice, by Anoshin Roman");
            window.SetVerticalSyncEnabled(true);

            window.Closed += Window_Closed;
        }
        
        private static void init_Content()
        {
            Content.Load();
        }
        private static void init_SceneHandler()
        {
            sceneHandler = new SceneHandler(window);
        }

        private static void init_GameLoop()
        {
            gameLoop = new GameLoop(window, sceneHandler);
        }

        private static void Window_Closed(object sender, EventArgs e)
        {
            window.Close();
        }
    }
}
