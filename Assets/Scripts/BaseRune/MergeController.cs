using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BaseRune
{
    public class MergeController : MonoBehaviour {
        [SerializeField] public InventorySO mergeInv;
        [SerializeField] public InventorySO mergeResultInv;
        [SerializeField] public List<RuneSlot> runeSlots;
        [SerializeField] public GameObject createAtSlot;

        public void UpdateListAndInv() {
            runeSlots.Clear(); 
            ManipulateInventory.Clear(mergeInv);

            foreach (var slot in GetComponentsInChildren<RuneSlot>())
                if (slot.dragSlot != null) {
                    Debug.Log("added Bby");
                    runeSlots.Add(slot);
                    ManipulateInventory.Add(slot.dragSlot.dragAbleRuneData, mergeInv, true); 
                }
            
            if(mergeInv.runes.Count >= 2)
                MergeRunes();
        }
        
        public void MergeRunes() { 
            var baseRarity = mergeInv.runes[0].Rarity;
            Debug.Log( "merge count: " + mergeInv.runes.Count);
            int chanceForUpgrade = mergeInv.runes.Count switch {2 => 20, 3 => 55, 4 => 95, _ => 0};
            
            if (Random.Range(0, 100) < chanceForUpgrade && Enum.GetNames(typeof(RuneClass.Rune.RarityEnum)).Length != (int)mergeInv.runes[0].Rarity) 
                baseRarity = (RuneClass.Rune.RarityEnum)Enum.GetValues(typeof(RuneClass.Rune.RarityEnum)).GetValue((int)baseRarity + 1);
            ManipulateInventory.Add(new RuneClass.Rune(baseRarity, mergeInv.runes[Random.Range(0, mergeInv.runes.Count)].Stat, 1), mergeResultInv, true);

            foreach (var rune in runeSlots) Destroy(rune.dragSlot.gameObject);
        }

        public void Update() {
            if (mergeResultInv.runes.Count <= 0) return;
            createAtSlot.GetComponent<CreateDragAble>().CustomCreate(mergeResultInv);
            
            runeSlots.Clear(); 
            ManipulateInventory.Clear(mergeInv);
            ManipulateInventory.Clear(mergeResultInv);
        }

        public void SendBackRunes() {
            //Send back runes. Access runes using runeSlots.
        }
    }
}
