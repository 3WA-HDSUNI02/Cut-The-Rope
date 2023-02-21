using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    private HingeJoint2D[] _joints;
    private Rigidbody2D _rigidbody;
    private bool _isInsideBubble;

    private void Start()
    {
        EventManager.Instance.onChainBreak += OnChainBreak;
    }

    private void OnDisable()
    {
        EventManager.Instance.onChainBreak -= OnChainBreak;
    }

    private void OnDestroy()
    {
        EventManager.Instance.onChainBreak -= OnChainBreak;
    }

    private void FixedUpdate()
    {
        // Get rigidbody component if null
        if(_rigidbody == null)
            _rigidbody = GetComponent<Rigidbody2D>();

        // Set rigidbody velocity directly using vectors
        if(_isInsideBubble)
        {
            _rigidbody.velocity = Vector2.up * 2f;
        }
    }

    private void OnChainBreak(HingeJoint2D lastJoint)
    {
        _joints = GetComponents<HingeJoint2D>();
        Rigidbody2D jointRigidbody = lastJoint.GetComponent<Rigidbody2D>();

        foreach(HingeJoint2D joint in _joints)
        {
            if (joint.connectedBody == null) continue;
            if(joint.connectedBody == jointRigidbody)
            {
                joint.enabled = false;
            }
        }
    }

    public void SetIsInsideBubble(bool isInsideBubble)
    {
        _isInsideBubble = isInsideBubble;
    }

    public void Teleport(Vector3 position)
    {
        _joints = GetComponents<HingeJoint2D>();

        foreach(HingeJoint2D joint in _joints)
        {
            if (joint.enabled) return;
        }

        transform.position = position;
    }
}
