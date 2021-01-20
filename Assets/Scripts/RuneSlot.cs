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
      Debug.Log(gameObject.GetComponent<CreateDragAble>());
      if (mergeSlot == false) gameObject.GetComponent<CreateDragAble>().Create();
   }


   public void OnPointerDown(PointerEventData eventData) {
      if (mergeSlot || dragSlot != null) return;
      
      /*
      var dragDrop = eventData.hovered.Find(gameObject => gameObject != null && gameObject.GetComponent<RuneSlot>() != null);
      dragDrop.GetComponent<CreateDragAble>().Create();
      */
   }
   
   public void OnDrop(PointerEventData eventData) {
      if (eventData.pointerDrag == null) return;
      var dragDrop = eventData.pointerDrag.GetComponent<DragDrop>();

      if (dragDrop.dragAbleRuneData.Rarity == acceptableRune.Rarity && dragDrop.dragAbleRuneData.Stat == acceptableRune.Stat || mergeSlot) {
         if (!mergeSlot) Destroy(dragSlot.gameObject);

         eventData.pointerDrag.GetComponent<Transform>().position = this.transform.position;
         eventData.pointerDrag.transform.SetParent(transform);
         
         if (dragSlot == null) dragSlot = dragDrop;

         if (mergeSlot) return;
         ManipulateInventory.Add(dragSlot.dragAbleRuneData, inv);
      }
      else 
         StartCoroutine(dragDrop.MoveToPreviousSlot());
   }
}