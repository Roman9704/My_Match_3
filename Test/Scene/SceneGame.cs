using System;

using SFML.Graphics;

namespace Test
{
    class SceneGame : AbstractScene
    {
        World _world = null;
        Grid _grid = null;
        GameLogic _gameLogic = null;
        GameInterface _gameInterface = null;

        public SceneGame()
        {

        }
        public override void Generate()
        {
            _background = new Background(BackgroundType.Turquoise);

            _world = new World();

            _grid = new Grid();

            _gameLogic = new GameLogic();
            _gameLogic.Generate();

            _gameInterface = new GameInterface(this);
            _gameInterface.Generate();

            _grid.generate_cells();    // Создаем сетку из пустых клеток
            _world.generateElements();  // Создаем элементы по созданной сетке
            _grid.bind_Elements_to_Cells();   // Привязываем элементы к сетке
        }

        public override void Destroy()
        {
            _background = null;

            _world.Destroy();
            _world = null;

            _gameLogic.Destroy();
            _gameLogic = null;

            _gameInterface.Destroy();
            _gameInterface = null;
        }

        public override void Update()
        {
            _gameLogic.Update();
            _world.Update();
            _gameInterface.Update();
        }

        public override void Draw()
        {
            _background.Draw();
            _world.Draw();
            _gameInterface.Draw();
        }

        public override void Transition()
        {
            Initializer.SceneHandler.Transition();
        }
    }
}
