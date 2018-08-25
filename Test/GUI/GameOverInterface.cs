using System.Collections.Generic;

using SFML.Graphics;
using SFML.System;

using Pulse.GUI.GUIObject.Button;
using Pulse.GUI.GUIObject;
using Pulse.World;

namespace Pulse.GUI
{
    public class GameOverInterface : AbstractGUI
    {
        private const int sizeText = GameWorld.AmountOfElements * 6;
        private RectangularButton buttonOk = null;
        private Inscription inscriptionScore = null;

        public GameOverInterface(Pulse.Scene.AbstractScene scene)
        {
            Scene = scene;
        }

        public override void Generate()
        {
            GUIObjectsList = new List<AbstractGUIObject>();

            GUIObjectsList.Add(new Inscription("Game Over", Content.Font, sizeText));
            GUIObjectsList[0].Position = new Vector2f(Initializer.WindowWidth / 2 - sizeText * 2.8f, Initializer.WindowHeight / 2 - sizeText * 2);

            GUIObjectsList.Add(new Inscription("Your score: " + GameLogic.Score.ToString(), Content.Font, sizeText));
            GUIObjectsList[1].Position = new Vector2f(GUIObjectsList[0].Position.X - sizeText * 1.5f, GUIObjectsList[0].Position.Y + sizeText * 1.5f);
            inscriptionScore = GUIObjectsList[1] as Inscription;
            inscriptionScore.Color = new Color(254, 216, 1);

            var position = new Vector2f(Initializer.WindowWidth / 2 - 60 / 2, GUIObjectsList[1].Position.Y + 60 / 2 + sizeText * 1.5f);
            var size = new Vector2f(60, 60);
            buttonOk = new RectangularButton(size, Content.ButtonOkSprite, Content.ButtonOkSelectSprite, position);
            buttonOk.Clicked += Scene.Transition;
        }

        public override void Destroy()
        {
            buttonOk.Clicked -= Scene.Transition;
            buttonOk.Destroy();
            buttonOk = null;

            GUIObjectsList.Clear();
            GUIObjectsList = null;

            Scene = null;
        }

        public override void Update()
        {
            
        }

        public override void Draw()
        {
            buttonOk.Draw();
            for (int i = 0; i < GUIObjectsList.Count; i++)
            {
                GUIObjectsList[i].Draw();
            }
        }
    }
}
