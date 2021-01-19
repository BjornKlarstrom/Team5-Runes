using NUnit.Framework;
using UnityEngine;

namespace Tests {
    
    public class MergeInvTest {
        
        public class Content {

            [Test]
            public void ContentNotNull() {
                var mergeInventory = new MergeInventory();
                Assert.IsNotNull(mergeInventory.Content);
            }

            [Test]
            public void ContentNotEmpty() {
                var mergeInventory = new MergeInventory();
                var allRunes = GameObject.FindObjectOfType<AllRunes>();
                mergeInventory.AddRune(allRunes.allRunes[0]);

                Assert.NotZero(mergeInventory.Content.Count);
            }
        }

        public class AddRune {

            [Test]
            public void TestAddInsertsRune() {
                var allRunes = GameObject.FindObjectOfType<AllRunes>();
                var mergeInventory = new MergeInventory();
                mergeInventory.AddRune(allRunes.allRunes[0]);

                Assert.True(mergeInventory.Content.ContainsKey(allRunes.allRunes[0]));
            }

            [Test]
            public void AddIncrementsRuneAmount() {
                var allRunes = GameObject.FindObjectOfType<AllRunes>();
                var mergeInventory = new MergeInventory();
                var theRune = allRunes.allRunes[0];

                mergeInventory.AddRune(theRune);
                mergeInventory.AddRune(theRune);

                Assert.True(mergeInventory.Content[theRune] == 2);
            }

            [Test]
            public void AtCapacityReturnsFalse() {
                //TODO fix potentially faulty test or code
                var allRunes = GameObject.FindObjectOfType<AllRunes>();
                var mergeInventory = new MergeInventory(4);
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
        }

        public class RemoveRune {

            [Test]
            public void AddThenRemove() {
                var allRunes = GameObject.FindObjectOfType<AllRunes>();
                var mergeInventory = new MergeInventory(4);
                var theRune = allRunes.allRunes[0];

                mergeInventory.AddRune(theRune);
                mergeInventory.RemoveRune(theRune);

                Assert.False(mergeInventory.Content.TryGetValue(theRune, out var value));
            }

            [Test]
            public void AmountDecrements() {
                var allRunes = GameObject.FindObjectOfType<AllRunes>();
                var mergeInventory = new MergeInventory(4);
                var theRune = allRunes.allRunes[0];

                mergeInventory.AddRune(theRune);
                mergeInventory.AddRune(theRune);
                mergeInventory.RemoveRune(theRune);

                Assert.True(mergeInventory.Content[theRune] == 1);
            }
        }
    }
}