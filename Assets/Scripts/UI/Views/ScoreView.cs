using UnityEngine;
using TMPro;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private Score _score;
    [SerializeField] private TMP_Text _textScore;

    private int _scoreCount;

    private void Start()
    {
        _scoreCount = _score.ScoreCount;
        _textScore.text = _scoreCount + "";
    }

    public void DisplayScoreCount(int scoreCount)
    {
        _textScore.text = scoreCount + "";
    }
}
