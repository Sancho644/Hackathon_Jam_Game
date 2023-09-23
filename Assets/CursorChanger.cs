using UnityEngine;

public class CursorChanger : MonoBehaviour
{
    [SerializeField] private Texture2D _cursor;

    private void Start()
    {
        Cursor.SetCursor(_cursor, Vector2.zero, CursorMode.Auto);
    }
}
