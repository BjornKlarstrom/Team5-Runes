using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace BaseRune {
    public class CreateDragAble : MonoBehaviour {
        [SerializeField] private GameObject _dragAbleGameObjectPrefab;
        [SerializeField] private Sprite _dragAbleSprite;
        [SerializeField] private RuneClass.Rune _dragAbleRuneData; 
        [SerializeField] private Canvas _mainCanvas;
        private CheckRuneAmount _checkRuneAmount;
        private RuneSlot _runeSlot;


        private void Awake() {
            _checkRuneAmount = GetComponentInChildren<CheckRuneAmount>();
            _runeSlot = GetComponent<RuneSlot>();
        }

        public void Create() {
            var go = Instantiate(_dragAbleGameObjectPrefab, transform);
            _runeSlot.dragSlot = go.GetComponent<DragDrop>();
            _runeSlot.dragSlot.currentRuneSlot = gameObject;
            _runeSlot.dragSlot._canvas = _mainCanvas;
            _runeSlot.dragSlot.dragAbleRuneData = _dragAbleRuneData;
            _runeSlot.dragSlot.GetComponent<Image>().sprite = _dragAbleSprite;
        }
        


            /*
            if (transform.childCount <= 2 && _checkRuneAmount._amount > 0) {
                if (GetComponentInChildren<DragDrop>() != null && _checkRuneAmount._amount <= 0) return;
                var go = Instantiate(dragableGameObjectPrefab, transform);
                var goData = go.GetComponent<DragDrop>();
                
                goData._canvas = _mainCanvas;
                goData.dragableRuneData = dragableRuneData;
                goData.GetComponent<Image>().sprite = dragableSprite;
                
                /*
                foreach (var rune in inv.runes.Where(rune => rune.Rarity == goData.dragableRuneData.Rarity && rune.Stat == goData.dragableRuneData.Stat))
                    rune.Amount--;
                    
            }
            else {
                if (GetComponentInChildren<DragDrop>() != null) {
                    var go = GetComponentInChildren<DragDrop>();
                    /*
                    foreach (var rune in inv.runes.Where(rune => rune.Rarity == go.dragableRuneData.Rarity && rune.Stat == go.dragableRuneData.Stat))
                        rune.Amount++;
                    
                    
                }
            }
            */
    }
}

