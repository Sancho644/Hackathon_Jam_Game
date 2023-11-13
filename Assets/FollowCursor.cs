using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FollowCursor : MonoBehaviour
{
    [SerializeField] private Color _colorRed;
    [SerializeField] private Color _colorGreen;
    [SerializeField] private Image _image;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        StopCurrentCoroutine();
        UpdatePosition();
    }

    private void LateUpdate()
    {
        UpdatePosition();
    }

    private void OnDisable()
    {
        StopCurrentCoroutine();
    }

    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }

    public void ScanFailed()
    {
        StopCurrentCoroutine();
        
        _coroutine = StartCoroutine(StartRedAnimation());
    }

    public void ScanSuccessfull()
    {
        StopCurrentCoroutine();

        _coroutine = StartCoroutine(StartGreenAnimation());
    }

    private void UpdatePosition()
    {
        GetComponent<RectTransform>().position = Input.mousePosition;
    }

    private void StopCurrentCoroutine()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
        
        _image.color = Color.white;
    }

    private IEnumerator StartRedAnimation()
    {
        _image.color = _colorRed;

        yield return new WaitForSeconds(0.3f);

        _image.color = Color.white;
    }

    private IEnumerator StartGreenAnimation()
    {
        _image.color = _colorGreen;

        yield return new WaitForSeconds(0.3f);

        _image.color = Color.white;
    }
}