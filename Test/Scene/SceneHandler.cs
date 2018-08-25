using System.Collections.Generic;

namespace Pulse.Scene
{
    public enum SceneType
    {
        GameMenu,
        Game,
        GameOver
    }

    public class SceneHandler
    {
        public int CurrentSceneIndex { get; private set; }
        private List<AbstractScene> listOfScenes = null;

        public SceneHandler()
        {
            listOfScenes = new List<AbstractScene>();
            listOfScenes.Add(new SceneGameMenu());
            listOfScenes.Add(new SceneGame());
            listOfScenes.Add(new SceneGameOver());

            CurrentSceneIndex = 0;

            listOfScenes[CurrentSceneIndex].Generate();
        }

        public void Update()
        {
            listOfScenes[CurrentSceneIndex].Update();
        }

        public void Draw()
        {
            listOfScenes[CurrentSceneIndex].Draw();
        }

        public void Transition()
        {
            listOfScenes[CurrentSceneIndex].Destroy();

            if (CurrentSceneIndex == listOfScenes.Count - 1)
            {
                CurrentSceneIndex = 0;
            }
            else
            {
                CurrentSceneIndex++;
            }

            listOfScenes[CurrentSceneIndex].Generate();
        }
    }
}
