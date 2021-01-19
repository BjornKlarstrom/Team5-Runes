using System.Collections.Generic;

public class MergeInventory {
    public MergeInventory(int capacity = 4) {
        _content = new Dictionary<RuneSO, int>();
        _capacity = capacity;
    }

    private Dictionary<RuneSO, int> _content;
    public Dictionary<RuneSO, int> Content => _content;

    private int _capacity = 1;
    private int _currentAmount = 0;

    public int Capacity => _capacity;
    public int CurrentAmount => _currentAmount;

    public bool AddRune(RuneSO rune) {
        if (_currentAmount >= _capacity)
            return false;

        if (_content.TryGetValue(rune, out int currentAmount)) {
            _content[rune] = currentAmount + 1;
            _currentAmount++;
        } else {
            _content.Add(rune, 1);
            _currentAmount++;
        }

        return true;
    }
    
    public void RemoveRune(RuneSO rune)
    {
        
    }

    public void NotifyRuneChange(RuneSO rune)
    {
        rune.OnRuneMerged?.Invoke();
    }
    
    public void Clear()
    {
        
    }

    public void RemoveRune(RuneSO rune) {
        if (_content.TryGetValue(rune, out int currentAmount)) {
            _content[rune] = currentAmount - 1;
            _currentAmount--;
            if (_content[rune] == 0)
                _content.Remove(rune);
        } else {
            return;
        }
    }

}

