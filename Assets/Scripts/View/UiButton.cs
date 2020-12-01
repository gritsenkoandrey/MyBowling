using UnityEngine;
using UnityEngine.UI;


public sealed class UiButton : MonoBehaviour
{
    private Button _button;

    public Button GetButton
    {
        get
        {
            if (!_button)
            {
                _button = GetComponentInChildren<Button>();
            }
            return _button;
        }
    }
}