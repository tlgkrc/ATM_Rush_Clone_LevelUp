using System;
using System.Collections.Generic;
using UnityEngine;

namespace Data.ValueObject
{
    [Serializable]
    public class StackData
    {
        //delete all
        public float MoneyMovementDelay = 0.3f;
        public List<GameObject> Inventory = new List<GameObject>();
    }
}

