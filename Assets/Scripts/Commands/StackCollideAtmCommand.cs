using System.Collections.Generic;
using UnityEngine;

namespace Commands
{
    public class StackCollideAtmCommand : MonoBehaviour
    {
        public void StackCollideWithAtm(GameObject gO ,List<GameObject> stackList)
        {
            stackList.Remove(gO);
            stackList.TrimExcess();
            Destroy(gO);
            for (int i = 1; i <= stackList.Count - 1; i++)
            {
                stackList[i].transform.localPosition =
                    stackList[i - 1].transform.localPosition + Vector3.forward;
            }
        }
    }
}