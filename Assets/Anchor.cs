using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor : MonoBehaviour
{

    [SerializeField] int _linkCount;
    [SerializeField] GameObject _linkPrefab;
    [SerializeField] GameObject _destination;
    [SerializeField] float _anchorOffset;
    [SerializeField] int seed;

#if UNITY_EDITOR
    [Button]
    void GenerateRope()
    {
        Debug.Log("coucou");

        GameObject before = null;

        Random.InitState(seed);
        for (int i = 0; i < _linkCount; i++)
        {
            GameObject current = UnityEditor.PrefabUtility.InstantiatePrefab(_linkPrefab) as GameObject;
                current.transform.position = transform.position + new Vector3(0, -i, 0) * _anchorOffset;
                current.transform.rotation = Quaternion.identity;
                current.transform.SetParent(transform);

            current.GetComponentInChildren<SpriteRenderer>().color = Random.ColorHSV(0f, 0.1f, 0.5f, 1f, 0.5f, 1f, 1f, 1f);

            //GameObject current = Instantiate(_linkPrefab,s
            //    transform.position + new Vector3(0, -i, 0) * _anchorOffset,
            //    Quaternion.identity, transform);

            var hinge = current.GetComponent<HingeJoint2D>();
            hinge.connectedBody = before?.GetComponent<Rigidbody2D>();

            //if (before != null)
            //{
            //    hinge.connectedBody = before.GetComponent<Rigidbody2D>();
            //}

            before = current;
        }

        _destination.GetComponent<HingeJoint2D>().connectedBody = before.GetComponent<Rigidbody2D>();
    }
#endif
}
