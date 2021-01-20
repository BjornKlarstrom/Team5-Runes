using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

namespace BaseRune {
    public class CheckRuneAmount : MonoBehaviour {
        public InventorySO inventorySO;
        public GameObject draggableObject;
        public Text displayAmount;
        public RuneClass.Rune checkThisRune;
        private Image _hideImage;
        public int _amount;
        private int _invIndex;

        private void Start() {
            _hideImage = gameObject.GetComponent<Image>();

            for (_invIndex = 0; _invIndex < inventorySO.runes.Count; _invIndex++) 
                if (inventorySO.runes[_invIndex].Rarity == checkThisRune.Rarity && inventorySO.runes[_invIndex].Stat == checkThisRune.Stat) {
                    break; 
                }
        }

        private void Update() {
            displayAmount.text = inventorySO.runes[_invIndex].Amount > 0 ? (inventorySO.runes[_invIndex].Amount).ToString() : "";
            
            _amount = inventorySO.runes[_invIndex].Amount;
            inventorySO.runes[_invIndex].Amount = math.max(inventorySO.runes[_invIndex].Amount, 0);
            _hideImage.enabled = inventorySO.runes[_invIndex].Amount != 0;
        }
    }
}
