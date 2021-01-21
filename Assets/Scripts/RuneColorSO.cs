using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/RuneColor")]
public class RuneColorSO : ScriptableObject
{
    [SerializeField] public Color _commonColor;
    [SerializeField] public Color _uncommonColor;
    [SerializeField] public Color _rareColor;
    [SerializeField] public Color _epicColor;
    [SerializeField] public Color _legendaryColor;

    public Color GetRarityColor(RuneSO.RarityEnum rarity)
    {
        return rarity switch {
            RuneSO.RarityEnum.Common => _commonColor,
            RuneSO.RarityEnum.Uncommon => _uncommonColor,
            RuneSO.RarityEnum.Rare => _rareColor,
            RuneSO.RarityEnum.Epic => _epicColor,
            RuneSO.RarityEnum.Legendary => _legendaryColor,
            _ => Color.magenta
        };
    }
}
