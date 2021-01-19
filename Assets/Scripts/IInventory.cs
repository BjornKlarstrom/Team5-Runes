using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventory {

    public bool AddRune(RuneSO rune);
    public void RemoveRune(RuneSO rune);
}
