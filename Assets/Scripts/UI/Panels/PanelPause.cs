using System;
using UnityEngine;

public class PanelPause : Panel
{
    [SerializeField] private PanelController _panelController;
    [SerializeField] private PanelGameOver _panelGameOver;

    public static Action OnPause; 
    public static Action OnGame;

    private void Start()
    {
        Time.timeScale = 0;
        OnPause?.Invoke();
    }

    public void ContinueGame()
    {
        _panelController.OnGame();
        OnGame?.Invoke();
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void GoToMenu()
    {
        Time.timeScale = 1;
        _panelGameOver.RetryLevel();
    }
}
