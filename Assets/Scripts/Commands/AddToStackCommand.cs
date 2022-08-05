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

            for (int i = 0; i < stackList.Count; i++)
            {
                
                if (i == 0)
                {
                    stackList[0].transform.localPosition = new Vector3(0,.8f,0);
                }
                else
                {
                    stackList[i].transform.localPosition = 
                        stackList[i - 1].transform.localPosition + Vector3.forward;
                }
            }
            
            stackAnimationController.StartCoroutine(stackAnimationController.MoneyScale(stackList));
        }
    }
}