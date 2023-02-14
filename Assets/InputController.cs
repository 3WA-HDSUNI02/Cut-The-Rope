using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [SerializeField]
    LayerMask _collidersLayerMask;

    private PlayerInputActions _inputActions;
    private Camera _mainCamera;

    private void Awake()
    {
        _inputActions = new PlayerInputActions();
        _mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        _inputActions.Enable();

        _inputActions.Game.Tap.started += OnTap;
    }

    private void OnDisable()
    {
        _inputActions.Game.Tap.started -= OnTap;

        _inputActions.Disable();
    }

    private void OnTap(InputAction.CallbackContext ctx)
    {
        // Get mouse position from Input System asset
        Vector2 mousePosition = _inputActions.Game.MousePosition.ReadValue<Vector2>();

        // Check For Rope Links colliders
        Ray ray = _mainCamera.ScreenPointToRay(mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, _collidersLayerMask);


        if(hit)
        {
            // If clicked a rope link, call function to disable hinge joint
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Corde"))
            {
                RopeLinkController ropeLinkController = hit.collider.GetComponent<RopeLinkController>();

                if(ropeLinkController != null)
                {
                    ropeLinkController.OnLinkClicked();
                }
            }

            // Else if clicked a bubble, Destroy it
            else if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Bubble"))
            {
                BubbleController bubbleController = hit.collider.GetComponent<BubbleController>();

                if(bubbleController != null)
                {
                    bubbleController.DestroyBubble();
                }
            }
        }
    }
}
