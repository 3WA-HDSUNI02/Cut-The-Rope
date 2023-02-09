using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] EatCandy _eat;

    public event Action OnAteCandy;

    private void Start()
    {
        _eat.OnEat += _eat_OnEat;
    }

    private void OnDestroy()
    {
        _eat.OnEat -= _eat_OnEat;
    }

    private void _eat_OnEat()
    {
        OnAteCandy?.Invoke();
    }
}
