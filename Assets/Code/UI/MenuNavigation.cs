using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Code.UI
{
    public class MenuNavigation : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("Loadout");
            }
        }
    }
}
