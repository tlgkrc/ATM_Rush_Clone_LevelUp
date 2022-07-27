using Enums;
using Managers;
using Signals;
using UnityEngine;

namespace Controllers
{
    public class CollectablePhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private CollectableManager collectableManager;
        [SerializeField] private CollectableMeshFilterController collectableMeshFilterController;
        #endregion

        #region Private Variables
        
        #endregion

        #endregion
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Portal"))
            {
                CollectableSignals.Instance.onTouchedGate?.Invoke(collectableManager.gameObject.GetInstanceID());
            }

            if (other.CompareTag("Player") && !CompareTag("Collected"))
            {
               CollectableSignals.Instance.onTouchedPlayer?.Invoke(collectableManager.gameObject);
               ScoreSignals.Instance.onIncreasePlayerScore?.Invoke();
            }

            if (other.CompareTag("Obstacle"))
            {
                CollectableSignals.Instance.onTouchedObstacle?.Invoke(collectableManager.gameObject,other.transform.position);
            }

            if (other.CompareTag("ATM"))
            {
                var meshGO = transform.parent.transform.GetChild(0).transform.GetComponent<MeshFilter>().sharedMesh.name;
                if (meshGO == "Money" )
                {
                    ScoreSignals.Instance.onIncreaseATMScore?.Invoke(1);
                }
                else if(meshGO == "gold")
                {
                    ScoreSignals.Instance.onIncreaseATMScore?.Invoke(2);
                }
                else
                {
                    ScoreSignals.Instance.onIncreaseATMScore?.Invoke(3);
                }
            }

            if (other.CompareTag("Collected") && CompareTag("Uncollected"))
            {
                CollectableSignals.Instance.onTouchedCollectedMoney?.Invoke(collectableManager.gameObject);
                ScoreSignals.Instance.onIncreasePlayerScore?.Invoke();
            }
        }
    }
}