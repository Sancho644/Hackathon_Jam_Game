using UnityEngine;

public class MouseSelectionAdapter : MonoBehaviour
{
    public void SetScanCursor()
    {
        FindObjectOfType<MouseSelectionController>().SetScanCursor();
    }
}
