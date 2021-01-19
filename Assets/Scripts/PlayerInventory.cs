using System.Collections.Generic;

public class PlayerInventory : IInventory {
    public PlayerInventory() {
        _content = new Dictionary<RuneSO, int>();
    }

    private Dictionary<RuneSO, int> _content;

    public Dictionary<RuneSO, int> Content => _content;

    public bool AddRune(RuneSO rune) {
        if (_content.TryGetValue(rune, out int currentAmount)) {
            _content[rune] = currentAmount + 1;
        } else {
            _content.Add(rune, 1);
        }
        return true;
    }

    public void RemoveRune(RuneSO rune) {
        if (_content.TryGetValue(rune, out int currentAmount)) {
            _content[rune] = currentAmount - 1;
            if (_content[rune] == 0)
                _content.Remove(rune);
        } else {
            return;
        }
    }

    public void Clear() {
    }
    
    
    public void NotifyRuneChange(RuneSO rune, int newAmount)
    {
        rune.OnInventoryAmountChanged?.Invoke(newAmount);
    }
    
}

