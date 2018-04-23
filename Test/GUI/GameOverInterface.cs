using System;
using System.Collections.Generic;

using SFML.Graphics;
using SFML.System;

using Test.Button;
using Test.GUI.GUIElement;

namespace Test.GUI
{
    class GameOverInterface : AbstractGUI
    {
        const int _sizeText = World.AmountOfElements * 6;
        List<Inscription> _listOfInscriptions = null;
        SquareButton _buttonOk = null;

        public GameOverInterface(Test.Scene.AbstractScene scene)
        {
            set_Scene(scene);
        }

        public override void Generate()
        {
            _listOfInscriptions = new List<Inscription>();

            _listOfInscriptions.Add(new Inscription("Game Over", Content.Font, _sizeText));
            _listOfInscriptions[0].set_position(new Vector2f(Initializer.WindowWidth / 2 - _sizeText * 2.8f, Initializer.WindowHeight / 2 - _sizeText * 2));

            _listOfInscriptions.Add(new Inscription("Your score: " + GameLogic.Score.ToString(), Content.Font, _sizeText));
            _listOfInscriptions[1].set_position(new Vector2f(_listOfInscriptions[0].get_positionX() - _sizeText * 1.5f, _listOfInscriptions[0].get_positionY() + _sizeText * 1.5f));
            _listOfInscriptions[1].set_color(new Color(254, 216, 1));

            _buttonOk = new SquareButton(60, Content.ButtonOkSprite, Content.ButtonOkSelectSprite, Initializer.WindowWidth / 2 - 60 / 2, _listOfInscriptions[1].get_positionY() + 60 / 2 + _sizeText * 1.5f);
            _buttonOk.Clicked += _scene.Transition;
        }

        public override void Destroy()
        {
            _buttonOk.Clicked -= _scene.Transition;
            _buttonOk.Destroy();
            _buttonOk = null;

            _listOfInscriptions.Clear();
            _listOfInscriptions = null;
        }

        public override void Update()
        {
            
        }

        public override void Draw()
        {
            _buttonOk.Draw();
            for (int i = 0; i < _listOfInscriptions.Count; i++)
            {
                _listOfInscriptions[i].Draw();
            }
        }
    }
}
