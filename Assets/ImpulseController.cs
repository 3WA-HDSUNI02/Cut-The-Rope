using UnityEngine;

using Cinemachine;

public class ImpulseController : MonoBehaviour
{
    [SerializeField]
    CinemachineImpulseSource _cutImpulseSource;

    private void Start()
    {
        EventManager.Instance.onChainBreak += OnChainBreak;
    }

    private void OnDisable()
    {
        EventManager.Instance.onChainBreak -= OnChainBreak;
    }

    private void OnChainBreak(HingeJoint2D joint)
    {
        _cutImpulseSource.m_ImpulseDefinition.m_ImpulseDuration = .25f;
        _cutImpulseSource.GenerateImpulseWithForce(.1f);
    }
}
