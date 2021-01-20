using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/RuneColor")]
public class RuneColorSO : ScriptableObject
{
    [SerializeField] private Color _commonColor;
    [SerializeField] private Color _uncommonColor;
    [SerializeField] private Color _rareColor;
    [SerializeField] private Color _epicColor;
    [SerializeField] private Color _legendaryColor;

    public Color GetRarityColor(RuneSO.RarityEnum rarity)
    {
        return rarity switch
        {
            RuneSO.RarityEnum.Common => _commonColor,
            RuneSO.RarityEnum.Uncommon => _uncommonColor,
            RuneSO.RarityEnum.Rare => _rareColor,
            RuneSO.RarityEnum.Epic => _epicColor,
            RuneSO.RarityEnum.Legendary => _legendaryColor,
            _ => Color.magenta
        };
    }
}
