using NUnit.Framework;
using UnityEngine;

namespace Editor.Tests.MergeInventory {
    public class MergeInventoryTests {
        [Test]
        public void ContentNotNull() {
            var mergeInventory = new global::MergeInventory();
            Assert.IsNotNull(mergeInventory.Content);
        }

        [Test]
        public void ContentNotEmpty() {
            var mergeInventory = new global::MergeInventory();
            global::AllRunes allRunes = GameObject.FindObjectOfType<global::AllRunes>();

            mergeInventory.AddRune(allRunes.allRunes[0]);
            Assert.NotZero(mergeInventory.Content.Count);
        }

        [Test]
        public void TestAddInsertsRune() {
            global::AllRunes allRunes = GameObject.FindObjectOfType<global::AllRunes>();
            global::MergeInventory mergeInventory = new global::MergeInventory();
            mergeInventory.AddRune(allRunes.allRunes[0]);
            Assert.True(mergeInventory.Content.ContainsKey(allRunes.allRunes[0]));
        }

        [Test]
        public void AddIncrementsRuneAmount() {
            global::AllRunes allRunes = GameObject.FindObjectOfType<global::AllRunes>();
            global::MergeInventory mergeInventory = new global::MergeInventory();
            var theRune = allRunes.allRunes[0];

            mergeInventory.AddRune(theRune);
            mergeInventory.AddRune(theRune);
            Assert.True(mergeInventory.Content[theRune] == 2);
        }

        [Test]
        public void AtCapacityReturnsFalse() {
            //TODO fix potentially faulty test or code
            global::AllRunes allRunes = GameObject.FindObjectOfType<global::AllRunes>();
            global::MergeInventory mergeInventory = new global::MergeInventory(4);
            var theRune = allRunes.allRunes[0];
            for (int i = 0; i < mergeInventory.Capacity; i++) {
                mergeInventory.AddRune(theRune);
            }

            mergeInventory.RemoveRune(theRune);
            mergeInventory.RemoveRune(theRune);
            mergeInventory.AddRune(theRune);
            mergeInventory.AddRune(theRune);


            Assert.False(mergeInventory.AddRune(theRune));
        }

        [Test]
        public void RemoveRune() {
            global::AllRunes allRunes = GameObject.FindObjectOfType<global::AllRunes>();

            global::MergeInventory mergeInventory = new global::MergeInventory(4);
            var theRune = allRunes.allRunes[0];

            mergeInventory.AddRune(theRune);
            mergeInventory.RemoveRune(theRune);
            Assert.False(mergeInventory.Content.TryGetValue(theRune, out int value));
        }

        [Test]
        public void RemoveRuneDecrements() {
            global::AllRunes allRunes = GameObject.FindObjectOfType<global::AllRunes>();

            global::MergeInventory mergeInventory = new global::MergeInventory(4);
            var theRune = allRunes.allRunes[0];
            mergeInventory.AddRune(theRune);
            mergeInventory.AddRune(theRune);
            mergeInventory.RemoveRune(theRune);

            Assert.True(mergeInventory.Content[theRune] == 1);
        }
    }
}