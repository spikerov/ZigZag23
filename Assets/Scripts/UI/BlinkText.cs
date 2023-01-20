using UnityEngine;
using TMPro;

public class BlinkText : MonoBehaviour
{
    [SerializeField] private float _rateBlink;
    [SerializeField] private TMP_Text _textToPlay;

    void Update()
    {
        float timeBlink = Mathf.PingPong(Time.time * _rateBlink, 1);
        _textToPlay.color = Color.Lerp(Color.black, Color.clear, timeBlink);
    }
}
