using System;
using System.Collections.Generic;
using Test.GUI.GUIElement;

namespace Test.GUI
{
    abstract class AbstractGUI
    {
        protected List<AbstractGUIElement> _listOfGUIElements = null;
        protected Test.Scene.AbstractScene _scene = null;
        public abstract void Generate();
        public virtual void Destroy()
        {
            if (_listOfGUIElements != null)
            {
                _listOfGUIElements.Clear();
                _listOfGUIElements = null;
            }

            _scene = null;
        }
        public virtual void Update()
        {
            if (_listOfGUIElements != null)
            {
                for (int i = 0; i < _listOfGUIElements.Count; i++)
                {
                    _listOfGUIElements[i].Update();
                }
            }
        }
        public virtual void Draw()
        {
            for (int i = 0; i < _listOfGUIElements.Count; i++)
            {
                _listOfGUIElements[i].Draw();
            }
        }

        protected void set_Scene(Test.Scene.AbstractScene scene)
        {
            this._scene = scene;
        }
    }
}
