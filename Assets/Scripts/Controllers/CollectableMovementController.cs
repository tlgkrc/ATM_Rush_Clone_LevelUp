using DG.Tweening;
using Managers;
using UnityEngine;

namespace Controllers
{
    public class CollectableMovementController : MonoBehaviour
    {
        #region Self Region

        #region Serialized Region

        [SerializeField] private CollectableManager collectableManager;

        #endregion

        #endregion
        public void MoveOnWalkingPlatform(GameObject gO)
        {
            gO.transform.SetParent(null);
            var goPos = gO.transform.position;
            gO.transform.DOJump(new Vector3(goPos.x, goPos.y + .5f, goPos.z + 2f), 0f, 0,.1f);
            gO.transform.DOMoveX(-10f, 1.1f,false).SetEase(Ease.Linear).SetDelay(.05f);
        }
    }
}