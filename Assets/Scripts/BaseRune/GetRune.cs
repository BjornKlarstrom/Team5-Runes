using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace BaseRune {
    public class GetRune : MonoBehaviour {
        List<Rune> Inventory = new List<Rune>();
        List<Rune> mergeRunes = new List<Rune>();
        
        void Start () {
            Button btn = GetComponent<Button>();
            btn.onClick.AddListener(TaskOnClick);
            
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
        }

        void TaskOnClick(){ 
            Debug.Log("test");
            
            Debug.Log(Inventory[0].Rarity);
            Debug.Log(Inventory[0].Stat);
            
            Debug.Log("\n");
            
            Debug.Log(Inventory[1].Rarity);
            Debug.Log(Inventory[1].Stat);
            
            Debug.Log("\n");

            Debug.Log(Inventory[2].Rarity);
            Debug.Log(Inventory[2].Stat);

        }
    }
}
