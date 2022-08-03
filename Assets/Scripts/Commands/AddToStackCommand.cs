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
            gO.transform.SetParent(stackAnimationController.transform);
            if (stackList.Count ==0)
            {
                stackList[0].transform.localPosition = Vector3.zero;
            }
            for (int i = 1; i <= stackList.Count - 1; i++)
            {
                stackList[i].transform.localPosition =
                    stackList[i - 1].transform.localPosition + Vector3.forward;
            }
            stackAnimationController.StartCoroutine(stackAnimationController.MoneyScale(stackList));
        }
    }
}