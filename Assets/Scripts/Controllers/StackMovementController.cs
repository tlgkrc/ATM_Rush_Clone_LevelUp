using System.Collections.Generic;
using DG.Tweening;
using Managers;
using UnityEngine;

namespace Controllers
{
    public class StackMovementController : MonoBehaviour
    {
        #region Self Variables
        
        #region Serialized Variables

        [SerializeField] private StackAnimationController animationController;
        [SerializeField] private StackPhysicsController physicsController;
        [SerializeField] private StackManager manager;

        #endregion

        #endregion
        
        

        public void LerpMoney(List<GameObject> stackMembers)
        {
            for (int i = 0; i <= stackMembers.Count -1 ; i++)
            {
                //change duration value with smaller 
                stackMembers[i].transform
                    .DOMoveX(i == 0 ? manager.transform.position.x : stackMembers[i - 1].transform.position.x, .2f);
                stackMembers.TrimExcess();
            }
        }
    }
}
