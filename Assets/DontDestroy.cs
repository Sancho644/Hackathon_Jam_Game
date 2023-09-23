using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private void Awake()
    {
        var existsInventory = GetExistsInventory();
        if (existsInventory != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this);
        }
    }
    
    private object GetExistsInventory()
    {
        var inventories = FindObjectsOfType<DontDestroy>();

        foreach (DontDestroy inventory in inventories)
        {
            if (inventory != this)
                return inventory;
        }

        return null;
    }
}
