using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyStar : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.attachedRigidbody.TryGetComponent(out Star star))
        {
            star.Drop();
            //Destroy(star.gameObject);
        }
    }


}
