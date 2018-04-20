using System;

using SFML.Graphics;

namespace Test
{
    class SceneGame : AbstractScene
    {
        World world = null;
        Grid grid = null;
        GameLogic gameLogic = null;
        GameInterface gameInterface = null;

        public SceneGame()
        {

        }
        public override void Generate()
        {
            background = new Background(BackgroundType.Turquoise);

            world = new World();

            grid = new Grid();

            gameLogic = new GameLogic();
            gameLogic.Generate();

            gameInterface = new GameInterface(this);
            gameInterface.Generate();

            grid.generate_Cells();    // Создаем сетку из пустых клеток
            world.generate_Elements();  // Создаем элементы по созданной сетке
            grid.bind_Elements_to_Cells();   // Привязываем элементы к сетке
        }

        public override void Destroy()
        {
            background = null;

            world.Destroy();
            world = null;

            gameLogic.Destroy();
            gameLogic = null;

            gameInterface.Destroy();
            gameInterface = null;
        }

        public override void Update()
        {
            gameLogic.Update();
            world.Update();
            gameInterface.Update();
        }

        public override void Draw()
        {
            background.Draw();
            world.Draw();
            gameInterface.Draw();
        }

        public override void Transition()
        {
            Initializer.sceneHandler.Transition();
        }
    }
}
