using System;

namespace Data.ValueObject
{
    [Serializable]
    public class PlayerData
    {
        public PlayerMovementData MovementData;
        public PlayerPullBackForceData PullBackForceData;
    }
}