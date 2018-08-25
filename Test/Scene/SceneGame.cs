using Pulse.Grid;
using Pulse.World;

namespace Pulse.Scene
{
    public class SceneGame : AbstractScene
    {
        private GameWorld world = null;
        private GameGrid grid = null;
        private GameLogic gameLogic = null;

        public SceneGame()
        {

        }

        public override void Generate()
        {
            background = new Background(BackgroundType.Turquoise);

            world = new GameWorld();

            grid = new GameGrid();

            gameLogic = new GameLogic();
            gameLogic.Generate();

            gui = new GUI.GameInterface(this);
            gui.Generate();

            // Создаем сетку из пустых клеток
            grid.GenerateCells();
            // Создаем элементы по созданной сетке
            world.GenerateElements();
            // Привязываем элементы к сетке
            grid.BindElementsToCells();   
        }

        public override void Destroy()
        {
            background = null;

            grid.Destroy();
            grid = null;

            world.Destroy();
            world = null;

            gameLogic.Destroy();
            gameLogic = null;

            gui.Destroy();
            gui = null;
        }

        public override void Update()
        {
            gameLogic.Update();
            world.Update();
            gui.Update();
        }

        public override void Draw()
        {
            background.Draw();
            world.Draw();
            gui.Draw();
        }

        public override void Transition()
        {
            Initializer.SceneHandler.Transition();
        }
    }
}
