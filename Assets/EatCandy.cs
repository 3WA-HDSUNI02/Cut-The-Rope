using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatCandy : MonoBehaviour
{
    public event Action OnEat;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.attachedRigidbody.TryGetComponent(out Candy c))
        {
            OnEat?.Invoke();
            Destroy(c.gameObject);
        }
    }
}
