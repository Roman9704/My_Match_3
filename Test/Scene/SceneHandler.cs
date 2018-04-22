using SFML.System;
using SFML.Graphics;
using System;


namespace Test.Scene
{
    enum SceneType
    {
        GameMenu,
        Game,
        GameOver
    }

    class SceneHandler
    {
        AbstractScene _scene = null;
        SceneType _currentScene;

        public SceneHandler()
        {
            set_currentScene(SceneType.GameMenu);
            _scene = new SceneGameMenu();
            _scene.Generate();
        }

        public void Update()
        {
            _scene.Update();
        }

        public void Draw()
        {
            _scene.Draw();
        }


        public void Transition()
        {
            _scene.Destroy();

            if (_currentScene == SceneType.GameOver)
            {
                _currentScene = SceneType.GameMenu;
                _scene = new SceneGameMenu();
            }
            else
            {
                _currentScene++;
                if (_currentScene == SceneType.Game)
                {
                    _scene = new SceneGame();
                }
                else
                {
                    _scene = new SceneGameOver();
                }
            }

            _scene.Generate();
        }

        private void set_currentScene(SceneType type)
        {
            _currentScene = type;
        }
        public SceneType get_currentScene()
        {
            return _currentScene;
        }
    }
}
