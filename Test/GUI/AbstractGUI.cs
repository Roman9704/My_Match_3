using System.Collections.Generic;
using Pulse.GUI.GUIObject;

namespace Pulse.GUI
{
    public abstract class AbstractGUI
    {
        protected List<AbstractGUIObject> GUIObjectsList = null;
        public Scene.AbstractScene Scene { get; set; }
        public abstract void Generate();

        public virtual void Destroy()
        {
            if (GUIObjectsList != null)
            {
                GUIObjectsList.Clear();
                GUIObjectsList = null;
            }

            Scene = null;
        }

        public virtual void Update()
        {
            if (GUIObjectsList != null)
            {
                for (int i = 0; i < GUIObjectsList.Count; i++)
                {
                    GUIObjectsList[i].Update();
                }
            }
        }

        public virtual void Draw()
        {
            for (int i = 0; i < GUIObjectsList.Count; i++)
            {
                GUIObjectsList[i].Draw();
            }
        }
    }
}
