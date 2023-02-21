using UnityEngine;

public class CandyBounds : MonoBehaviour
{
    [SerializeField]
    private LayerMask _boundsLayerMask;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(_boundsLayerMask.value == 1 << collision.gameObject.layer)
        {
            EventManager.Instance.OnCandyOutOfBounds();
        }
    }
}
