using UnityEngine;


public abstract class BaseController
{
    protected UiInterface uiInterface;
    protected Camera mainCamera;

    protected BaseController()
    {
        uiInterface = new UiInterface();
        mainCamera = Object.FindObjectOfType<Camera>();
    }
}