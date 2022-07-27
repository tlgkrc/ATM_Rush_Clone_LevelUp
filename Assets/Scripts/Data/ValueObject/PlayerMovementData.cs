using System;

namespace Data.ValueObject
{
    [Serializable]
    public class PlayerMovementData
    {
        public float ForwardSpeed = 5f;
        public float SidewaysSpeed = 2.5f;
        public float ForwardForceSpeed = 10;
    }
}