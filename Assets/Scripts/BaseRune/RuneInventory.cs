using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BaseRune
{
    /*
    public class RuneInventory : MonoBehaviour {
        public readonly List<Rune> Inventory = new List<Rune>();
        public readonly List<Rune> MergeRunesSlot = new List<Rune>();
        public Dictionary<RuneClass.Rune, int> _runes = new Dictionary<RuneClass.Rune, int>();
        
        void Start () {
            MergeRunesSlot.AddRange(new List<Rune> {
                new Rune(Rune.RarityEnum.Uncommon, Rune.StatEnum.Strength),
                new Rune(Rune.RarityEnum.Uncommon, Rune.StatEnum.Intelligence),
                new Rune(Rune.RarityEnum.Uncommon, Rune.StatEnum.Agility),
            });
            
            Rune mergedRune = Rune.Merge(MergeRunesSlot);
            Rune customRune = new Rune(Rune.RarityEnum.Uncommon, Rune.StatEnum.Intelligence);
            Rune randomCommonRune = new Rune();
            
            Inventory.Add(mergedRune);
            Inventory.Add(customRune);
            Inventory.Add(randomCommonRune);
            
        }
    }
    */
}
