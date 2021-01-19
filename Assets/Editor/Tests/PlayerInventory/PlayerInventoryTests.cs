using NUnit.Framework;
using UnityEngine;

namespace Editor.Tests.PlayerInventory {
    public class Content {
        
        [Test]
        public void ContentNotNull() {
            var playerInventory = new global::PlayerInventory();
            Assert.IsNotNull(playerInventory.Content);
        }
        
        [Test]
        public void ContentNotEmpty() {
            var playerInventory = new global::PlayerInventory();
            var allRunes = GameObject.FindObjectOfType<global::AllRunes>();
            playerInventory.AddRune(allRunes.allRunes[0]);
            
            Assert.NotZero(playerInventory.Content.Count);
        }
    }
    
    public class AddRune {
        
        [Test]
        public void TestAddInsertsRune() {
            var allRunes = GameObject.FindObjectOfType<global::AllRunes>();
            var playerInventory = new global::PlayerInventory();
            playerInventory.AddRune(allRunes.allRunes[0]);

            Assert.True(playerInventory.Content.ContainsKey(allRunes.allRunes[0]));
        }
        
        [Test]
        public void AddIncrementsRuneAmount() {
            var allRunes = GameObject.FindObjectOfType<global::AllRunes>();
            var playerInventory = new global::PlayerInventory();
            var theRune = allRunes.allRunes[0];
            playerInventory.AddRune(theRune);
            playerInventory.AddRune(theRune);

            Assert.True(playerInventory.Content[theRune] == 2);
        }
    }
    
    public class RemoveRune {
        
        [Test]
        public void AddThenRemove() {
            var allRunes = GameObject.FindObjectOfType<global::AllRunes>();
            var playerInventory = new global::PlayerInventory();
            var theRune = allRunes.allRunes[0];

            playerInventory.AddRune(theRune);
            playerInventory.RemoveRune(theRune);

            Assert.False(playerInventory.Content.TryGetValue(theRune, out int a));
        }

        [Test]
        public void RemoveRuneDecrements() {
            var allRunes = GameObject.FindObjectOfType<global::AllRunes>();
            var playerInventory = new global::PlayerInventory();
            var theRune = allRunes.allRunes[0];

            playerInventory.AddRune(theRune);
            playerInventory.AddRune(theRune);
            playerInventory.RemoveRune(theRune);

            Assert.True(playerInventory.Content[theRune] == 1);
        }
    }
}
