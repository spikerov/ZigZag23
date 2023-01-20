using UnityEngine;

public class CounterPlayedGames : MonoBehaviour
{
    private int _countGamesPlayed;
    private const string _keyCountGamesPlayed = "Count Games Played";

    private void OnEnable()
    {
        TapToPlay.OnStartGameEvent += ChangeCountPlayedGames;
    }

    private void OnDisable()
    {
        TapToPlay.OnStartGameEvent -= ChangeCountPlayedGames;
    }

    private void Start()
    {
        _countGamesPlayed = PlayerPrefs.GetInt(_keyCountGamesPlayed);
    }

    public void ChangeCountPlayedGames()
    {
        _countGamesPlayed++;
        PlayerPrefs.SetInt(_keyCountGamesPlayed, _countGamesPlayed);
    }
}
