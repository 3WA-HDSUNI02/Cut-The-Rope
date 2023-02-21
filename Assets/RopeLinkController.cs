using System.Collections;
using UnityEngine;

public class RopeLinkController : MonoBehaviour
{
    [SerializeField]
    HingeJoint2D _joint;
    [SerializeField]
    GameObject _slashPrefab;

    private ChainController _chainController;

    private void Awake()
    {
        _chainController = GetComponentInParent<ChainController>();
    }

    public void OnLinkSwiped(Vector2 slashTarget)
    {
        if(_joint.enabled)
        {
            // Disable this gameObject's joint
            _joint.enabled = false;
            GameObject slashGO = Instantiate(_slashPrefab);
            slashGO.transform.position = transform.position;
            slashGO.transform.right = slashTarget;
            StartCoroutine(IE_DestroyGameObject(slashGO, .4f));

            // Then call parent function to disable last in chain
            if(_chainController != null )
            {
                _chainController.DisableLastJoint(_joint);
            }
        }
    }

    private IEnumerator IE_DestroyGameObject(GameObject go, float time)
    {
        // Initialization
        float timer = 0;

        // Loop / coroutine
        while(timer < time)
        {
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        // Coroutine end actions
        Destroy(go);
    }
}
