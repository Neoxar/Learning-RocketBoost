using UnityEngine;
using UnityEngine.InputSystem;

public class QuitApplication : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (Keyboard.current.escapeKey.IsPressed())
        {
            Application.Quit();
        }
    }
}
