using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCandy : MonoBehaviour
{
    public event Action OnDetectStart;
    public event Action OnDetectStop;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.TryGetComponent<Candy>(out var c))
        {
            OnDetectStart?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.TryGetComponent<Candy>(out var c))
        {
            OnDetectStop?.Invoke();
        }
    }

}
