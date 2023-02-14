using UnityEngine;

public class TeleportController : MonoBehaviour
{
    [SerializeField]
    private TeleportTransformController _entrance;
    [SerializeField]
    private TeleportTransformController _exit;

    public TeleportTransformController GetEntrance()
    {
        return _entrance;
    }

    public TeleportTransformController GetExit()
    {
        return _exit;
    }
}
