using System;
using Enums;

namespace Data.ValueObject
{
    [Serializable]
    public class CollectableData
    {
        public CollectableTypes collectableTypes = CollectableTypes.Money;
        public CollectableMeshData collectableMeshData;
    } 
}