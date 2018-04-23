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
        SquareButton _buttonOk = null;
        Inscription _inscriptionScore = null;

        public GameOverInterface(Test.Scene.AbstractScene scene)
        {
            set_Scene(scene);
        }

        public override void Generate()
        {
            _listOfGUIElements = new List<AbstractGUIElement>();

            _listOfGUIElements.Add(new Inscription("Game Over", Content.Font, _sizeText));
            _listOfGUIElements[0].set_position(new Vector2f(Initializer.WindowWidth / 2 - _sizeText * 2.8f, Initializer.WindowHeight / 2 - _sizeText * 2));

            _listOfGUIElements.Add(new Inscription("Your score: " + GameLogic.Score.ToString(), Content.Font, _sizeText));
            _listOfGUIElements[1].set_position(new Vector2f(_listOfGUIElements[0].get_positionX() - _sizeText * 1.5f, _listOfGUIElements[0].get_positionY() + _sizeText * 1.5f));
            _inscriptionScore = _listOfGUIElements[1] as Inscription;
            _inscriptionScore.set_color(new Color(254, 216, 1));

            _buttonOk = new SquareButton(60, Content.ButtonOkSprite, Content.ButtonOkSelectSprite, Initializer.WindowWidth / 2 - 60 / 2, _listOfGUIElements[1].get_positionY() + 60 / 2 + _sizeText * 1.5f);
            _buttonOk.Clicked += _scene.Transition;
        }

        public override void Destroy()
        {
            _buttonOk.Clicked -= _scene.Transition;
            _buttonOk.Destroy();
            _buttonOk = null;

            _listOfGUIElements.Clear();
            _listOfGUIElements = null;

            _scene = null;
        }

        public override void Update()
        {
            
        }

        public override void Draw()
        {
            _buttonOk.Draw();
            for (int i = 0; i < _listOfGUIElements.Count; i++)
            {
                _listOfGUIElements[i].Draw();
            }
        }
    }
}
