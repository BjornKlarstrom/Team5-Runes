using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Rune")]
public class RuneSO : ScriptableObject
{
    public UnityAction<int> OnInventoryAmountChanged;
    public UnityAction OnRuneMerged;

    [SerializeField] private string _name;
    [SerializeField] private RarityEnum _rarity;
    [SerializeField] private RuneColorSO _rarityColor;
    [SerializeField] private RuneSpriteSO _runeSprite;
    [SerializeField] private StatEnum _stat;
    public string Name => _name;
    public RarityEnum Rarity => _rarity;

    public Color RarityColor => _rarityColor.GetRarityColor(Rarity);
    public Sprite Sprite => _runeSprite.LookupSprite(_stat);
    public StatEnum Stat => _stat;
    
    public enum StatEnum { Strength, Intelligence, Agility }
    public enum RarityEnum { Common, Uncommon, Rare, Epic, Legendary }
}