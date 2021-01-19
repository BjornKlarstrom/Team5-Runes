
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Random = System.Random;

public class RuneTest {
    public enum RarityEnum { Common, Uncommon, Rare, Epic, Legendary }
    public enum StatEnum { Strength, Intelligence, Agility }
    public RarityEnum Rarity;
    public StatEnum Stat;
        
    public RuneTest() {
        Array values = Enum.GetValues(typeof(StatEnum));
            
        Rarity = RarityEnum.Common;
        Stat = (StatEnum)values.GetValue(new Random().Next(values.Length));
    }
        
    public RuneTest(RarityEnum rarity, StatEnum stat) {
        Rarity = rarity;
        Stat = stat;
    }
    public static RuneTest Merge(List<RuneTest> runes) {
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
            
        return new RuneTest(baseRarity, runes[new Random().Next(runes.Count)].Stat);
    }
}
    
static class Program {
        
    static void Main() {
        List<RuneTest> Inventory = new List<RuneTest>();
        List<RuneTest> mergeRunes = new List<RuneTest>();
            
        mergeRunes.AddRange(new List<RuneTest> {
            new RuneTest(RuneTest.RarityEnum.Uncommon, RuneTest.StatEnum.Strength),
            new RuneTest(RuneTest.RarityEnum.Uncommon, RuneTest.StatEnum.Intelligence),
            new RuneTest(RuneTest.RarityEnum.Uncommon, RuneTest.StatEnum.Agility),
        });
            
        RuneTest mergedRune = RuneTest.Merge(mergeRunes);
        RuneTest customRune = new RuneTest(RuneTest.RarityEnum.Uncommon, RuneTest.StatEnum.Intelligence);
        RuneTest randomCommonRune = new RuneTest();
        
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