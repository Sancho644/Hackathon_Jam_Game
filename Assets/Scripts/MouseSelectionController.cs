using UI.Dialogs;
using UI.Hud;
using UnityEngine;

public class MouseSelectionController : MonoBehaviour
{
    private const string NpcLayer = "NpcLayer";
    private const string ObjectLayer = "ObjectLayer";

    [SerializeField] private FollowCursor _followCursor;
    [SerializeField] private float _maxDistance;

    private int _currentFrame;
    private float _frameTimer;

    private LayerMask _npcLayer;
    private LayerMask _objectLayer;

    private RaycastHit _npcHit;
    private RaycastHit _objectHit;
    private RaycastHit _inventoryHit;

    private bool _cursorIsScanning;
    private bool _disableAnimate;

    public bool IsScanning => _cursorIsScanning;

    private void Start()
    {
        _npcLayer = 1 << LayerMask.NameToLayer(NpcLayer);
        _objectLayer = 1 << LayerMask.NameToLayer(ObjectLayer);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && _cursorIsScanning)
        {
            SetScanCursor();
            
            return;
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            Select();
        }
    }

    public void SetScanCursor()
    {
        _cursorIsScanning = !_cursorIsScanning;

        if (_cursorIsScanning)
        {
            FindObjectOfType<HudController>().EnableScanTutor();
            _followCursor.SetActive(true);
            Cursor.visible = false;
        }
        else
        {
            FindObjectOfType<HudController>().DisableScanTutor();
            _followCursor.SetActive(false);
            Cursor.visible = true;
        }
    }

    private void Select()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        TryShowDialog(ray);

        FindTaleObject(ray);
    }

    private void FindTaleObject(Ray ray)
    {
        if (Physics.Raycast(ray, out _objectHit, _maxDistance, _objectLayer) && _cursorIsScanning)
        {
            if (_objectHit.collider.TryGetComponent<ObjectController>(out ObjectController objectController))
            {
                if (TaleSaves.GetSave(objectController.SaveKey).ObjectFound)
                {
                    _followCursor.ScanFailed();

                    return;
                }
                
                _followCursor.ScanSuccessfull();
                objectController.SetObjectFound();
                SetScanCursor();

                Destroy(_objectHit.collider.gameObject);
            }
        }

        if (_cursorIsScanning)
        {
            _followCursor.ScanFailed();
        }
    }

    private void TryShowDialog(Ray ray)
    {
        if (_cursorIsScanning)
            return;

        if (Physics.Raycast(ray, out _npcHit, _maxDistance, _npcLayer))
        {
            if (_npcHit.collider.gameObject.TryGetComponent<ShowDialogComponent>(
                    out ShowDialogComponent dialogComponent))
            {
                dialogComponent.Show();
            }
        }
    }
}