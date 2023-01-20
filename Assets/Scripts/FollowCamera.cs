using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private BallMover _ball;

    private bool _inGame = false;
    private float _speed = 5f;
    private Vector3 _direction = new Vector3(1.0f, 0.0f, 1.0f);

    private void OnEnable()
    {
        TapToPlay.OnStartGameEvent += OnStartGame;
        PanelPause.OnGame += OnStartGame;
        PanelPause.OnPause += StopMotionCamera;
        Ball.OnGameOverEvent += StopMotionCamera;
    }

    private void OnDisable()
    {
        TapToPlay.OnStartGameEvent -= OnStartGame;
        PanelPause.OnGame -= OnStartGame;
        PanelPause.OnPause -= StopMotionCamera;
        Ball.OnGameOverEvent -= StopMotionCamera;
    }

    void LateUpdate()
    {
        if (_inGame == true)
        {
            transform.Translate(_direction * _speed * Time.deltaTime, Space.World);
        }
    }

    private void OnStartGame()
    {
        _inGame = true;
    }

    private void StopMotionCamera()
    {
        _inGame = false;
    }
}