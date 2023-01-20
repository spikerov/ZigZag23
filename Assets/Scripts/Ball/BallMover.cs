using UnityEngine;

public class BallMover : MonoBehaviour, IMove, IDirection
{
    [SerializeField] private AI _ai;
    [SerializeField] private float _speed = 0.2f;

    private Vector3 _direction = Vector3.right;
    private bool _inGame = false;

    public Vector3 Direction => _direction;
    public float Speed => _speed;

    private void OnEnable()
    {
        TapToPlay.OnStartGameEvent += OnStartGame;
    }

    private void OnDisable()
    {
        TapToPlay.OnStartGameEvent -= OnStartGame;
    }

    private void FixedUpdate()
    {
        if (_ai.OnAI == false && _inGame == true)
        {
            Move();
        }
    }

    public void Move()
    {
        transform.Translate(_direction.normalized * _speed);
    }

    private void OnStartGame()
    {
        _inGame = true;
    }

    public void ChangeDirection(Vector3 direction)
    {
        _direction = direction;
    }
}