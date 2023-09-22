using UI.Dialogs;
using UnityEngine;

public class MouseSelectionController : MonoBehaviour
{
    private const string NpcLayer = "NpcLayer";
    private const string ObjectLayer = "ObjectLayer";

    [SerializeField] private Texture2D cursorTexture;
    [SerializeField] private float _maxDistance;

    private Camera _camera;

    private LayerMask _npcLayer;
    private LayerMask _objectLayer;

    private RaycastHit _npcHit;
    private RaycastHit _objectHit;
    private bool _cursorIsScanning;

    private void Start()
    {
        _camera = Camera.main;

        _npcLayer = 1 << LayerMask.NameToLayer(NpcLayer);
        _objectLayer = 1 << LayerMask.NameToLayer(ObjectLayer);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Select();
        }
    }

    public void SetScanCursor()
    {
        _cursorIsScanning = !_cursorIsScanning;

        if (_cursorIsScanning)
            Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
        else
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    private void Select()
    {
        var ray = _camera.ScreenPointToRay(Input.mousePosition);

        TryShowDialog(ray);

        FindTaleObject(ray);
    }

    private void FindTaleObject(Ray ray)
    {
        if (Physics.Raycast(ray, out _objectHit, _maxDistance, _objectLayer) && _cursorIsScanning)
        {
            if (_objectHit.collider.TryGetComponent<ObjectController>(out ObjectController objectController))
            {
                objectController.SetObjectFound();

                Destroy(_objectHit.collider.gameObject);
            }
        }
    }

    private void TryShowDialog(Ray ray)
    {
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