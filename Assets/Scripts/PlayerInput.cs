using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private BallMover _ballMover;
    [SerializeField] private AI _ai;
    [SerializeField] private AudioSource _audio;

    public static Action OnTap;

    private void Update()
    {
        GetTouchInput();
    }

    private void GetTouchInput()
    {
        if (_ai.OnAI == false && Input.GetMouseButtonDown(0))
        {
            if (_ballMover.Direction == Vector3.right)
            {
                _ballMover.ChangeDirection(Vector3.forward);
            }
            else
            {
                _ballMover.ChangeDirection(Vector3.right);
            }

            _audio.Play();
            OnTap?.Invoke();
        }
    }
}
