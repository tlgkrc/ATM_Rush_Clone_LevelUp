using Enums;
using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class CollectableSignals : MonoSingleton<CollectableSignals>
    {
        public UnityAction<GameObject> onTouchedPlayer = delegate {  };
        public UnityAction<int> onTouchedGate = delegate {  };
        public UnityAction<GameObject> onTouchedCollectedMoney = delegate {  };
        public UnityAction<GameObject,Vector3> onTouchedObstacle = delegate { };
        public UnityAction<GameObject> onTouchedWalkingPlatform = delegate {  };
        public UnityAction<GameObject> onTouchedATM = delegate {  };
    }
}