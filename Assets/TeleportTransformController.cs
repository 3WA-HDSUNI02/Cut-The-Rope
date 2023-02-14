using UnityEngine;

public class TeleportTransformController : MonoBehaviour
{
    TeleportController _teleportController;

    private void Awake()
    {
        _teleportController = GetComponentInParent<TeleportController>();
    }

    public void TeleportCandy(Candy _candy)
    {
        if(_teleportController.GetEntrance() == this)
        {
            _candy.Teleport(_teleportController.GetExit().transform.position);
        }
    }
}
