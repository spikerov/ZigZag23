using UnityEngine;
using UnityEngine.UI;

public class ButtonColorChanger : MonoBehaviour
{
    [SerializeField] private Image _colorButton;

    public void ChangeColorButtonOn()
    {
        _colorButton.color = new Color(233, 0, 255, 255);
    }
    
    public void ChangeColorButtonOff()
    {
        _colorButton.color = Color.black;
    }
}
