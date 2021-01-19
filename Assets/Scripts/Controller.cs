using System.Security.Cryptography;

public class Controller
{
    public RuneSO Merge(RuneSO[] runesToMerge)
    {
        return null;
    }

    public void PurchaseRunes()
    {
        // will return 4 random runes
    }
    public bool Move(RuneSO rune, IInventory from, IInventory to)
    {
        return false;
    }

    public bool AddToInventory(IInventory to, RuneSO rune)
    {
        return false;
    }

    public void RemoveFromInventory(IInventory inventory, RuneSO rune)
    {
        
    }
    
    public void PickupRune(RuneSO rune, RuneSlot fromslot)
    {
        // From PlayerinventorySLot
            //TODO remove 1x rune frominventory
            //TODO Instantiate runeprefab on pointer
            
        // From Mergeslot
            //TODO remove rune from merge inventory
            //TODO Instantiate runeprefab on pointer
    }

    public void DropRune(RuneSO droppedRune, RuneSlot dropSlot)
    {
        // Mergeslot -> Mergeslot
            // handle dropSlot empty
                // Destroy prefab
                // TODO Add rune to dropslot
                // TODO Add rune to Merge Inventory
            // handle dropSlot occupied
                //TODO Remove rune from DragDrop
                //TODO Add 
                
        // Playerslot -> Mergeslot
            // dropslot empty
                // TODO Remove rune from DragDrop, Add Rune To Dropslot, add rune to merge inventory.
            // dropslot occupied
                // TODO Remove Dropslot.rune from merge inventory.
                // TODO Add Dropslot.rune to player inventory
                // TODO add DragDrop.rune to merge inventory
    }    

}
