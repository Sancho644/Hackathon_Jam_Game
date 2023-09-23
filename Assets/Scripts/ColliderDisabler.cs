using UnityEngine;

public class ColliderDisabler : MonoBehaviour
{
    [SerializeField] private Collider _collider;
    [SerializeField] private TalesNames _taleName;
    
    private TaleProperties _save;
    private bool _colliderDisabled;

    private void Start()
    {
        _save = TaleSaves.GetSave(_taleName);
    }

    private void Update()
    {
        if (_save.StoryFixed && !_colliderDisabled)
        {
            _colliderDisabled = true;
            _collider.enabled = false;
        }
    }
}
