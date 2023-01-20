using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private ScoreView _scoreView;

    private int _scoreCount;

    public int ScoreCount => _scoreCount;

    private void OnEnable()
    {
        PlayerInput.OnTap += AddDiamond;
    }
    private void OnDisable()
    {
        PlayerInput.OnTap -= AddDiamond;
    }

    private void AddDiamond()
    {
        _scoreCount++;
        _scoreView.DisplayScoreCount(_scoreCount);
    }
}
