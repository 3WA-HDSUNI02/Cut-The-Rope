using UnityEngine;

public class RopeLinkController : MonoBehaviour
{
    [SerializeField]
    HingeJoint2D _joint;

    private ChainController _chainController;

    private void Awake()
    {
        _chainController = GetComponentInParent<ChainController>();
    }

    public void OnLinkClicked()
    {
        if(_joint.enabled)
        {
            // Disable this gameObject's joint
            _joint.enabled = false;

            // Then call parent function to disable last in chain
            if(_chainController != null )
            {
                _chainController.DisableLastJoint(_joint);
            }
        }
    }
}
