using NUnit.Framework;
using UnityEngine;

public class PlayerInventoryTests 
{
    
    
    [Test]
    public void ContentNotNull()
    {
        PlayerInventory p = new PlayerInventory();
        Assert.IsNotNull(p.Content);
    }

    [Test]
    public void ContentNotEmpty()
    {
        PlayerInventory p = new PlayerInventory();
        AllRunes allRunes = GameObject.FindObjectOfType<AllRunes>();
        
        p.AddRune(allRunes.allRunes[0]);
        Assert.NotZero(p.Content.Count);
    }

    [Test]
    public void TestAddInsertsRune()
    {
        AllRunes allRunes = GameObject.FindObjectOfType<AllRunes>();
        PlayerInventory p = new PlayerInventory();
        p.AddRune(allRunes.allRunes[0]);
        Assert.True(p.Content.ContainsKey(allRunes.allRunes[0]));
    }
    
    [Test]
    public void AddIncrementsRuneAmount()
    {
        AllRunes allRunes = GameObject.FindObjectOfType<AllRunes>();
        PlayerInventory p = new PlayerInventory();
        var theRune = allRunes.allRunes[0];
        p.AddRune(theRune);
        p.AddRune(theRune);
        Assert.True(p.Content[theRune] == 2);
    }

    [Test]
    public void RemoveRune()
    {
        AllRunes allRunes = GameObject.FindObjectOfType<AllRunes>();
        
        PlayerInventory playerInventory = new PlayerInventory();
        var theRune = allRunes.allRunes[0];
        
        playerInventory.AddRune(theRune);
        playerInventory.RemoveRune(theRune);
        Assert.False(playerInventory.Content.TryGetValue(theRune, out int a));
    }
    
    [Test]
    public void RemoveRuneDecrements()
    {
        AllRunes allRunes = GameObject.FindObjectOfType<AllRunes>();
        
        PlayerInventory playerInventory = new PlayerInventory();
        var theRune = allRunes.allRunes[0];
        
        playerInventory.AddRune(theRune);
        playerInventory.AddRune(theRune);
        playerInventory.RemoveRune(theRune);
        Assert.True(playerInventory.Content[theRune] == 1);
    }
    
    
    
    
    
    

}
