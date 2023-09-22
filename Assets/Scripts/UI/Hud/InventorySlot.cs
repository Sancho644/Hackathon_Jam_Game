using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Hud
{
    public class InventorySlot : MonoBehaviour, IDropHandler
    {
        private GameObject _dropped;
        private bool _isActive = true;

        public bool IsActive => _isActive;


        public void OnDrop(PointerEventData eventData)
        {
            if (transform.childCount == 0 || !transform.GetChild(0).gameObject.activeSelf && _isActive)
            {
                _dropped = eventData.pointerDrag;
                if (_dropped.TryGetComponent(out DraggableItem draggableItem))
                {
                    draggableItem.ParentAfterDrag = transform;
                }
            }
        }

        public void ActivateSlot()
        {
            _isActive = true;
        }

        public void LockSlot()
        {
            _isActive = false;
        }
    }
}