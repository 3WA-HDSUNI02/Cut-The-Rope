using UnityEngine;

public class CandyTeleport : MonoBehaviour
{
    [SerializeField]
    Candy _candy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.attachedRigidbody.TryGetComponent(out TeleportTransformController teleport))
        {
            teleport.TeleportCandy(_candy);
        }
    }
}
