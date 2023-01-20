using UnityEngine;
using TMPro;

public class BestScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text _textBestScore;

    private const string _keyBestScore = "Best Score";

    private void Start()
    {
        _textBestScore.text = PlayerPrefs.GetInt(_keyBestScore) + "";
    }
}
