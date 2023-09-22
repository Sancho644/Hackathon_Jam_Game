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

        [HideInInspector] public Transform ParentAfterDrag;

        private Vector3 _mousePositionStart;
        private Vector3 _mousePositionDrag;
        private Vector3 _mousePositionDelta;
        private Vector3 _transformStartLocalPosition;

        public static event Action OnEndDragChanged;

        public void OnBeginDrag(PointerEventData eventData)
        {
            _mousePositionStart = Input.mousePosition;
            ParentAfterDrag = transform.parent;
            transform.SetParent(transform.root);
            _transformStartLocalPosition = transform.localPosition;
            transform.SetAsLastSibling();
            _icon.raycastTarget = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            _mousePositionDrag = Input.mousePosition;
            _mousePositionDelta =  _mousePositionDrag - _mousePositionStart;
            transform.localPosition = _transformStartLocalPosition + _mousePositionDelta;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            var currentSceneName = SceneManager.GetActiveScene().name;
            if (_taleName.ToString() == currentSceneName)
            {
                Destroy(gameObject);
            }
            
            transform.SetParent(ParentAfterDrag);
            _icon.raycastTarget = true;
            OnEndDragChanged?.Invoke();
        }
    }
}