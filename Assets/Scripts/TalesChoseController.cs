using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TalesChoseController : MonoBehaviour
{
    public List<GameObject> TalesFixedIcons = new List<GameObject>();

    private void Start()
    {
        foreach (GameObject icon in TalesFixedIcons)
        {
            if (!icon.activeSelf)
                return;
        }

        SceneManager.LoadScene("EndScene");
    }
}
