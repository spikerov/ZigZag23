using System;
using UnityEngine;

public class TapToPlay : MonoBehaviour
{
    public static Action OnStartGameEvent;

    private void OnMouseDown()
    {
        OnStartGameEvent?.Invoke();
    }
}
