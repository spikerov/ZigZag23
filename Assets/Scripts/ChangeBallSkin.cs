using UnityEngine;
using UnityEngine.UI;

public class ChangeBallSkin : MonoBehaviour
{
    [SerializeField] private MeshRenderer _ballSkin;
    [SerializeField] private Material _black;
    [SerializeField] private Material _blue;
    [SerializeField] private Material _green;
    [SerializeField] private Material _purple;
    [SerializeField] private Material _red;
    [SerializeField] private Image _colorButton;

    private string _nameSkin;

    public void ChangeSkin()
    {
        _nameSkin = _ballSkin.material.name;

        switch (_nameSkin)
        {
            case "Blank (Instance)":
                _ballSkin.material = _blue;
                _colorButton.color = Color.blue;
                break;
            case "Blue (Instance)":
                _ballSkin.material = _green;
                _colorButton.color = Color.green;
                break;
            case "Green (Instance)":
                _ballSkin.material = _purple;
                _colorButton.color = new Color(233, 0, 255, 255);
                break;
            case "Purple (Instance)":
                _ballSkin.material = _red;
                _colorButton.color = Color.red;
                break;
            case "Red (Instance)":
                _ballSkin.material = _black;
                _colorButton.color = Color.black;
                break;
        }
    }
}
