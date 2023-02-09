using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Star : MonoBehaviour
{
    [SerializeField] UnityEvent _onDropped;

    public bool IsDropped { get; private set; }


    public event Action OnDropped;

    internal void Drop()
    {
        if (IsDropped) return;

        IsDropped = true;
        OnDropped?.Invoke();
        _onDropped.Invoke();

    }
}
