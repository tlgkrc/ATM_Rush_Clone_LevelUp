using Enums;
using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class ScoreSignals : MonoSingleton<ScoreSignals>
    {
        public UnityAction onIncreasePlayerScore = delegate {  };
        public UnityAction onDecreasePlayerScore = delegate {  };
        public UnityAction<int> onIncreaseATMScore = delegate {  };
    }
}