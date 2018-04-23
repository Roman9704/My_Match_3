using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Button;

namespace Test.GUI
{
    class GameMenuInterface : AbstractGUI
    {
        RectangularButton _menuButton = null;

        public GameMenuInterface(Test.Scene.AbstractScene scene)
        {
            set_Scene(scene);
        }

        public override void Generate()
        {
            _menuButton = new RectangularButton(120, 60, Content.ButtonSprite0, Content.ButtonSprite1, Initializer.WindowWidth / 2 - 120 / 2, Initializer.WindowHeight / 2 - 60 / 2);
            _menuButton.Clicked += _scene.Transition;
        }

        public override void Destroy()
        {
            _menuButton.Clicked -= _scene.Transition;
            _menuButton.Destroy();
            _menuButton = null;
        }

        public override void Update()
        {
        }

        public override void Draw()
        {
            _menuButton.Draw();
        }
    }
}
