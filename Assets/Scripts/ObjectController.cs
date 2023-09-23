using UnityEngine;

public class ObjectController : MonoBehaviour
{
    [SerializeField] private TalesNames _taleName;
    [SerializeField] private GameObject _taleObject;
    
    private TaleProperties _taleProperties;
    public TalesNames SaveKey => _taleName;

    private void Start()
    {
        _taleProperties = TaleSaves.GetSave(_taleName);
    }

    public void SetObjectFound()
    {
        _taleProperties.ObjectFound = true;
        _taleObject.SetActive(true);
    }
}