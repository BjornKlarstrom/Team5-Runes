using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BaseRune {
    public class CreateDragAble : MonoBehaviour {
        [SerializeField] private GameObject _dragAbleGameObjectPrefab;
        [SerializeField] private List<RuneClass.Rune> _dragAbleRuneData; 
        [SerializeField] private Canvas _mainCanvas;
        [SerializeField] private bool mergeSlot = false;
        private CheckRuneAmount _checkRuneAmount;
        private RuneSlot _runeSlot;


        private void Awake() {
            _runeSlot = GetComponent<RuneSlot>();
            if (mergeSlot) return;
            _checkRuneAmount = GetComponentInChildren<CheckRuneAmount>();
        }
        public void CustomCreate(InventorySO inv = null) {
            if (!mergeSlot && ManipulateInventory.FindRuneInInv(_dragAbleRuneData[0], _checkRuneAmount.inventorySO).Amount <= 0) return;
            if (mergeSlot) _dragAbleRuneData[0] = inv.runes[0];

            var go = Instantiate(_dragAbleGameObjectPrefab, transform);
            _runeSlot.dragSlot = go.GetComponent<DragDrop>();
            _runeSlot.dragSlot.currentRuneSlot = gameObject;
            _runeSlot.dragSlot.canvas = _mainCanvas;
            _runeSlot.dragSlot.dragAbleRuneData = _dragAbleRuneData[0];
        }

        public void Update() {
            if (mergeSlot) return;

            if (_checkRuneAmount._amount > 0 && _runeSlot.dragSlot == null) CustomCreate();
            else if (_checkRuneAmount._amount <= 0 && _runeSlot.transform.childCount > 1) 
                Destroy(GetComponentInChildren<DragDrop>().gameObject);
        }
    }
}

