using UI.Hud;
using UnityEngine;

public class HideInventoryComponent : MonoBehaviour
{
    private void Start()
    {
        FindObjectOfType<InventoryController>().gameObject.SetActive(false);
    }
}
