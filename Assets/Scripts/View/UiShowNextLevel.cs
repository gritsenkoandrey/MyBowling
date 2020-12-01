using UnityEngine;
using UnityEngine.UI;


public class UiShowNextLevel : MonoBehaviour
{
    private Text _textLevel = null;

    public int Text
    {
        set
        {
            _textLevel.text = $"{value}";
        }
    }

    private void Awake()
    {
        _textLevel = GetComponent<Text>();
    }

    public void SetActive(bool value)
    {
        _textLevel.gameObject.SetActive(value);
    }
}