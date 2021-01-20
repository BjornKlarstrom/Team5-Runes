using System.Linq;

namespace BaseRune
{
    public static class ManipulateInventory {

        public static void Add(RuneClass.Rune removeRune, InventorySO inventory) {
            var rune = FindRuneInInv(removeRune, inventory);
            if (rune != null) rune.Amount++;
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
            return inventory.runes.FirstOrDefault(rune => rune.Rarity == findRune.Rarity && rune.Stat == findRune.Stat);
        }
    }
}
