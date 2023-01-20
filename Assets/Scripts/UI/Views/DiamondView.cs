using UnityEngine;
using TMPro;

public class DiamondView : MonoBehaviour
{
    [SerializeField] private TMP_Text _countDiamonds;

    private const string _keyCountDiamonds = "Count Diamonds";

    public void Start()
    {
        _countDiamonds.text = PlayerPrefs.GetInt(_keyCountDiamonds) + "";
    }
}
