using System.Collections.Generic;

public class MergeInventory
{
    public MergeInventory(int capacity = 4)
    {
        _content = new Dictionary<RuneSO, int>();
        _capacity = capacity;
    }
    private Dictionary<RuneSO, int> _content;
    public Dictionary<RuneSO, int> Content => _content;
    
    private int _capacity = 1;
    private int _currentAmount = 0;

    public int Capacity => _capacity;
    public int CurrentAmount => _currentAmount;

    public bool AddRune(RuneSO rune)
    {
        if (_currentAmount >= _capacity)
            return false;
            
        if (_content.TryGetValue(rune, out int currentAmount))
        {
            _content[rune] = currentAmount + 1;
        }
        else
        {
            _content.Add(rune, 1);
        }
        return true;
    }

    public void RemoveRune(RuneSO rune)
    {
        
    }
    
    // TODO Notify view of update to model. (Event)
    // interface remove this rune 
}
