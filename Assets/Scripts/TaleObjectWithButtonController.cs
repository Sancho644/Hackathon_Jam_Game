using UI.Hud;
using UnityEngine;
using UnityEngine.UI;

public class TaleObjectWithButtonController : MonoBehaviour
{
    private const string InventoryBoxTag = "InventoryBox";
    
    [SerializeField] private Button _button;
    [SerializeField] private TalesNames _taleName;
    [SerializeField] private GameObject _blackPlate;
    [SerializeField] private Collider _npcCollider;

    private void Start()
    {
        _button.onClick.AddListener(AddObjectToInventory);
    }

    private void OnEnable()
    {
        _blackPlate.SetActive(true);
        _npcCollider.enabled = false;
    }

    private void AddObjectToInventory()
    {
        var inventoryBox = GameObject.FindGameObjectWithTag(InventoryBoxTag);
        var inventoryController = inventoryBox.GetComponent<InventoryController>();
        
        inventoryController.ChangeInventoryVisible();
        inventoryController.SetActiveObject(_taleName);
        
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        _npcCollider.enabled = true;
        _blackPlate.SetActive(false);
    }
}