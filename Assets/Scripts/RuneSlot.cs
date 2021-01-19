using UnityEngine;
using UnityEngine.EventSystems;

public class RuneSlot : MonoBehaviour, IDropHandler
{
   public RuneSO currentRune;
   public void OnDrop(PointerEventData eventData)
   {
      if (eventData.pointerDrag != null)
      {
         eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
            GetComponent<RectTransform>().anchoredPosition;
      }
   }
}
