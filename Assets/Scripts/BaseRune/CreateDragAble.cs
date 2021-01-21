using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

namespace BaseRune {
    public class CreateDragAble : MonoBehaviour {
        [SerializeField] private GameObject _dragAbleGameObjectPrefab;
        [SerializeField] private List<Sprite>_sprite;
        [SerializeField] private RuneColorSO colors;
        [SerializeField] private List<RuneClass.Rune> _dragAbleRuneData; 
        [SerializeField] private Canvas _mainCanvas;
        [SerializeField] private bool mergeSlot = false;
        private Sprite useSprite;
        private Color useColor;
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


            if (_sprite.Count == 1)useSprite = _sprite[0];
            else {
                useSprite = _dragAbleRuneData[0].Stat switch {
                    RuneClass.Rune.StatEnum.Strength => _sprite[0],
                    RuneClass.Rune.StatEnum.Intelligence => _sprite[1],
                    RuneClass.Rune.StatEnum.Agility => _sprite[2],
                    _ => useSprite
                };
            }
            
            useColor = _dragAbleRuneData[0].Rarity switch {
                RuneClass.Rune.RarityEnum.Common => colors._commonColor,
                RuneClass.Rune.RarityEnum.Uncommon => colors._uncommonColor,
                RuneClass.Rune.RarityEnum.Rare => colors._rareColor,
                RuneClass.Rune.RarityEnum.Epic => colors._epicColor,
                RuneClass.Rune.RarityEnum.Legendary => colors._legendaryColor,
                _ => useColor
            };


                var go = Instantiate(_dragAbleGameObjectPrefab, transform);
            _runeSlot.dragSlot = go.GetComponent<DragDrop>();
            _runeSlot.dragSlot.GetComponent<Image>().sprite = useSprite;
            _runeSlot.dragSlot.GetComponent<Image>().color = useColor;
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

