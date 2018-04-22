using System;

using SFML.Graphics;
using Test.Grid;

namespace Test.Scene
{
    class SceneGame : AbstractScene
    {
        World _world = null;
        GameGrid _grid = null;
        GameLogic _gameLogic = null;

        public SceneGame()
        {

        }
        public override void Generate()
        {
            _background = new Background(BackgroundType.Turquoise);

            _world = new World();

            _grid = new GameGrid();

            _gameLogic = new GameLogic();
            _gameLogic.Generate();

            _gui = new GUI.GameInterface(this);
            _gui.Generate();

            _grid.generateCells();    // Создаем сетку из пустых клеток
            _world.generateElements();  // Создаем элементы по созданной сетке
            _grid.bindElementsToCells();   // Привязываем элементы к сетке
        }

        public override void Destroy()
        {
            _background = null;

            _world.Destroy();
            _world = null;

            _gameLogic.Destroy();
            _gameLogic = null;

            _gui.Destroy();
            _gui = null;
        }

        public override void Update()
        {
            _gameLogic.Update();
            _world.Update();
            _gui.Update();
        }

        public override void Draw()
        {
            _background.Draw();
            _world.Draw();
            _gui.Draw();
        }

        public override void Transition()
        {
            Initializer.SceneHandler.Transition();
        }
    }
}
