using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class MainMenu : MonoBehaviour
    {
        public void LoadPlayScene()
        {
            SceneManager.LoadScene(1);
        }
    }
}
