using SFML.Graphics;
using SFML.System;
using System;
using Test.Button;

namespace Test.GUI
{
    class GameOverInterface : AbstractGUI
    {
        ButtonOk buttonOk = null;

        Text textGameOver = null;
        Text textYourScore = null;

        const int sizeText = World.AmountOfElements * 6;

        public GameOverInterface(Test.Scene.AbstractScene scene)
        {
            set_Scene(scene);
        }

        public override void Generate()
        {
            textGameOver = new Text("Game Over", Content.Font, sizeText);
            textGameOver.Position = new Vector2f(Initializer.WindowWidth / 2 - sizeText * 2.8f, Initializer.WindowHeight / 2 - sizeText * 2);

            textYourScore = new Text("Your score: " + GameLogic.Score.ToString(), Content.Font, sizeText);
            textYourScore.Position = new Vector2f(textGameOver.Position.X - sizeText * 1.5f, textGameOver.Position.Y + sizeText * 1.5f);
            textYourScore.Color = new Color(254, 216, 1);

            buttonOk = new ButtonOk();
            buttonOk.set_position(Initializer.WindowWidth / 2 - 60 / 2, textYourScore.Position.Y + 60 / 2 + sizeText * 1.5f);
            buttonOk.Clicked += _scene.Transition;
        }

        public override void Destroy()
        {
            buttonOk.Clicked -= _scene.Transition;
            buttonOk = null;

            textGameOver = null;
            textYourScore = null;   
        }

        public override void Update()
        {
            
        }

        public override void Draw()
        {
            buttonOk.Draw();
            Initializer.Window.Draw(textGameOver);
            Initializer.Window.Draw(textYourScore);
        }
    }
}
