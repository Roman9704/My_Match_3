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
        MenuButton menuButton = null;

        public GameMenuInterface(Test.Scene.AbstractScene scene)
        {
            set_Scene(scene);
        }

        public override void Generate()
        {
            menuButton = new MenuButton();
            menuButton.Clicked += _scene.Transition;
        }

        public override void Destroy()
        {
            menuButton.Clicked -= _scene.Transition;
            menuButton = null;
        }

        public override void Update()
        {
            menuButton.Update();
        }

        public override void Draw()
        {
            menuButton.Draw();
        }
    }
}
