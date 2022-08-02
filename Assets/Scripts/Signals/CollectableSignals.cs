using Enums;
using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class CollectableSignals : MonoSingleton<CollectableSignals>
    {
        public UnityAction<GameObject> onAddStackList = delegate {  };
        public UnityAction<GameObject> onTouchedGate = delegate {  };
        public UnityAction<GameObject> onTouchedCollectedMoney = delegate {  };
        public UnityAction<GameObject,Vector3> onTouchedObstacle = delegate { };
        public UnityAction<GameObject> onTouchedWalkingPlatform = delegate {  };
        public UnityAction<GameObject> onTouchedATM = delegate {  };
    }
}