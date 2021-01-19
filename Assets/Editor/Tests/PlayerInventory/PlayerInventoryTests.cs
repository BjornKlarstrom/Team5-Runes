using NUnit.Framework;
using UnityEngine;

namespace Editor.Tests.PlayerInventory {
    public class PlayerInventoryTests 
    {
    
    
        [Test]
        public void ContentNotNull()
        {
            global::PlayerInventory p = new global::PlayerInventory();
            Assert.IsNotNull(p.Content);
        }

        [Test]
        public void ContentNotEmpty()
        {
            global::PlayerInventory p = new global::PlayerInventory();
            global::AllRunes allRunes = GameObject.FindObjectOfType<global::AllRunes>();
        
            p.AddRune(allRunes.allRunes[0]);
            Assert.NotZero(p.Content.Count);
        }

        [Test]
        public void TestAddInsertsRune()
        {
            global::AllRunes allRunes = GameObject.FindObjectOfType<global::AllRunes>();
            global::PlayerInventory p = new global::PlayerInventory();
            p.AddRune(allRunes.allRunes[0]);
            Assert.True(p.Content.ContainsKey(allRunes.allRunes[0]));
        }
    
        [Test]
        public void AddIncrementsRuneAmount()
        {
            global::AllRunes allRunes = GameObject.FindObjectOfType<global::AllRunes>();
            global::PlayerInventory p = new global::PlayerInventory();
            var theRune = allRunes.allRunes[0];
            p.AddRune(theRune);
            p.AddRune(theRune);
            Assert.True(p.Content[theRune] == 2);
        }

        [Test]
        public void RemoveRune()
        {
            global::AllRunes allRunes = GameObject.FindObjectOfType<global::AllRunes>();
        
            global::PlayerInventory playerInventory = new global::PlayerInventory();
            var theRune = allRunes.allRunes[0];
        
            playerInventory.AddRune(theRune);
            playerInventory.RemoveRune(theRune);
            Assert.False(playerInventory.Content.TryGetValue(theRune, out int a));
        }
    
        [Test]
        public void RemoveRuneDecrements()
        {
            global::AllRunes allRunes = GameObject.FindObjectOfType<global::AllRunes>();
        
            global::PlayerInventory playerInventory = new global::PlayerInventory();
            var theRune = allRunes.allRunes[0];
        
            playerInventory.AddRune(theRune);
            playerInventory.AddRune(theRune);
            playerInventory.RemoveRune(theRune);
            Assert.True(playerInventory.Content[theRune] == 1);
        }
    
    
    
    
    
    

    }
}
