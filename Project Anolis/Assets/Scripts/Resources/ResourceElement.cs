using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceElement
{
    public ushort ID;
    public short amount;
        
    public ResourceElement(ushort _ID, short _amount)
    {
        ID = _ID;
        amount = _amount;
    }
}