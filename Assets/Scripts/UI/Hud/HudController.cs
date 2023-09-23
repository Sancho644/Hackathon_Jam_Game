using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.Hud
{
    public class HudController : MonoBehaviour
    {
        [SerializeField] private GameObject _scanTutorial;

        public void OnSceneSwitch(string sceneName)
        {
            if (FindObjectOfType<MouseSelectionController>().IsScanning)
                return;

            SceneManager.LoadScene(sceneName);
        }

        public void DisableScanTutor()
        {
            _scanTutorial.SetActive(false);
        }

        public void EnableScanTutor()
        {
            _scanTutorial.SetActive(true);
        }
    }
}