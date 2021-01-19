using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace BaseRune {
    public class GetRune : MonoBehaviour {
        [SerializeField] public InventorySO inventory;
        private readonly List<RuneClass.Rune> _mergeRunes = new List<RuneClass.Rune>();

        void Start () {
            Button btn = GetComponent<Button>();
            btn.onClick.AddListener(TaskOnClick);
        }

        void TaskOnClick() {
            AddRandomCommonRuneToInv(4);
        }

        void AddRandomCommonRuneToInv(int amount) {
            for (int i = 0; i < amount; i++) {
                Array values = Enum.GetValues(typeof(RuneClass.Rune.StatEnum));
                RuneClass.Rune.StatEnum randomStat = (RuneClass.Rune.StatEnum)values.GetValue(Random.Range(0, values.Length));
                RuneClass.Rune randomCommonRune = new RuneClass.Rune(RuneClass.Rune.RarityEnum.Common, randomStat, 1);
            
                foreach (var rune in inventory.runes.Where(rune => rune.Rarity == randomCommonRune.Rarity && rune.Stat == randomCommonRune.Stat))
                    rune.Amount++;
            }
        }
    }
}
