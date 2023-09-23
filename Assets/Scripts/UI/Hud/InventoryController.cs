using UnityEngine;
using UnityEngine.UI;

namespace UI.Hud
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField] private Button _hideButton;
        [SerializeField] private Animator _animator;

        [Space] [Header("Objects")] 
        [SerializeField] private GameObject _tale1;
        [SerializeField] private GameObject _tale2;
        [SerializeField] private GameObject _tale3;
        [SerializeField] private GameObject _tale4;
        [SerializeField] private GameObject _tale5;

        private bool _stage;
        private static readonly int isOpen = Animator.StringToHash("isOpen");
        private Animator _buttonAnimator;
        private bool _inventoryClosed;

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

        private void Start()
        {
            _hideButton.onClick.AddListener(ChangeInventoryVisible);
            _buttonAnimator = _hideButton.GetComponent<Animator>();
            _animator.SetBool(isOpen, false);
        }

        public void ChangeInventoryVisible()
        {
            if (FindObjectOfType<MouseSelectionController>().IsScanning)
                return;
            
            _stage = !_stage;

            _buttonAnimator.SetBool(isOpen, _stage);
            _animator.SetBool(isOpen, _stage);
        }

        public void SetActiveObject(TalesNames taleName)
        {
           if (taleName == TalesNames.TaleScene)
               _tale1.SetActive(true);
           if (taleName == TalesNames.TaleScene2)
               _tale2.SetActive(true);
           if (taleName == TalesNames.TaleScene3)
               _tale3.SetActive(true);
           if (taleName == TalesNames.TaleScene4)
               _tale4.SetActive(true);
           if (taleName == TalesNames.TaleScene5)
               _tale5.SetActive(true);
        }

        private object GetExistsInventory()
        {
            var inventories = FindObjectsOfType<InventoryController>();

            foreach (InventoryController inventory in inventories)
            {
                if (inventory != this)
                    return inventory;
            }

            return null;
        }
    }
}