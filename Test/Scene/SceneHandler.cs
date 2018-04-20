using System.Collections.Generic;

using SFML.System;
using SFML.Graphics;


namespace Test
{
    enum SceneType
    {
        GameMenu,
        Game,
        GameOver
    }

    class SceneHandler
    {
        AbstractScene scene = null;
        SceneType CurrentScene;

        public SceneHandler()
        {
            set_CurrentScene(SceneType.GameMenu);
            scene = new SceneGameMenu();
            scene.Generate();
        }

        public void Update()
        {
            scene.Update();
        }

        public void Draw()
        {
            scene.Draw();
        }


        public void Transition()
        {
            scene.Destroy();

            if (CurrentScene == SceneType.GameOver)
            {
                CurrentScene = SceneType.GameMenu;
                scene = new SceneGameMenu();
            }
            else
            {
                CurrentScene++;
                if (CurrentScene == SceneType.Game)
                {
                    scene = new SceneGame();
                }
                else
                {
                    scene = new SceneGameOver();
                }
            }

            scene.Generate();
        }

        private void set_CurrentScene(SceneType type)
        {
            CurrentScene = type;

            //if (scenes[(int)CurrentScene].get_SceneGenerate() == false)//если сцена уже была сгенерирована, чтобы заново не генерировать и продолжить
            //{
                //scenes[(int)CurrentScene].Generate();
            //}
        }
        public SceneType get_CurrentScene()
        {
            return CurrentScene;
        }
    }
}
