using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Star : MonoBehaviour
{
    [SerializeField] UnityEvent _onDropped;

    [SerializeField, Foldout("params")] int _a;
    [SerializeField, Foldout("params")] int _aa;
    [SerializeField, Foldout("params")] int _aaa;
    [SerializeField, Foldout("params")] int _aaaa;

    public bool IsDropped { get; private set; }


    public event Action OnDropped;

    internal void Drop()
    {
        if (IsDropped) return;

        IsDropped = true;
        OnDropped?.Invoke();
        _onDropped.Invoke();
    }

    [Button("bidule")]
    void SetupSomething()
    {
        Debug.Log("coucou");
    }


}
