using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSaveData
{
    public int Version { get; protected set; }
    public abstract BaseSaveData VersionUp();
}

public class BaseSaveDataV1 : BaseSaveData
{    
    // Base Data To be Saved

    public BaseSaveDataV1()
    {
        Version = 1;
    }

    public override BaseSaveData VersionUp()
    {
        throw new System.NotImplementedException();
    }
}