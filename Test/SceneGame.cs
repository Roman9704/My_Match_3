using System;

using SFML.Graphics;

namespace Test
{
    class SceneGame : AScene
    {
        World world = null;
        Grid grid = null;
        GameLogic gameLogic = null;
        GameInterface gameInterface = null;

        public SceneGame(RenderWindow window, SceneHandler sceneHandler)
        {
            set_Window(window);
            set_SceneHandler(sceneHandler);
        }
        public override void Generate()
        {
            background = new Background(window, BackgroundType.Turquoise);

            world = new World();

            grid = new Grid();

            gameLogic = new GameLogic(grid, world);

            gameInterface = new GameInterface(window, this, gameLogic);

            grid.generate_Cells(gameLogic);    // Создаем сетку из пустых клеток
            world.generate_Elements(grid);  // Создаем элементы по созданной сетке
            grid.bind_Elements_to_Cells(world);   // Привязываем элементы к сетке
        }

        public override void Update()
        {
            gameLogic.Update();
            gameInterface.Update();
            world.Update();
        }

        public override void Draw()
        {
            background.Draw();
            world.Draw();
            gameInterface.Draw();
        }

        public override void Transition()
        {
            sceneHandler.set_CurrentScene(SceneType.GameOver);
        }

        public GameLogic get_GameLogic()
        {
            return gameLogic;
        }
    }
}
