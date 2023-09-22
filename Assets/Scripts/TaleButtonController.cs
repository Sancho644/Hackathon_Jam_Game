using UnityEngine;

public class TaleButtonController : MonoBehaviour
{
    [SerializeField] private TalesNames _taleName;
    [SerializeField] private GameObject _notFoundObjectTale;
    [SerializeField] private GameObject _foundObjectTale;
    [SerializeField] private GameObject _completeTaleIcon;
    
    private TaleProperties _taleProperties; 

    private void Start()
    {
        _taleProperties = TaleSaves.GetSave(_taleName);
        
        _notFoundObjectTale.SetActive(!_taleProperties.ObjectFound);
        _foundObjectTale.SetActive(_taleProperties.ObjectFound);
        _completeTaleIcon.SetActive(_taleProperties.StoryFixed);
    }
}