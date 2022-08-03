using System.Collections.Generic;
using Controllers;
using UnityEngine;

namespace Commands
{
    public class AddToStackCommand:MonoBehaviour
    {
        public void CollectableAddToStack(List<GameObject> stackList,GameObject gO,StackAnimationController stackAnimationController)
        {
            stackList.Add(gO);
            gO.transform.SetParent(transform);
            if (stackList.Count ==1)
            {
                stackList[0].transform.localPosition = new Vector3(0,.5f,0);
                return;
            }
            for (int i = 1; i < stackList.Count; i++)
            {
                stackList[i].transform.localPosition =
                    stackList[i - 1].transform.localPosition + Vector3.forward;
            }
            stackAnimationController.StartCoroutine(stackAnimationController.MoneyScale(stackList));
        }
    }
}