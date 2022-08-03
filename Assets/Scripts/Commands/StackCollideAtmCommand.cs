using System.Collections.Generic;
using UnityEngine;

namespace Commands
{
    public class StackCollideAtmCommand : MonoBehaviour
    {
        public void StackCollideWithAtm(GameObject gO ,List<GameObject> stackList)
        {
            Destroy(gO);
            stackList.Remove(gO);
            stackList.TrimExcess();
        }
    }
}