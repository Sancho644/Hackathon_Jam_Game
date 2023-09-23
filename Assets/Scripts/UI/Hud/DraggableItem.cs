using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI.Hud
{
    public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private Image _icon;
        [SerializeField] private string _taleName;
        [SerializeField] private TalesNames _tale;
        [SerializeField] private Animator _inventoryAnimator;

        [HideInInspector] public Transform ParentAfterDrag;
        
        private static readonly int isOpen = Animator.StringToHash("isOpen");

        private Vector3 _mousePositionStart;
        private Vector3 _mousePositionDrag;
        private Vector3 _mousePositionDelta;
        private Vector3 _transformStartLocalPosition;

        public static event Action OnEndDragChanged;

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (FindObjectOfType<MouseSelectionController>().IsScanning)
                return;
            
            _mousePositionStart = Input.mousePosition;
            ParentAfterDrag = transform.parent;
            transform.SetParent(transform.root);
            _transformStartLocalPosition = transform.localPosition;
            transform.SetAsLastSibling();
            _icon.raycastTarget = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (FindObjectOfType<MouseSelectionController>().IsScanning)
                return;
            
            _mousePositionDrag = Input.mousePosition;
            _mousePositionDelta = _mousePositionDrag - _mousePositionStart;
            transform.localPosition = _transformStartLocalPosition + _mousePositionDelta;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (FindObjectOfType<MouseSelectionController>().IsScanning)
                return;
            
            var currentSceneName = SceneManager.GetActiveScene().name;
            if (_taleName == currentSceneName)
            {
                var save = TaleSaves.GetSave(_tale);
                save.StoryFixed = true;
                _inventoryAnimator.SetBool(isOpen, false);
                
                Destroy(gameObject);
            }

            transform.SetParent(ParentAfterDrag);
            _icon.raycastTarget = true;
            OnEndDragChanged?.Invoke();
        }
    }
}