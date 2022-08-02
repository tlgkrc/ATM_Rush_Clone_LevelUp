using Enums;
using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class CollectableSignals : MonoSingleton<CollectableSignals>
    {
        public UnityAction<GameObject> onAddStackList = delegate {  };
        public UnityAction<GameObject> onCollideGate = delegate {  };
        public UnityAction<GameObject,Vector3> onCollideObstacle = delegate { };
        public UnityAction<GameObject> onCollideWalkingPlatform = delegate {  };
        public UnityAction<GameObject> onCollideATM = delegate {  };
    }
}