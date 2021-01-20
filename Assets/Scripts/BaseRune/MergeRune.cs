using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace BaseRune {
    //Breaks
    public class MergeRune : RuneClass{
        public static Rune Merge(List<Rune> runes) {
            const int mergeAmount = 1;
            Rune.RarityEnum baseRarity = runes[0].Rarity;

            int chanceForUpgrade = runes.Count switch {2 => 20, 3 => 55, 4 => 95, _ => 0};
            
            if (Random.Range(0, 100) < chanceForUpgrade && Enum.GetNames(typeof(Rune.RarityEnum)).Length != (int)runes[0].Rarity)
                baseRarity = (Rune.RarityEnum)Enum.GetValues(typeof(Rune.RarityEnum)).GetValue((int)baseRarity + 1);
            
            return new Rune(baseRarity, runes[Random.Range(0, runes.Count)].Stat, mergeAmount);
        }
    }
}
