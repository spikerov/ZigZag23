using UnityEngine;

public class PanelGame : Panel
{
    [SerializeField] private PanelController _panelController;

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        _panelController.OnPause();
        gameObject.SetActive(false);
    }
}
