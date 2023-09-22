using UnityEngine;
using UnityEngine.Events;

namespace UI.Dialogs
{
    public class ShowDialogComponent : MonoBehaviour
    {
        [SerializeField] private DialogBoxController _dialogBox;
        [SerializeField] private DialogData _bound;
        [SerializeField] private UnityEvent _onComplete;


        public void Show()
        {
            _dialogBox.ShowDialog(_bound, _onComplete);
        }
    }
}