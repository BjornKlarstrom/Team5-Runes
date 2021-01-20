using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

namespace BaseRune
{
    public class CheckRuneAmount : MonoBehaviour
    {
        public InventorySO inventorySO;
        public GameObject draggableObject;
        public Text displayAmount;
        public RuneClass.Rune checkForRune;
        private Image _hideImage;
        private bool _hide;
        private int _amount = 0;
        private int _invIndex;

        private void Start() {
            _hideImage = gameObject.GetComponent<Image>();

            for (_invIndex = 0; _invIndex < inventorySO.runes.Count; _invIndex++) 
                if (inventorySO.runes[_invIndex].Rarity == checkForRune.Rarity && inventorySO.runes[_invIndex].Stat == checkForRune.Stat) {
                    break; 
                }
        }

        private void Update() {
            displayAmount.text = inventorySO.runes[_invIndex].Amount > 1 ? inventorySO.runes[_invIndex].Amount.ToString() : "";
        
            _hide = inventorySO.runes[_invIndex].Amount > 0;
            draggableObject.SetActive(_hide);
            _hideImage.enabled = _hide;
        }
    }
}
