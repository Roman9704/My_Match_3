using System;
using System.Collections.Generic;

namespace Test.GUI
{
    abstract class AbstractGUI
    {
        protected Test.Scene.AbstractScene _scene = null;
        public abstract void Destroy();
        public abstract void Generate();
        public abstract void Update();
        public abstract void Draw();

        protected void set_Scene(Test.Scene.AbstractScene scene)
        {
            this._scene = scene;
        }
    }
}
