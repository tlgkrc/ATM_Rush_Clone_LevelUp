using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Controllers
{
    public class StackAnimationController : MonoBehaviour
    {

        public IEnumerator MoneyScale(List<GameObject> newList) 
        {
            var increasedScale = Vector3.one*1.7f ;
            for (int i = 0 ; i <= newList.Count-1 ; i++)
            {
                var index = (newList.Count -1) - i;

                newList[index].transform.DOScale(increasedScale, 0.1f).SetEase(Ease.Flash); 
                newList[index].transform.DOScale(Vector3.one*1.2f, .1f ).SetEase(Ease.Flash).SetDelay(.1f); 
                yield return new WaitForSeconds(0.05f);
            }
        }
    }
}