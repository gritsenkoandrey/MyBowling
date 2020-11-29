using UnityEngine;
using UnityEngine.UI;


public sealed class UiButton : MonoBehaviour
{
    private Text _text;
    private Button _button;

    public Text GetText
    {
        get
        {
            if (!_text)
            {
                _text = GetComponentInChildren<Text>();
            }
            return _text;
        }
    }

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