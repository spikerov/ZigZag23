using UnityEngine;

public class AnimationDiamond : MonoBehaviour {

    [SerializeField] private bool _isAnimated = false;
    [SerializeField] private bool _isRotating = false;
    [SerializeField] private bool _isFloating = false;
    [SerializeField] private Vector3 _rotationAngle;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _flySpeed;
    [SerializeField] private float _flytRate;

    private float _flyTimer;
    private bool _goingUp = true;

    private void OnEnable()
    {
        PanelPause.OnPause += StopAnimated;
        PanelPause.OnGame += StartAnimated;
    }

    private void OnDisable()
    {
        PanelPause.OnPause -= StopAnimated;
        PanelPause.OnGame -= StartAnimated;
    }

    void Update () {       
        
        if(_isAnimated)
        {
            if(_isRotating)
            {
                transform.Rotate(_rotationAngle * _rotationSpeed * Time.deltaTime);
            }

            if(_isFloating)
            {
                _flyTimer += Time.deltaTime;
                Vector3 moveDirectrion = new Vector3(0.0f, 0.0f, _flySpeed);
                transform.Translate(moveDirectrion);

                if (_goingUp && _flyTimer >= _flytRate)
                {
                    _goingUp = false;
                    _flyTimer = 0;
                    _flySpeed = -_flySpeed;
                }
                else if(!_goingUp && _flyTimer >= _flytRate)
                {
                    _goingUp = true;
                    _flyTimer = 0;
                    _flySpeed = +_flySpeed;
                }
            }
        }
	}

    private void StopAnimated()
    {
        _isAnimated = false;
    }

    private void StartAnimated()
    {
        _isAnimated = true;
    }
}
