using UnityEngine;

public class DiamondVault : MonoBehaviour
{
    [SerializeField] private DiamondView _diamondView;

    private int _countDiamonds;
    private const string _keyCountDiamonds = "Count Diamonds";

    public int CountDiamonds => _countDiamonds;

    private void OnEnable()
    {
        Diamond.OnGetDiamond += AddDiamond;
    }
    private void OnDisable()
    {
        Diamond.OnGetDiamond -= AddDiamond;
    }

    private void Start()
    {
        _countDiamonds = PlayerPrefs.GetInt(_keyCountDiamonds);
    }

    private void AddDiamond()
    {
        _countDiamonds++;
        PlayerPrefs.SetInt(_keyCountDiamonds, _countDiamonds);
    }
}
