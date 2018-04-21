using System;

using SFML.Graphics;

namespace Test
{
    static class Initializer
    {
        public const uint WindowWidth = ((uint)Element.elementSize + Grid.partitionWidth) * World.AmountOfElements + Grid.coordinateShift;
        public const uint WindowHeight = WindowWidth + GameInterface.heightTimerAndScore;

        public static RenderWindow Window = null;
        public static SceneHandler SceneHandler = null;
        public static GameLoop GameLoop = null;

        public static void initialization()
        {
            initWindow();
            initContent();
            initSceneHandler();
            initGameLoop();
        }

        private static void initWindow()
        {
            Window = new RenderWindow(new SFML.Window.VideoMode(WindowWidth, WindowHeight), "Test task for Summer practice, by Anoshin Roman");
            Window.SetVerticalSyncEnabled(true);
            //window.SetFramerateLimit(60);

            Window.Closed += WindowClosed;
        }
        
        private static void initContent()
        {
            Content.Load();
        }
        private static void initSceneHandler()
        {
            SceneHandler = new SceneHandler();
        }

        private static void initGameLoop()
        {
            GameLoop = new GameLoop();
        }

        private static void WindowClosed(object sender, EventArgs e)
        {
            Window.Close();
        }
    }
}
