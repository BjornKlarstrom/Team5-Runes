using System;
using Random = UnityEngine.Random;

namespace BaseRune {
    public class RuneClass {
        public class Rune {
            public enum RarityEnum { Common, Uncommon, Rare, Epic, Legendary }
            public enum StatEnum { Strength, Intelligence, Agility }
            public RarityEnum Rarity;
            public StatEnum Stat;
        
            public Rune() {
                Array values = Enum.GetValues(typeof(StatEnum));
            
                Rarity = RarityEnum.Common;
                Stat = (StatEnum)values.GetValue(Random.Range(0, values.Length));
            }
        
            public Rune(RarityEnum rarity, StatEnum stat) {
                Rarity = rarity;
                Stat = stat;
            }
        }
    }
}
