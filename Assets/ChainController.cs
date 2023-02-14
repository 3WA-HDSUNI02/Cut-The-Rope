using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChainController : MonoBehaviour
{
    private HingeJoint2D[] _joints;

    private void Awake()
    {
        _joints = GetComponentsInChildren<HingeJoint2D>();
    }

    public void DisableLastJoint(HingeJoint2D currentJoint)
    {
        _joints = GetComponentsInChildren<HingeJoint2D>();
        Rigidbody2D currentJointRigidbody = currentJoint.GetComponent<Rigidbody2D>();

        // Loop through all hinge joints in this chain
        foreach(HingeJoint2D joint in _joints)
        {
            // if we find a joint connected to this one, set it as new starting joint
            if(joint.connectedBody == currentJointRigidbody)
            {
                DisableLastJoint(joint);
                break;
            }
        }

        EventManager.Instance.OnChainBreak(currentJoint);
    }
}
