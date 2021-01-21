using System.Linq;
using UnityEngine;

namespace BaseRune
{
    public static class ManipulateInventory {

        public static void Add(RuneClass.Rune addRune, InventorySO inventory, bool addNewElement = false) {
            if (addNewElement) {
                inventory.runes.Add(addRune);
                return;
            }
            
            var rune = FindRuneInInv(addRune, inventory);
            rune.Amount++;
        }
        
        public static void Remove(RuneClass.Rune removeRune, InventorySO inventory)
        {
            var rune = FindRuneInInv(removeRune, inventory);
            if (rune != null) rune.Amount--;
        }
        
        public static void Clear(InventorySO inventory) {
            inventory.runes.Clear();
        }

        public static RuneClass.Rune FindRuneInInv(RuneClass.Rune findRune, InventorySO inventory) {
            var exists = inventory.runes.FirstOrDefault(rune => rune.Rarity == findRune.Rarity && rune.Stat == findRune.Stat);
            if (exists != null) return exists;
            inventory.runes.Add(findRune);
            return FindRuneInInv(findRune, inventory);

        }
    }
}
