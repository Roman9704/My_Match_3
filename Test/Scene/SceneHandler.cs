using SFML.System;
using SFML.Graphics;
using System;
using System.Collections.Generic;


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
        int _currentSceneIndex;
        List<AbstractScene> _listOfScenes = null;

        public SceneHandler()
        {
            _listOfScenes = new List<AbstractScene>();
            _listOfScenes.Add(new SceneGameMenu());
            _listOfScenes.Add(new SceneGame());
            _listOfScenes.Add(new SceneGameOver());

            set_currentSceneIndex(0);

            _listOfScenes[_currentSceneIndex].Generate();
        }

        public void Update()
        {
            _listOfScenes[_currentSceneIndex].Update();
        }

        public void Draw()
        {
            _listOfScenes[_currentSceneIndex].Draw();
        }

        public void Transition()
        {
            _listOfScenes[_currentSceneIndex].Destroy();

            if (_currentSceneIndex == _listOfScenes.Count - 1)
            {
                _currentSceneIndex = 0;
            }
            else
            {
                _currentSceneIndex++;
            }

            _listOfScenes[_currentSceneIndex].Generate();
        }

        private void set_currentSceneIndex(int i)
        {
            _currentSceneIndex = i;
        }
        public int get_currentSceneIndex()
        {
            return _currentSceneIndex;
        }
    }
}
