using UnityEngine;

public class ChangeMouse : MonoBehaviour
{

    //should be of type CURSOR for this to work
    [SerializeField] Texture2D mouseIcon;

    // offset for the mouse icon from its top-left
    [SerializeField] Vector2 offset;

    void Start()
    {
        // set the cursor icon
        Cursor.SetCursor(mouseIcon, offset, CursorMode.Auto);
    }

    // Hide the mouse during middle of the game
    public void HideMouse()
    {
        Cursor.visible = false;
    }

    // show the mouse when the player needs to click on objects
    public void ShowMouse()
    {
        Cursor.visible = true;
    }
}
