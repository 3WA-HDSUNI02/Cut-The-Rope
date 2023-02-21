using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [SerializeField]
    float _minimumSwipeDistance = 100f;
    [SerializeField]
    float _maximumSwipeTime = .2f;
    [Space]
    [SerializeField]
    LayerMask _collidersLayerMask;

    private PlayerInputActions _inputActions;
    private Camera _mainCamera;

    private Vector2 _swipeStartPosition;
    private Vector2 _swipeEndPosition;
    private float _swipeStartTime;
    private float _swipeEndTime;

    private void Awake()
    {
        _inputActions = new PlayerInputActions();
        _mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        _inputActions.Enable();

        _inputActions.Game.PrimaryTouchTap.started += OnTap;
        _inputActions.Game.PrimaryTouchContact.started += OnPrimaryTouchStart;
        _inputActions.Game.PrimaryTouchContact.canceled += OnPrimaryTouchEnd;
    }

    private void OnDisable()
    {
        _inputActions.Game.PrimaryTouchTap.started -= OnTap;
        _inputActions.Game.PrimaryTouchContact.started -= OnPrimaryTouchStart;
        _inputActions.Game.PrimaryTouchContact.canceled -= OnPrimaryTouchEnd;

        _inputActions.Disable();
    }

    private void OnTap(InputAction.CallbackContext ctx)
    {
        // Get mouse position from Input System asset
        Vector2 mousePosition = _inputActions.Game.PrimaryTouchPosition.ReadValue<Vector2>();

        // Check For Rope Links colliders
        Ray ray = _mainCamera.ScreenPointToRay(mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, _collidersLayerMask);


        if(hit)
        {
            // If clicked a bubble, Destroy it
            if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Bubble"))
            {
                BubbleController bubbleController = hit.collider.GetComponent<BubbleController>();

                if(bubbleController != null)
                {
                    bubbleController.DestroyBubble();
                }
            }
        }
    }

    private void OnPrimaryTouchStart(InputAction.CallbackContext ctx)
    {
        _swipeStartPosition = _inputActions.Game.PrimaryTouchPosition.ReadValue<Vector2>();
        _swipeStartTime = (float)ctx.startTime;
    }
    private void OnPrimaryTouchEnd(InputAction.CallbackContext ctx)
    {
        _swipeEndPosition = _inputActions.Game.PrimaryTouchPosition.ReadValue<Vector2>();
        _swipeEndTime = (float)ctx.time;

        float swipeTime = _swipeEndTime - _swipeStartTime;
        float swipeDistance = Vector2.Distance(_swipeStartPosition, _swipeEndPosition);

        /*Debug.Log($"Swipe Time {swipeTime}");
        Debug.Log($"Swipe Distance {swipeDistance}");*/

        if(swipeDistance >= _minimumSwipeDistance && swipeTime <= _maximumSwipeTime)
        {
            DoSwipe();
        }
    }

    private void DoSwipe()
    {
        // Convert our swipe start and end positions from screen to world space
        Vector2 lineStart = _mainCamera.ScreenToWorldPoint(_swipeStartPosition);
        Vector2 lineEnd = _mainCamera.ScreenToWorldPoint(_swipeEndPosition);

        // Cast a line between both positions with relevant layer masks
        RaycastHit2D hit = Physics2D.Linecast(lineStart, lineEnd, _collidersLayerMask);

        if (hit)
        {
            // If detected a rope link, call function to disable hinge joint
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Corde"))
            {
                RopeLinkController ropeLinkController = hit.collider.GetComponent<RopeLinkController>();

                if (ropeLinkController != null)
                {
                    Vector2 slashTarget = lineStart - lineEnd;
                    ropeLinkController.OnLinkSwiped(slashTarget);
                }
            }
        }
    }
}
