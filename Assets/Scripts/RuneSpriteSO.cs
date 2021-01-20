using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/RuneSprite")]
public class RuneSpriteSO : ScriptableObject
{
    [SerializeField] private List<RuneSprite> _spriteLookup;
    [SerializeField] private Sprite _defaultSprite;

    public Sprite LookupSprite(RuneSO.StatEnum statEnum)
    {
        Sprite sprite = _spriteLookup.First(r => r.Stat == statEnum).Sprite;
        if (sprite == null)
        {
            sprite = _defaultSprite;
            Debug.LogWarning($"Couldn't find Sprite in list. Using default sprite");
        }
        return sprite;
    }
    
    [System.Serializable]
    public class RuneSprite
    {
        [SerializeField] private RuneSO.StatEnum _stat;
        [SerializeField] private Sprite _sprite;
        public RuneSO.StatEnum Stat => _stat;
        public Sprite Sprite => _sprite;
    }
}
