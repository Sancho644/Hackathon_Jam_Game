using System.Collections;
using UI.Dialogs;
using UnityEngine;

public class CheckFixTale : MonoBehaviour
{
    [SerializeField] private TalesNames _taleName;
    [SerializeField] private ShowDialogComponent _showDialogComponent;
    [SerializeField] private CanvasGroup _fixedScene;
    [SerializeField] private GameObject _brokenScene;
    [SerializeField] private float _animationSpeed = 1f;

    private TaleProperties _save;
    private bool _dialogFinished;
    private bool _startAnimation;

    private void Start()
    {
        _save = TaleSaves.GetSave(_taleName);
    }

    private void Update()
    {
        if (_fixedScene.alpha == 1)
        {
            _brokenScene.SetActive(false);
        }
        
        if (_save.StoryFixed && !_dialogFinished && !_save.FixedDialogFinished)
        {
            _save.FixedDialogFinished = true;
            _dialogFinished = true;
            _showDialogComponent.Show();
        }

        if (_save.StoryFixed && !_startAnimation)
        {
            _startAnimation = true;
            StartCoroutine(StartSceneAnimation());
        }
    }

    private IEnumerator StartSceneAnimation()
    {
        float time = 0f;  
        while (time <= _animationSpeed)  
        {  
            float t = Mathf.SmoothStep(0f, 1f, time / _animationSpeed);  
            _fixedScene.alpha = Mathf.Lerp(0, 1, t);  
            yield return null;  
            time += Time.deltaTime;  
        }
    }

    [ContextMenu("StartAnimation")]
    public void StartAnimation()
    {
        StartCoroutine(StartSceneAnimation());
    }
}
