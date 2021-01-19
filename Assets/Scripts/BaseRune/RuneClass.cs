using System;
using System.Runtime.Serialization;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BaseRune {
    public class RuneClass : MonoBehaviour{
        [Serializable]
        public class Rune {
            public enum RarityEnum { Common, Uncommon, Rare, Epic, Legendary }
            public enum StatEnum { Strength, Intelligence, Agility }
            public RarityEnum Rarity;
            public StatEnum Stat;
            public int Amount;
        
            public Rune() {
                Rarity = RarityEnum.Common;
                Stat = StatEnum.Strength;
                Amount = 1;
            }
        
            public Rune(RarityEnum rarity, StatEnum stat, int amount) {
                Rarity = rarity;
                Stat = stat;
                Amount = amount;
            }
        }
    }
}
