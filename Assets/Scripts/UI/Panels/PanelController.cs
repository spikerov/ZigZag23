using UnityEngine;

public class PanelController : MonoBehaviour
{
    [SerializeField] private PanelMenu _panelMenu;
    [SerializeField] private PanelSetting _panelSetting;
    [SerializeField] private PanelGame _panelGame;
    [SerializeField] private PanelPause _panelPause;
    [SerializeField] private PanelGameOver _panelGameOver;

    private void OnEnable()
    {
        Ball.OnGameOverEvent += OnGameOver;
        TapToPlay.OnStartGameEvent += OnGame;
    }

    private void OnDisable()
    {
        Ball.OnGameOverEvent -= OnGameOver;
        TapToPlay.OnStartGameEvent -= OnGame;
    }

    private void Start()
    {
        OffPanels();
        _panelMenu.gameObject.SetActive(true);
    }

    public void OnMenu()
    {
        PanelActivator(_panelMenu);
    }

    public void OnSetting()
    {
        PanelActivator(_panelSetting);
    }

    public void OnGame()
    {
        PanelActivator(_panelGame);
    }
    
    public void OnPause()
    {
        PanelActivator(_panelPause);
    }

    private void OnGameOver()
    {
        PanelActivator(_panelGameOver); 
    }

    private void OffPanels()
    {
        _panelMenu.gameObject.SetActive(false);
        _panelSetting.gameObject.SetActive(false);
        _panelGame.gameObject.SetActive(false);
        _panelPause.gameObject.SetActive(false);
        _panelGameOver.gameObject.SetActive(false);
    }

    private void PanelActivator(Panel panel)
    {
        OffPanels();
        panel.gameObject.SetActive(true);
    }
}
