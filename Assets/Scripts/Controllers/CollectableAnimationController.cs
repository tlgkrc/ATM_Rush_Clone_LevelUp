using DG.Tweening;
using Managers;
using UnityEngine;

namespace Controllers
{
    public class CollectableAnimationController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private CollectablePhysicsController physicsController;
        [SerializeField] private CollectableManager manager;

        #endregion

        #endregion

        public void StartWalkingPlatformAnim(GameObject _gO)
        {
            _gO.transform.DOLocalMoveX(-15, 1, false).SetEase(Ease.Linear);
        }
    }
}