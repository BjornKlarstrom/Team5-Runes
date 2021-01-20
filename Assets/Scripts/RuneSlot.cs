using System;
using System.Collections.Generic;
using BaseRune;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

public class RuneSlot : MonoBehaviour, IDropHandler, IPointerDownHandler {
   [SerializeField]private InventorySO inv;
   [SerializeField]private RuneClass.Rune acceptableRune;
   [SerializeField]public bool mergeSlot;
   public DragDrop dragSlot;

   public void Start() {
      if (mergeSlot || ManipulateInventory.FindRuneInInv(acceptableRune, inv).Amount <= 0) return;
      ManipulateInventory.Remove(acceptableRune, inv);
      gameObject.GetComponent<CreateDragAble>().Create();

   }


   public void OnPointerDown(PointerEventData eventData) {
      if (mergeSlot || dragSlot != null) return;
      
   }
   
   public void OnDrop(PointerEventData eventData) {
      if (eventData.pointerDrag == null) return;
      var dragDrop = eventData.pointerDrag.GetComponent<DragDrop>();

      if (dragDrop.dragAbleRuneData.Rarity == acceptableRune.Rarity && dragDrop.dragAbleRuneData.Stat == acceptableRune.Stat || mergeSlot)
      {

         if (!mergeSlot) Debug.Log(dragSlot.gameObject);
         if (!mergeSlot) Destroy(dragSlot.gameObject);
         
         dragDrop.CurrentRuneSlot = gameObject;
         dragDrop.GetComponent<Transform>().position = transform.position;
         dragDrop.transform.SetParent(transform);
         
         if (dragSlot == null) dragSlot = dragDrop;

         if (mergeSlot) return;
         ManipulateInventory.Add(dragSlot.dragAbleRuneData, inv);
      }
      else 
         StartCoroutine(dragDrop.MoveToPreviousSlot());
   }
}