﻿using SFML.Graphics;
using SFML.System;

namespace Test
{
    class SceneGameOver : AbstractScene
    {
        ButtonOk buttonOk = null;

        Text textGameOver = null;
        Text textYourScore = null;

        const int sizeText = World.AMOUNT_OF_ELEMENTS * 6;

        Color textColor = new Color(254, 216, 1);


        public SceneGameOver()
        {
        }

        public override void Generate()
        {
            background = new Background(BackgroundType.DarkPurple);

            textGameOver = new Text("Game Over", Content.font, sizeText);
            textGameOver.Position = new Vector2f(Initializer.WINDOW_WIDTH / 2 - sizeText * 2.8f, Initializer.WINDOW_HEIGHT / 2 - sizeText * 2);

            textYourScore = new Text("Your score: " + GameLogic.SCORE.ToString(), Content.font, sizeText);
            textYourScore.Position = new Vector2f(textGameOver.Position.X - sizeText * 1.5f, textGameOver.Position.Y + sizeText * 1.5f);
            textYourScore.Color = textColor;

            buttonOk = new ButtonOk();
            buttonOk.set_Position(Initializer.WINDOW_WIDTH / 2 - 60 / 2, textYourScore.Position.Y + 60 / 2 + sizeText * 1.5f);
            buttonOk.Clicked += Transition;
        }

        public override void Destroy()
        {
            buttonOk = null;

            textGameOver = null;
            textYourScore = null;
        }

        public override void Update()
        {
            
        }

        public override void Draw()
        {
            background.Draw();
            buttonOk.Draw();
            Initializer.window.Draw(textGameOver);
            Initializer.window.Draw(textYourScore);
        }

        public override void Transition()
        {
            buttonOk.Clicked -= Transition;
            Initializer.sceneHandler.Transition();
        }
    }
}