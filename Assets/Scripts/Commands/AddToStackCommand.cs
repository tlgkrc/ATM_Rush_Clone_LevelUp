using System.Collections.Generic;
using Controllers;
using UnityEngine;

namespace Commands
{
    public class AddToStackCommand:MonoBehaviour
    {
        public void CollectableAddToStack(List<GameObject> _stackList,GameObject _gO,StackAnimationController _stackAnimationController)
        {
            _stackList.Add(_gO);
            _gO.transform.SetParent(_stackAnimationController.transform);
            if (_stackList.Count ==0)
            {
                _stackList[0].transform.localPosition = Vector3.zero;
            }
            for (int i = 1; i <= _stackList.Count - 1; i++)
            {
                _stackList[i].transform.localPosition =
                    _stackList[i - 1].transform.localPosition + Vector3.forward;
            }
            _stackAnimationController.StartCoroutine(_stackAnimationController.MoneyScale(_stackList));
        }
    }
}