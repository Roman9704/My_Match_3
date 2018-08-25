using System;

using SFML.Graphics;
using Pulse.Scene;
using Pulse.World;

namespace Pulse
{
    static class Initializer
    {
        public const uint WindowWidth = ((uint)Element.ElementSize + Grid.GameGrid.PartitionWidth) * GameWorld.AmountOfElements + Grid.GameGrid.CoordinateShift;
        public const uint WindowHeight = WindowWidth + GUI.GameInterface.HeightTimerAndScore;

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
            Window = new RenderWindow(new SFML.Window.VideoMode(WindowWidth, WindowHeight), "Match 3, by Anoshin Roman");
            Window.SetFramerateLimit(60);

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
