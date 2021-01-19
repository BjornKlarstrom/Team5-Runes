using System.Collections.Generic;
using UnityEngine;

namespace BaseRune {
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/RuneInventory")]
    public class InventorySO : ScriptableObject {
        [SerializeField] public List<RuneClass.Rune> runes;
    }
}