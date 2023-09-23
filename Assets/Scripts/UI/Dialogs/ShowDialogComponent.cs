using UnityEngine;
using UnityEngine.Events;

namespace UI.Dialogs
{
    public class ShowDialogComponent : MonoBehaviour
    {
        [SerializeField] private bool _showInStart;
        [SerializeField] private TalesNames _taleName;
        [SerializeField] private Collider _npcCollider;
        [SerializeField] private DialogBoxController _dialogBox;
        [SerializeField] private DialogData _bound;
        [SerializeField] private UnityEvent _onComplete;

        private void Start()
        {
            var entryDialog = TaleSaves.GetSave(_taleName);
            
            if (_showInStart && !entryDialog.EntryDialogFinished)
                Show();
        }

        public void Show()
        {
            _dialogBox.ShowDialog(_bound, _onComplete);
            _npcCollider.enabled = false;
        }

        public void FinishEntryDialog()
        {
            var entryDialog = TaleSaves.GetSave(_taleName);
            entryDialog.EntryDialogFinished = true;
        }
    }
}