using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class MiniGameSignals : MonoSingleton<MiniGameSignals>
    {
        public UnityAction<int> onSetLevelScoreToMiniGame = delegate {  };
        public UnityAction onStartMiniGame =delegate {  };
        public UnityAction<GameObject> onSetCameraTargetFakePlayer = delegate {  };

    }
}