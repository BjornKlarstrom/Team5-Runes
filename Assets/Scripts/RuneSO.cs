using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Rune")]
public class RuneSO : ScriptableObject
{
    public UnityAction<int> OnInventoryAmountChanged;
    public UnityAction OnRuneMerged;

    [SerializeField] private string _name;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private RarityEnum _rarity;
    [SerializeField] private StatEnum _stat;
    public string Name => _name;
    public Sprite Sprite => _sprite;
    public RarityEnum Rarity => _rarity;
    public StatEnum Stat => _stat;
    
    public enum StatEnum { Strength, Intelligence, Agility }
    public enum RarityEnum { Common, Uncommon, Rare, Epic, Legendary }
}