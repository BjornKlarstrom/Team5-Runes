using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Rune")]
public class RuneSO : ScriptableObject {
    
    [SerializeField] private string _name;
    [SerializeField] private Sprite _sprite;
    public enum RarityEnum { Common, Uncommon, Rare, Epic, Legendary }
    public enum StatEnum { Strength, Intelligence, Agility }
    [SerializeField] private RarityEnum _rarity;
    [SerializeField] private StatEnum _stat;

    public string Name => _name;
    public Sprite Sprite => _sprite;
    public RarityEnum Rarity => _rarity;
    public StatEnum Stat => _stat;
}
/*
static class Program {
        
    static void Main() {
        List<Rune> ownedRunes = new List<Rune>();
        Rune rune = new Rune();
        Rune test = new Rune(Rune.RarityEnum.Uncommon, Rune.StatEnum.Intelligence);
            
        ownedRunes.Add(new Rune(Rune.RarityEnum.Uncommon, Rune.StatEnum.Intelligence));
        ownedRunes.Add(rune);
        ownedRunes.Add(test);
            
        Console.WriteLine(ownedRunes[0].Rarity);
        Console.WriteLine(ownedRunes[0].Stat);
    }
    
        public Rune RandomizeRune(RarityEnum baseRarity, List<StatEnum> allowedStats, int chanceForUpgrade) {
        Rarity = baseRarity;
        if (new Random().Next(0, 100) < chanceForUpgrade) {
            RarityEnum nextValue = Enum.GetValues(typeof(RarityEnum)).Cast<RarityEnum>().SkipWhile(e => e != Rarity).Skip(1).First();
        }
        return new Rune(Rarity, allowedStats[new Random().Next(allowedStats.Count)]);
    }
}
*/