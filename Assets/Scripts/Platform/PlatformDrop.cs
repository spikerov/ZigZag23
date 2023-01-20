using System.Collections;
using UnityEngine;

public class PlatformDrop : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _timeToDrop = 0.3f;
    [SerializeField] private float _timeFall = 1f;

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.GetComponent<Ball>())
        {
            StartCoroutine(DropPlatform());
        }
    }

    private IEnumerator DropPlatform()
    {
        yield return new WaitForSeconds(_timeToDrop);
        _rigidbody.isKinematic = false;
        yield return new WaitForSeconds(_timeFall);

        if (gameObject.GetComponentInChildren<Diamond>())
        {
            Destroy(gameObject.GetComponentInChildren<Diamond>().gameObject);
        }

        gameObject.SetActive(false);
    }
}
