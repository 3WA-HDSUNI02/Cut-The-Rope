using UnityEngine;

public class CandyBubble : MonoBehaviour
{
    [SerializeField]
    Candy _candy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.attachedRigidbody.TryGetComponent(out BubbleController bubble))
        {
            bubble.AttachToCandy(_candy);
        }
    }
}
