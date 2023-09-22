using System.Collections;
using UI.Hud;
using UnityEngine;
using UnityEngine.Events;

namespace UI.Dialogs
{
    public class DialogBoxController : MonoBehaviour
    {
        [SerializeField] private GameObject _blackPlate;
        [SerializeField] private GameObject _container;
        [SerializeField] private GameObject _player;
        [SerializeField] private Animator _animator;

        [Space] [SerializeField] private float _textSpeed = 0.09f;

        [Header("Sounds")] [SerializeField] private AudioClip _typing;
        [SerializeField] private AudioClip _open;
        [SerializeField] private AudioClip _close;

        [Space] [SerializeField] protected DialogContent _content;

        private static readonly int isOpen = Animator.StringToHash("isOpen");

        private PersonalizedDialogBoxController _rightBox;
        private DialogData _data;
        private int _currentSentence;
        private AudioSource _sfxSource;
        private Coroutine _typingRoutine;
        private UnityEvent _onComplete;

        protected Sentence CurrentSentence => _data.Sentence[_currentSentence];

        private void Start()
        {
            _rightBox = FindObjectOfType<PersonalizedDialogBoxController>();
            _sfxSource = AudioUtils.FindSfxSource();
        }

        public void ShowDialog(DialogData data, UnityEvent onComplete)
        {
            _onComplete = onComplete;
            _data = data;
            _currentSentence = 0;
            CurrentContent.Text.text = string.Empty;
            
            _blackPlate.SetActive(true);
            _player.SetActive(true);
            _container.SetActive(true);
            _sfxSource.PlayOneShot(_open);
            _animator.SetBool(isOpen, true);
        }

        protected virtual void OnStartDialogAnimation()
        {
            _typingRoutine = StartCoroutine(TypeDialogText());
        }

        protected virtual DialogContent CurrentContent => _content;

        public void OnSkip()
        {
            if (_typingRoutine == null) return;

            StopTypeAnimation();
            var sentence = _data.Sentence[_currentSentence].Value;
            CurrentContent.Text.text = sentence;
        }

        public void OnContinue()
        {
            StopTypeAnimation();
            _currentSentence++;

            var isDialogCompleted = _currentSentence >= _data.Sentence.Length;
            if (isDialogCompleted)
            {
                HideDialogBox();
                _onComplete?.Invoke();
            }
            else
            {
                OnStartDialogAnimation();
            }
        }

        private void HideDialogBox()
        {
            _animator.SetBool(isOpen, false);
            _sfxSource.PlayOneShot(_close);
            _blackPlate.SetActive(false);
            _player.SetActive(false);
        }

        private void StopTypeAnimation()
        {
            if (_typingRoutine != null)
                StopCoroutine(_typingRoutine);
            _typingRoutine = null;
        }

        private void OnCloseAnimationComplete()
        {
            _content.gameObject.SetActive(false);
            _rightBox._right.gameObject.SetActive(false);
        }

        private IEnumerator TypeDialogText()
        {
            CurrentContent.Text.text = string.Empty;
            var sentence = CurrentSentence;
            var localizedSentence = sentence.Value;

            foreach (var letter in localizedSentence)
            {
                CurrentContent.Text.text += letter;
                _sfxSource.PlayOneShot(_typing);
                yield return new WaitForSeconds(_textSpeed);
            }

            _typingRoutine = null;
        }
    }
}