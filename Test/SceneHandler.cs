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
        RenderWindow window = null;
        List<AScene> scenes = null;
        SceneType CurrentScene;

        public SceneHandler(RenderWindow window)
        {
            scenes = new List<AScene>();
            set_Window(window);
            scenes.Add(new SceneGameMenu(window, this));
            scenes.Add(new SceneGame(window, this));
            scenes.Add(new SceneGameOver(window, this));
            set_CurrentScene(0);
        }

        public void Update()
        {
            scenes[(int)CurrentScene].Update();
        }

        public void Draw()
        {
            scenes[(int)CurrentScene].Draw();
        }

        public void set_CurrentScene(SceneType type)
        {
            CurrentScene = type;

            //if (scenes[(int)CurrentScene].get_SceneGenerate() == false)//если сцена уже была сгенерирована, чтобы заново не генерировать и продолжить
            //{
                scenes[(int)CurrentScene].Generate();
            //}
        }
        public SceneType get_CurrentScene()
        {
            return CurrentScene;
        }

        private void set_Window(RenderWindow window)
        {
            this.window = window;
        }
    }
}
