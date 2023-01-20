using TMPro;
using UnityEngine;

public class GamesPlayedView : MonoBehaviour
{
    [SerializeField] private TMP_Text _countPlayedGames;

    private const string _keyCountGamesPlayed = "Count Games Played";

    public void Start()
    {
        if (!PlayerPrefs.HasKey(_keyCountGamesPlayed))
        {
            _countPlayedGames.text = "0";
        }
        else
        {
            _countPlayedGames.text = PlayerPrefs.GetInt(_keyCountGamesPlayed) + "";
        }
    }
}
