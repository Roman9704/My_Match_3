using SFML.Graphics;
using SFML.System;

using System;
using System.Collections.Generic;
using Test.GUI.GUIElement;

namespace Test.GUI
{
    class GameInterface : AbstractGUI
    {
        public const uint HeightTimerAndScore = World.AmountOfElements * 10;
        const int _sizeText = World.AmountOfElements * 4;
        float _timerTime = 60;
        Inscription _inscriptionScore = null;
        Inscription _inscriptionTimer = null;

        public GameInterface(Test.Scene.AbstractScene scene)
        {
            set_Scene(scene);
        }

        public override void Generate()
        {
            _listOfGUIElements = new List<AbstractGUIElement>();

            _listOfGUIElements.Add(new Inscription("Score: ", Content.Font, _sizeText));
            _listOfGUIElements[0].set_position(new Vector2f(Initializer.WindowWidth / 2 + 45, Initializer.WindowHeight - _sizeText * 2));
            _inscriptionScore = _listOfGUIElements[0] as Inscription;
            _inscriptionScore.set_color(Content.ListOfColors[(int)BackgroundType.DarkPurple]);
            
            _listOfGUIElements.Add(new Inscription("Timer: ", Content.Font, _sizeText));
            _listOfGUIElements[1].set_position(new Vector2f(15, Initializer.WindowHeight - _sizeText * 2));
            _inscriptionTimer = _listOfGUIElements[1] as Inscription;
            _inscriptionTimer.set_color(Content.ListOfColors[(int)BackgroundType.DarkPurple]);
        }

        public override void Destroy()
        {
            _scene = null;

            _listOfGUIElements.Clear();
            _listOfGUIElements = null;
            _inscriptionScore = null;
            _inscriptionTimer = null;
        }

        public override void Update()
        {
            _inscriptionScore.set_string("Score: " + GameLogic.Score.ToString());
            _timerTime -= GameLoop.dt;
            _inscriptionTimer.set_string("Timer: " + Convert.ToInt32(_timerTime).ToString() + "sec.");
            if (_timerTime <= 0)
            {
                _scene.Transition();
            }
        }
    }
}
