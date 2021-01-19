using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace Editor {
    public class AllRunesTests 
    {
        [Test]
        public void IsNotNull() {
            var runes = GameObject.FindObjectOfType<AllRunes>().allRunes;
            Assert.IsNotNull(runes);
        }
        
        [Test]
        public void IsNotEmpty() {
            var runes = GameObject.FindObjectOfType<AllRunes>().allRunes; 
            Assert.IsNotEmpty(runes);
        }
        
        [Test]
        public void ContainsFifteenElements() {
            var runes = GameObject.FindObjectOfType<AllRunes>().allRunes;
            Assert.AreEqual(15, runes.Count);
        }
        
        [Test]
        public void AllElementsContainsARune() {
            var runes = GameObject.FindObjectOfType<AllRunes>().allRunes;
            var result = true;
            foreach (var rune in runes) {
                if (rune == null) {
                    result = false;
                }
            }
            Assert.AreEqual(true, result);
        }

        [Test]
        public void HasNoDuplicates() {
            var runes = GameObject.FindObjectOfType<AllRunes>().allRunes;
            var addedRunes = new List<RuneSO>();
            var noDuplicates = true;
            foreach (var rune in runes) {
                if (addedRunes.Contains(rune)) {
                    noDuplicates = false;
                    break;
                }
                addedRunes.Add(rune);
            }
            Assert.AreEqual(true, noDuplicates);
        }
    }
}
