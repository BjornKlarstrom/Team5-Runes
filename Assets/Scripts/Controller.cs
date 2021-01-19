using System.Security.Cryptography;

public class Controller {
    public RuneSO Merge(RuneSO[] runesToMerge) {
        return null;
    }

    public void PurchaseRunes() {
        // will return 4 random runes
    }

    public bool Move(RuneSO rune, IInventory from, IInventory to) {
        return false;
    }

    public bool AddToInventory(IInventory to, RuneSO rune) {
        return false;
    }

    public void RemoveFromInventory(IInventory inventory, RuneSO rune) {

    }
    
    public void PickupRune(RuneSO rune, RuneSlot fromslot)
    {
        // From PlayerinventorySLot
            //if (playerInventory > 1)
                // TODO Instantiate runeDragNDropprefab on pointer
            // TODO remove 1x rune from inventory

        // From Mergeslot
            //TODO remove rune from merge inventory
    }

    public void DropRune(RuneSO droppedRune, RuneSlot dropSlot)
    {
        // Mergeslot -> Mergeslot
            // if dropSlot empty
                // TODO Add droppedRune to Merge Inventory
            // if dropSlot occupied
                // TODO Add droppedRune to Merge Inventory
                // TODO Remove Rune sitting in occupying prefab from merge inventory
                // TODO Swap prefab on drop slot with prefab in hand
    }

    public void DropRuneOutsideDropslot(RuneSO rune)
    {
        //TODO add 1x rune to player inventory 
    }

}