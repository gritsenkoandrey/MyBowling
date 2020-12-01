using UnityEngine;
using UnityEngine.UI;


public sealed class UiShowScore : MonoBehaviour
{
    private Text _textScore = null;

    public int Text
    {
        set
        {
            _textScore.text = $"{value}";
        }
    }

    private void Awake()
    {
        _textScore = GetComponent<Text>();
    }

    public void SetActive(bool value)
    {
        _textScore.gameObject.SetActive(value);
    }
}