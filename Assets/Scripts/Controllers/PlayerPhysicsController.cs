using Data.ValueObject;
using DG.Tweening;
using Managers;
using Signals;
using UnityEngine;


namespace Controllers
{
    public class PlayerPhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables
        
        [SerializeField] private PlayerManager playerManager;

        #endregion

        #region Private Variables
        
        private PlayerPullBackForceData _playerPullBackForceData;

        #endregion

        #endregion
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Obstacle"))
            {
                PlayerPullBackForce();
            }

            if (other.CompareTag("WalkingPlatform"))
            {
                CoreGameSignals.Instance.onFinishLineReached?.Invoke();

                MiniGameSignals.Instance.onStartMiniGame?.Invoke();
            }

            if (other.CompareTag("ATM"))
            {
                other.transform.parent.transform.DOMoveY(-10, .3f, false);
            }
        }
        public void SetPhysicsData(PlayerPullBackForceData forceData)
        {
            _playerPullBackForceData = forceData;
        }
        private void PlayerPullBackForce()
        {
            playerManager.GetComponent<Rigidbody>().AddForce(0,0,-_playerPullBackForceData.PullBackForce,ForceMode.Impulse);
        }
        
    }
}