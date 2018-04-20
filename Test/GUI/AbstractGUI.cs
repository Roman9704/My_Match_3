using System;
using System.Collections.Generic;

namespace Test
{
    abstract class AbstractGUI
    {
        protected List<AbstractGUIElement> GUIElements = null;

        public abstract void Destroy();
        public abstract void Generate();
        public abstract void Update();
        public abstract void Draw();
    }
}
