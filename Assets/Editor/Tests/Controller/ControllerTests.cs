using NUnit.Framework;
using UnityEngine;

namespace Editor.Tests.Controller {
    
    public class Merge {
        
        [Test]
        public void PlaceholderTest() {
            var controller = new global::Controller();
            Assert.AreEqual(true, false);
        }

        [Test]
        public void ReturnsOneRune() {
            var controller = new global::Controller();
            Assert.AreEqual(true, false);
        }

        [Test]
        public void DestroysUsedRunes() {
            var controller = new global::Controller();
            Assert.AreEqual(true, false);
        }

        [Test]
        public void SameRarity() {
            var controller = new global::Controller();
            Assert.AreEqual(true, false);
        }
    }

    public class PurchaseRunes {
        
        [Test]
        public void ReturnsFourRunes() {
            var controller = new global::Controller();
            Assert.AreEqual(true, false);
        }
        
        [Test]
        public void RunesAreCommonQuality() {
            var controller = new global::Controller();
            Assert.AreEqual(true, false);
        }
        
    }

    public class Move {
        
        [Test]
        public void ToAndFromAreNotEqual() {
            var controller = new global::Controller();
            var playerInventory = new global::PlayerInventory();
            var mergeInventory = new global::MergeInventory();
            var runes = GameObject.FindObjectOfType<global::AllRunes>().allRunes;
            //controller.Move(runes[0], inventory, inventory);
            
            Assert.AreEqual(playerInventory, mergeInventory);
        }
    }

    public class AddToInventory {
        
        [Test]
        public void PlaceholderTest() {
            var controller = new global::Controller();
            Assert.AreEqual(true, false);
        }
    }

    public class RemoveFromInventory {
        
        [Test]
        public void PlaceholderTest() {
            var controller = new global::Controller();
            Assert.AreEqual(true, false);
        }
    }
}
