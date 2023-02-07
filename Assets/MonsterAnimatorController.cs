using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimatorController : MonoBehaviour
{
    [Header("Animator")]
    [SerializeField] Transform _root;
    [SerializeField] Animator _animator;
    [SerializeField] string _detectBoolParam;
    [SerializeField] string _eatTriggerParam;

    [Header("Component")]
    [SerializeField] DetectCandy _detect;
    [SerializeField] EatCandy _eat;

    private void Reset()
    {
        _root = transform.parent.parent;
        _animator = _animator ?? GetComponent<Animator>() ?? _root.GetComponent<Animator>();
        _detect = _detect ?? GetComponent<DetectCandy>() ?? _root.GetComponentInChildren<DetectCandy>();
        _eat = _eat ?? GetComponent<EatCandy>() ?? _root.GetComponentInChildren<EatCandy>();
    }

    private void Start()
    {
        _detect.OnDetectStart += _detect_OnDetectStart;
        _detect.OnDetectStop += _detect_OnDetectStop;

        _eat.OnEat += _eat_OnEat;

    }

    private void OnDestroy()
    {
        _detect.OnDetectStart -= _detect_OnDetectStart;
        _detect.OnDetectStop -= _detect_OnDetectStop;

        _eat.OnEat -= _eat_OnEat;
    }

    private void _eat_OnEat()
    {
        _animator.SetTrigger(_eatTriggerParam);
    }

    private void _detect_OnDetectStart()
    {
        _animator.SetBool(_detectBoolParam, true);
    }
    private void _detect_OnDetectStop()
    {
        _animator.SetBool(_detectBoolParam, false);
    }



}
