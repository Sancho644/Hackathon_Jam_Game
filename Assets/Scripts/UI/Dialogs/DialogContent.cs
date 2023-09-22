using UnityEngine;
using UnityEngine.UI;

namespace UI.Dialogs
{
    public class DialogContent : MonoBehaviour
    {
        [SerializeField] private Text _text;

        public Text Text => _text;
    }
}