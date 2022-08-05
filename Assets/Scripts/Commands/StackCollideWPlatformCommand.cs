using System.Collections.Generic;
using Signals;
using UnityEngine;

namespace Commands
{
    public class StackCollideWPlatformCommand:MonoBehaviour
    {
        public void StackCollideWPlatform(GameObject gO, List<GameObject> stackList,GameObject collectables)
        {
            if (stackList.Count==0)
            {
                ScoreSignals.Instance.onSetLevelScore?.Invoke();
            }
            stackList.Remove(gO);
            stackList.TrimExcess();
            gO.transform.SetParent(collectables.transform);
        }
    }
}