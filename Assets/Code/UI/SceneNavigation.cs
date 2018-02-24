using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Code.UI
{
    public class SceneNavigation : MonoBehaviour
    {
        public void NavigateToScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}
