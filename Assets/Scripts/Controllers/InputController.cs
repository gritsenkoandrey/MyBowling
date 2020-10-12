using UnityEngine;


public sealed class InputController : IExecute
{
    private readonly KeyCode _escape = KeyCode.Escape;

    public InputController()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    #region IExecute

    public void Execute()
    {
        if (Input.GetKeyDown(_escape))
        {
            return;
        }
    }

    #endregion
}