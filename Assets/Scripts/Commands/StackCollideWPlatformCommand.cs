using System.Collections.Generic;
using Signals;
using UnityEngine;

namespace Commands
{
    public class StackCollideWPlatformCommand:MonoBehaviour
    {
        public void StackCollideWPlatform(GameObject gO, List<GameObject> stackList)
        {
            stackList.Remove(gO);
            stackList.TrimExcess();
            if (stackList.Count==0)
            {
                ScoreSignals.Instance.onSetLevelScore?.Invoke();
            }
        }
    }
}