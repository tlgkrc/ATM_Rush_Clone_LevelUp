using System;
using Extentions;
using Keys;
using UnityEngine.Events;

namespace Signals
{
    public class CoreGameSignals : MonoSingleton<CoreGameSignals>
    {
    
        public UnityAction<SaveGameDataParams> onSaveGame = delegate{  };
        public UnityAction onLevelInitialize = delegate { };
        public UnityAction onClearActiveLevel = delegate { };
        public UnityAction onLevelSuccessful = delegate { };
        public UnityAction onNextLevel = delegate { };
        public UnityAction onRestartLevel = delegate { };
        public UnityAction onPlay = delegate { };
        public UnityAction onReset = delegate { };
        public UnityAction onFinishLineReached = delegate {  };

        public UnityAction onSetCameraTarget = delegate { };

        public Func<int> onGetLevelID = delegate { return 0; };

    }
    
}