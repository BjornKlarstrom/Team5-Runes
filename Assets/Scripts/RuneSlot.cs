using UnityEngine;
using UnityEngine.EventSystems;

public class RuneSlot : MonoBehaviour, IDropHandler
{
   public RuneSO currentRune;
   public void OnDrop(PointerEventData eventData)
   {
       Debug.Log("rune dropped in slot");
      if (eventData.pointerDrag != null)
      {
         //eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
         eventData.pointerDrag.GetComponent<Transform>().position = this.transform.position;
         eventData.pointerDrag.transform.SetParent(transform);
      }
   }

   public void AddRune(RuneSO rune)
   {
      Debug.Log($"rune added to {gameObject.name}");
   }
}
