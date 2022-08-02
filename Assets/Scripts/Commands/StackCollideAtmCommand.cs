using System.Collections.Generic;
using UnityEngine;

namespace Commands
{
    public class StackCollideAtmCommand : MonoBehaviour
    {
        public void CollideWithAtm(GameObject gO ,List<GameObject> stackList)
        {
            Destroy(gO);
            stackList.Remove(gO);
            stackList.TrimExcess();
            if (stackList.Count>=1)
            {
                if (stackList.Count ==0)
                {
                    stackList[0].transform.localPosition = Vector3.zero;
                }
                for (int i = 1; i <= stackList.Count - 1; i++)
                {
                    stackList[i].transform.localPosition =
                        stackList[i - 1].transform.localPosition + Vector3.forward;
                }
            }
        }
    }
}