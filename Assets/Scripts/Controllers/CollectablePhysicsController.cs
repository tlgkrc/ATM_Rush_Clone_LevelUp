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
                CollectableSignals.Instance.onTouchedGate?.Invoke(transform.parent.gameObject.GetInstanceID());
            }

            if (other.CompareTag("Player") && !CompareTag("Collected"))
            {
               CollectableSignals.Instance.onTouchedPlayer?.Invoke(transform.parent.gameObject);
               ScoreSignals.Instance.onIncreasePlayerScore?.Invoke();
            }

            if (other.CompareTag("Obstacle"))
            {
                var index = transform.parent.GetSiblingIndex();
                CollectableSignals.Instance.onTouchedObstacle?.Invoke(index);
                CollectableSignals.Instance.onUpdatePosition?.Invoke(index,other.transform.position);
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
                CollectableSignals.Instance.onTouchedCollectedMoney?.Invoke(transform.parent.gameObject);
            }
        }
    }
}