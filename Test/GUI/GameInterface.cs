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
        List<Inscription> _listOfInscriptions = null;

        public GameInterface(Test.Scene.AbstractScene scene)
        {
            set_Scene(scene);
        }

        public override void Generate()
        {
            _listOfInscriptions = new List<Inscription>();

            _listOfInscriptions.Add(new Inscription("Score: ", Content.Font, _sizeText));
            _listOfInscriptions[0].set_position(new Vector2f(Initializer.WindowWidth / 2 + 45, Initializer.WindowHeight - _sizeText * 2));
            _listOfInscriptions[0].set_color(Content.ListOfColors[(int)BackgroundType.DarkPurple]);

            _listOfInscriptions.Add(new Inscription("Timer: ", Content.Font, _sizeText));
            _listOfInscriptions[1].set_position(new Vector2f(15, Initializer.WindowHeight - _sizeText * 2));
            _listOfInscriptions[1].set_color(Content.ListOfColors[(int)BackgroundType.DarkPurple]);
        }

        public override void Destroy()
        {
            _scene = null;

            _listOfInscriptions.Clear();
            _listOfInscriptions = null;
        }

        public override void Update()
        {
            _listOfInscriptions[0].set_string("Score: " + GameLogic.Score.ToString());
            _timerTime -= GameLoop.dt;
            _listOfInscriptions[1].set_string("Timer: " + Convert.ToInt32(_timerTime).ToString() + "sec.");
            if (_timerTime <= 0)
            {
                _scene.Transition();
            }
        }

        public override void Draw()
        {
            for (int i = 0; i < _listOfInscriptions.Count; i++)
            {
                _listOfInscriptions[i].Draw();
            }
        }
    }
}
