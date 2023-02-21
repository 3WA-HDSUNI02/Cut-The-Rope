using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonBase : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerMoveHandler, IPointerExitHandler
{
    [Header("Button Graphics")]
    [SerializeField]
    protected Sprite _buttonSpriteHover;
    [SerializeField]
    protected Sprite _buttonSpriteIdle;

    protected Image _buttonImage;
    protected RectTransform _rectTransform;

    private void Awake()
    {
        _buttonImage = GetComponent<Image>();
        _rectTransform = GetComponent<RectTransform>();

        _buttonImage.sprite = _buttonSpriteIdle;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition = _rectTransform.anchoredPosition + Vector2.down * 5f;
        _rectTransform.localScale = new Vector2(.9f, .9f);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition = _rectTransform.anchoredPosition + Vector2.up * 5f;
        _rectTransform.localScale = Vector2.one;
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        _buttonImage.sprite = _buttonSpriteHover;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _buttonImage.sprite = _buttonSpriteIdle;
    }

}
