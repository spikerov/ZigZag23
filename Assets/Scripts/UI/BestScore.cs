using UnityEngine;

public class BestScore : MonoBehaviour
{
    [SerializeField] private Score _score;

    private int _bestScore;
    private const string _keyBestScore = "Best Score";

    private void Start()
    {
        ChangeBestScore();
    }

    private void OnEnable()
    {
        Ball.OnGameOverEvent += ChangeBestScore;
    }

    private void OnDisable()
    {
        Ball.OnGameOverEvent -= ChangeBestScore;
    }

    private void ChangeBestScore()
    {
        if (PlayerPrefs.HasKey(_keyBestScore) == false)
        {
            _bestScore = _score.ScoreCount;
            PlayerPrefs.SetInt(_keyBestScore, _bestScore);
        }
        else if (PlayerPrefs.GetInt(_keyBestScore) < _score.ScoreCount)
        {
            _bestScore = _score.ScoreCount;
            PlayerPrefs.SetInt(_keyBestScore, _bestScore);
        }
    }
}
