using Enums;
using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class ScoreSignals : MonoSingleton<ScoreSignals>
    {
        public UnityAction<int> onIncreasePlayerScore = delegate {  };
        public UnityAction<int> onDecreasePlayerScore = delegate {  };
        public UnityAction<int> onIncreaseATMScore = delegate {  };
        public UnityAction onSetLevelScore = delegate {  };
    }
}