using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Debug = UnityEngine.Debug;
using Random = System.Random;

namespace BaseRune {
    public class Rune {
        public enum RarityEnum { Common, Uncommon, Rare, Epic, Legendary }
        public enum StatEnum { Strength, Intelligence, Agility }
        public RarityEnum Rarity;
        public StatEnum Stat;
        
        public Rune() {
            Array values = Enum.GetValues(typeof(StatEnum));
            
            Rarity = RarityEnum.Common;
            Stat = (StatEnum)values.GetValue(new Random().Next(values.Length));
        }
        
        public Rune(RarityEnum rarity, StatEnum stat) {
            Rarity = rarity;
            Stat = stat;
        }
        public static Rune Merge(List<Rune> runes) {
            RarityEnum baseRarity = runes[0].Rarity;

            int chanceForUpgrade = 0;
            switch (runes.Count) {
                case 2:
                    chanceForUpgrade = 20; 
                    break;
                case 3:
                    chanceForUpgrade = 55;
                    break;
                case 4:
                    chanceForUpgrade = 95;
                    break; 
            }

            if (new Random().Next(0, 100) < chanceForUpgrade && Enum.GetNames(typeof(RarityEnum)).Length != (int)runes[0].Rarity)
                baseRarity = (RarityEnum)Enum.GetValues(typeof(RarityEnum)).GetValue((int)baseRarity + 1);
            
            return new Rune(baseRarity, runes[new Random().Next(runes.Count)].Stat);
        }
    }
    
    static class Program {
        
        static void Main() {
            List<Rune> Inventory = new List<Rune>();
            List<Rune> mergeRunes = new List<Rune>();
            
            mergeRunes.AddRange(new List<Rune> {
                new Rune(Rune.RarityEnum.Uncommon, Rune.StatEnum.Strength),
                new Rune(Rune.RarityEnum.Uncommon, Rune.StatEnum.Intelligence),
                new Rune(Rune.RarityEnum.Uncommon, Rune.StatEnum.Agility),
            });
            
            Rune mergedRune = Rune.Merge(mergeRunes);
            Rune customRune = new Rune(Rune.RarityEnum.Uncommon, Rune.StatEnum.Intelligence);
            Rune randomCommonRune = new Rune();
        
            Inventory.Add(mergedRune);
            Inventory.Add(customRune);
            Inventory.Add(randomCommonRune);

            Debug.Log("test");
                
                
            Console.WriteLine(Inventory[0].Rarity);
            Console.WriteLine(Inventory[0].Stat);
            
            Console.WriteLine("\n");
            
            Console.WriteLine(Inventory[1].Rarity);
            Console.WriteLine(Inventory[1].Stat);
            
            Console.WriteLine("\n");
            
            Console.WriteLine(Inventory[2].Rarity);
            Console.WriteLine(Inventory[2].Stat);
        }
    }
}