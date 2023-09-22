using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.Hud
{
    public class HudController : MonoBehaviour
    {
        public void OnSceneSwitch(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}