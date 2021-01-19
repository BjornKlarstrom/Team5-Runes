using System.Collections.Generic;

public class PlayerInventory {
    public PlayerInventory() {
        _content = new Dictionary<RuneSO, int>();
    }
    // Notify view of update to model.
    // keep track of number of cards of each type list, dict, 

    // lookup tables

    private Dictionary<RuneSO, int> _content;

    public Dictionary<RuneSO, int> Content => _content;
    //public RuneSO theRune; //temporary

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

    // TODO Notify view of update to model. (Event)
}