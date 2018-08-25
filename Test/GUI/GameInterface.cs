using SFML.System;

using System;
using System.Collections.Generic;
using Pulse.GUI.GUIObject;
using Pulse.World;

namespace Pulse.GUI
{
    public class GameInterface : AbstractGUI
    {
        public const uint HeightTimerAndScore = GameWorld.AmountOfElements * 10;
        private const int sizeText = GameWorld.AmountOfElements * 4;
        private float timerTime = 60;
        private Inscription inscriptionScore = null;
        private Inscription inscriptionTimer = null;

        public GameInterface(Scene.AbstractScene scene)
        {
            Scene = scene;
        }

        public override void Generate()
        {
            GUIObjectsList = new List<AbstractGUIObject>();

            GUIObjectsList.Add(new Inscription("Score: ", Content.Font, sizeText));
            GUIObjectsList[0].Position = new Vector2f(Initializer.WindowWidth / 2 + 45, Initializer.WindowHeight - sizeText * 2);
            inscriptionScore = GUIObjectsList[0] as Inscription;
            inscriptionScore.Color = Content.ListOfColors[(int)BackgroundType.DarkPurple];
            
            GUIObjectsList.Add(new Inscription("Timer: ", Content.Font, sizeText));
            GUIObjectsList[1].Position = new Vector2f(15, Initializer.WindowHeight - sizeText * 2);
            inscriptionTimer = GUIObjectsList[1] as Inscription;
            inscriptionTimer.Color = Content.ListOfColors[(int)BackgroundType.DarkPurple];
        }

        public override void Destroy()
        {
            Scene = null;

            GUIObjectsList.Clear();
            GUIObjectsList = null;
            inscriptionScore = null;
            inscriptionTimer = null;
        }

        public override void Update()
        {
            inscriptionScore.DisplayedString = "Score: " + GameLogic.Score.ToString();
            timerTime -= GameLoop.Dt;
            inscriptionTimer.DisplayedString = "Timer: " + Convert.ToInt32(timerTime).ToString() + "sec.";
            if (timerTime <= 0)
            {
                Scene.Transition();
            }
        }
    }
}
