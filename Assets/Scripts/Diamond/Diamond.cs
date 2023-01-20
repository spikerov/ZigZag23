using System;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Collider _collider;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private ParticleSystem _particleSystem;

    public static Action OnGetDiamond;

    private void Awake()
    {
        _particleSystem.Stop();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Ball>())
        {
            _collider.enabled = false;
            OnGetDiamond?.Invoke();
            _meshRenderer.enabled = false;
            _audio.Play();
            _particleSystem.Play();
            Destroy(gameObject, 0.3f);
        }
    }
}
