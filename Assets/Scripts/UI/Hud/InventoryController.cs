using UnityEngine;
using UnityEngine.UI;

namespace UI.Hud
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField] private Button _hideButton;
        [SerializeField] private Animator _animator;

        private bool _stage;
        private static readonly int isOpen = Animator.StringToHash("isOpen");

        private void Start()
        {
            _hideButton.onClick.AddListener(ChangeInventoryVisible);
        }

        public void ChangeInventoryVisible()
        {
            _stage = !_stage;

            _animator.SetBool(isOpen, _stage);
        }
    }
}