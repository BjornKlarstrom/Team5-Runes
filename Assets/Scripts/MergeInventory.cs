using System.Collections.Generic;

public class MergeInventory
{
    private Dictionary<RuneSO, int> _content;
    
    private RuneSO theRune; //temporary
    
    private int _capacity = 0;
    private int _currentAmount = 0;
    
    
    public bool TryToAddRune(RuneSO rune)
    {
        if (_currentAmount >= _capacity)
            return false;
            
        if (_content.TryGetValue(theRune, out int currentAmount))
        {
            _content[theRune] = currentAmount + 1;
        }
        else
        {
            _content.Add(theRune, 1);
        }
        return true;
    }

    public void RemoveRune(RuneSO rune)
    {

    }
    
}
