using UnityEngine;

public class ObjectController : MonoBehaviour
{
    [SerializeField] private TalesNames _taleName;
    
    private TaleProperties _taleProperties;

    private void Start()
    {
        _taleProperties = TaleSaves.GetSave(_taleName);
    }

    public void SetObjectFound()
    {
        _taleProperties.ObjectFound = true;
    }

    public void SetTaleFixed()
    {
        _taleProperties.StoryFixed = true;
    }
}