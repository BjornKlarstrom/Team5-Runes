using NUnit.Framework;
using UnityEngine;

public class MergeInventoryTests 
{
    [Test]
    public void ContentNotNull()
    {
        var mergeInventory = new MergeInventory();
        Assert.IsNotNull(mergeInventory.Content);
    }

    [Test]
    public void ContentNotEmpty()
    {
        var mergeInventory = new MergeInventory();
        AllRunes allRunes = GameObject.FindObjectOfType<AllRunes>();
        
        mergeInventory.AddRune(allRunes.allRunes[0]);
        Assert.NotZero(mergeInventory.Content.Count);
    }

    [Test]
    public void TestAddInsertsRune()
    {
        AllRunes allRunes = GameObject.FindObjectOfType<AllRunes>();
        MergeInventory mergeInventory = new MergeInventory();
        mergeInventory.AddRune(allRunes.allRunes[0]);
        Assert.True(mergeInventory.Content.ContainsKey(allRunes.allRunes[0]));
    }
    
    [Test]
    public void AddIncrementsRuneAmount()
    {
        AllRunes allRunes = GameObject.FindObjectOfType<AllRunes>();
        MergeInventory mergeInventory = new MergeInventory();
        var theRune = allRunes.allRunes[0];
        
        mergeInventory.AddRune(theRune);
        mergeInventory.AddRune(theRune);
        Assert.True(mergeInventory.Content[theRune] == 2);
    }
    
    [Test]
    public void AtCapacityReturnsFalse()
    {
        //TODO fix potentially faulty test or code
        AllRunes allRunes = GameObject.FindObjectOfType<AllRunes>();
        MergeInventory mergeInventory = new MergeInventory(4);
        var theRune = allRunes.allRunes[0];
        for (int i = 0; i <= mergeInventory.Capacity; i++)
        {
            mergeInventory.AddRune(theRune);
        }
        Assert.False(mergeInventory.AddRune(theRune));
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
