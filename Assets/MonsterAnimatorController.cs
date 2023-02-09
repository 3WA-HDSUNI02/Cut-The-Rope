using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimatorController : MonoBehaviour
{
    [Header("Animator")]
    [SerializeField] Transform _root;
    [SerializeField] Animator _animator;
    [SerializeField, AnimatorParam(nameof(_animator))] string _detectBoolParam;
    [SerializeField, AnimatorParam(nameof(_animator))] string _eatTriggerParam;

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
        _detect.OnDetectStart += DetectStart;
        _detect.OnDetectStop += DetectStop;
        _eat.OnEat += Eat;
    }

    private void OnDestroy()
    {
        _detect.OnDetectStart -= DetectStart;
        _detect.OnDetectStop -= DetectStop;

        _eat.OnEat -= Eat;
    }

    private void Eat()
    {
        _animator.SetTrigger(_eatTriggerParam);
    }
    private void DetectStart()
    {
        _animator.SetBool(_detectBoolParam, true);
    }
    private void DetectStop()
    {
        _animator.SetBool(_detectBoolParam, false);
    }

}
