using Enums;
using Extentions;
using UnityEngine.Events;

namespace Signals
{
    public class UISignals : MonoSingleton<UISignals>
    {
        public UnityAction<UIPanels> onOpenPanel = delegate {  };
        public UnityAction<UIPanels> onClosePanel = delegate {  };
        public UnityAction onChangeLevelText = delegate {  };
        public UnityAction<int> onChangeMoneyText = delegate {  };

    }
}