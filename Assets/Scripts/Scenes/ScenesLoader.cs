using UnityEngine.SceneManagement;

namespace Scenes
{
    public class ScenesLoader : IGameLoader, IMenuLoader
    {
        public void LoadGameScene()
        {
            SceneManager.LoadScene(1);
        }
        
        public void LoadMenuScene()
        {
            SceneManager.LoadScene(0);
        }
    }
}