using Managers;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Controllers
{
    public class PlayerAnimationController : MonoBehaviour
    {
        #region Self Variables
        
        #region Serialized Variables
        
        [SerializeField] private Animator playAnimator;

        #endregion

        #endregion  

        public void ActivatePlayerAnim(bool isMoving)
        {
            playAnimator.SetBool("isMoving" ,isMoving);
        }

        public void MiniGamePlayerAnim(bool isFinishedPath)
        {
            playAnimator.SetBool("isFinishedPath" ,isFinishedPath);
        }
    }
}