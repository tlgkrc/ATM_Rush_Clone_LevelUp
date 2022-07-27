using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Managers;
using UnityEngine;

namespace Controllers
{
    public class StackAnimationController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private StackManager manager;
        [SerializeField] private StackMovementController movementController;
        [SerializeField] private StackPhysicsController physicsController;

        #endregion

        #region Private Variables
        
        #endregion

        #endregion
        
        public IEnumerator MoneyScale(List<GameObject> newList) 
        {
            var increasedScale = Vector3.one*1.3f ;
            for (int i = 0 ; i <= newList.Count-1 ; i++)
            {
                var index = (newList.Count -1) - i;

                newList[index].transform.DOScale(increasedScale, 0.14f).SetEase(Ease.Flash); 
                newList[index].transform.DOScale(Vector3.one, .14f ).SetEase(Ease.Flash).SetDelay(.14f); 
                yield return new WaitForSeconds(0.3f);
            }
        }
    }
}