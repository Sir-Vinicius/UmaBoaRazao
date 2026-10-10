using UnityEngine;
using UnityEngine.EventSystems;

public class UIHoverSound : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private UISoundController uiSound;

    public void OnPointerEnter(PointerEventData eventData)
    {
        uiSound.PlayHover();
    }
}
