using System;
using UnityEngine;

public class Ball : MonoBehaviour 
{
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _platform;
    [SerializeField] private AudioSource _audio;

    private bool _isPlaying = true;

    public static Action OnGameOverEvent;

    private void Update()
    {
        if (_isPlaying == true && IsGrounded() == false)
        {
            OnGameOverEvent?.Invoke();
            _audio.Play();
            _isPlaying = false;
            Destroy(gameObject, 2);
        }        
        else if (IsGrounded() == true)
        {
            _isPlaying = true;
        }
    }

    private bool IsGrounded()
    {
        return Physics.CheckSphere(_groundCheck.position, 0.5f, _platform);
    }
}
