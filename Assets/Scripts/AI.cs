using UnityEngine;

public class AI : MonoBehaviour
{
    [SerializeField] private bool _ai = false;
    [SerializeField] private float _speed = 9f;
    [SerializeField] private float _minDistanceToPoint = 0.1f;
    [SerializeField] private ButtonColorChanger _buttonColorChanger;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private LevelGenerator _levelGenerator;

    private Vector3 _startPosition = new Vector3(0, 3, 7.5f);
    private Vector3 _targetPoint;
    private int _numberTargetPoint = 0;
    private bool _onGame = false;

    public bool OnAI => _ai;

    private void OnEnable()
    {
        TapToPlay.OnStartGameEvent += OnGame;
    }

    private void OnDisable()
    {
        TapToPlay.OnStartGameEvent -= OnGame;
    }

    private void Start()
    {
        _targetPoint = _startPosition;
    }

    private void Update()
    {
        if (_ai == true)
        {
            if (_onGame == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, _targetPoint, Time.deltaTime * _speed);
                _rigidbody.gameObject.transform.position = Vector3.MoveTowards(transform.position, _targetPoint, Time.deltaTime * _speed);
                var distranceSqure = (transform.position - _targetPoint).magnitude;

                if (distranceSqure < _minDistanceToPoint)
                {
                    for (int i = 0; i < _levelGenerator._listBlocks.Count; i++)
                    {
                        if (_levelGenerator._listBlocks[i].name == "Platform" + _numberTargetPoint)
                        {
                            _targetPoint = new Vector3(_levelGenerator._listBlocks[i].transform.position.x, 3f, _levelGenerator._listBlocks[i].transform.position.z);
                            break;
                        }
                    }

                    _numberTargetPoint++;
                }
            }
        }
    }

    public void TurnOnAI()
    {
        if (_ai == true)
        {
            _ai = false;
            _buttonColorChanger.ChangeColorButtonOff();
        }
        else
        {
            _ai = true;
            _buttonColorChanger.ChangeColorButtonOn();
        }
    }

    private void OnGame()
    {
        _onGame = true;
    }


}
