using System;

namespace BaseRune {
    public class InvClass : RuneClass.Rune {
        [Serializable]
        public class Inv {
            public int Amount;
            public RarityEnum Rarity;
            public StatEnum Stat;
            
            public Inv (RarityEnum rarity, StatEnum stat, int amount) {
                Rarity = rarity;
                Stat = stat;
                Amount = amount;
            } 
        }
    }
}