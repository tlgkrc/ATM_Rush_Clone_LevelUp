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
        public UnityAction<int> onTouchedObstacle = delegate { };
        public UnityAction<int,Vector3> onUpdatePosition = delegate {  };
    }
}