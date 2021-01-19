using System;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Internal;
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

    public class DropRune
    {
        GameObject gameObject = new GameObject();
        private DragDrop dragDrop;
        private RuneSlot runeSlotFrom;
        private RuneSlot runeSlotTo;
        private List<RuneSO> allRunes;
        global::Controller controller;
        private RuneSO rune0;
        private RuneSO rune1;
        private global::PlayerInventory playerInventory;

        public DropRune()
        {
            dragDrop = gameObject.AddComponent<DragDrop>();
            runeSlotFrom = gameObject.AddComponent<RuneSlot>();
            runeSlotTo = gameObject.AddComponent<RuneSlot>();
            allRunes = GameObject.FindObjectOfType<global::AllRunes>().allRunes;
            controller = new global::Controller();
            rune0 = allRunes[0];
            rune1 = allRunes[1];
            playerInventory = new global::PlayerInventory();
        }

        [Test]
        public void FromMergeslotToMergeslotSameRune() // rune with same rarity and same stat
        {
            runeSlotTo.currentRune = rune0;
            dragDrop.runeBeingDragged = rune0;
            
            controller.DropRune(rune0, runeSlotTo);
            // merge inventory unchanged
            // player inventory unchanged
            // dragdrop rune is unchanged
            // runeSlotTo is unchanged
        }
        
        [Test]
        public void ToAndFromAreNotEqual(IInventory from, IInventory to) {
            var controller = new global::Controller();
            var playerInventory = new global::PlayerInventory();
            var mergeInventory = new global::MergeInventory();
            var runes = GameObject.FindObjectOfType<global::AllRunes>().allRunes;
            controller.Move(runes[0], playerInventory, mergeInventory);
            
            Assert.AreNotEqual(playerInventory, mergeInventory);
        }
        
    }
}
