using UnityEngine;

public class BubbleController : MonoBehaviour
{
    private bool _isActive = true;
    private Candy _candy;

    public void DestroyBubble()
    {
        if(_candy != null)
            _candy.SetIsInsideBubble(false);

        gameObject.SetActive(false);
    }

    public void DisableCollision()
    {
        _isActive = false;
    }

    public void AttachToCandy(Candy candy)
    {
        _candy = candy;

        if (_isActive)
        {
            _candy.SetIsInsideBubble(true);
            DisableCollision();
            transform.SetParent(_candy.transform);
            transform.localPosition = Vector3.zero;
        }
    }
}
