using System;
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
               tag = "Collected";
               IncreasePlayerScore(transform.parent.gameObject);
            }

            if (other.CompareTag("Obstacle"))
            {
                CollectableSignals.Instance.onTouchedObstacle?.Invoke(collectableManager.gameObject,other.transform.position);
                DecreasePlayerScore(transform.parent.gameObject);
            }

            if ( CompareTag("Collected"))
            {
                var meshGO = collectableMeshFilterController.GetComponent<MeshFilter>().sharedMesh.name;
                if (other.CompareTag("ATM"))
                {
                    IncreaseAtmScore(meshGO);
                    CollectableSignals.Instance.onTouchedATM?.Invoke(collectableManager.gameObject);
                }

                if (other.CompareTag("WalkingPlatform"))
                {
                    IncreaseAtmScore(meshGO);
                    CollectableSignals.Instance.onTouchedWalkingPlatform?.Invoke(collectableManager.gameObject);
                }
            }

            if (other.CompareTag("Collected") && CompareTag("Uncollected"))
            {
                CollectableSignals.Instance.onTouchedCollectedMoney?.Invoke(collectableManager.gameObject);
                tag = "Collected";
                IncreasePlayerScore(transform.parent.gameObject);
            }
        }

        private void IncreasePlayerScore(GameObject gO)
        {
            var state = gO.GetComponent<CollectableManager>().Data;
            if (state == CollectableTypes.Money)
            {
                ScoreSignals.Instance.onIncreasePlayerScore?.Invoke(1);
            }
            else if(state == CollectableTypes.Gold)
            {
                ScoreSignals.Instance.onIncreasePlayerScore?.Invoke((2));
            }
            else
            {
                ScoreSignals.Instance.onIncreasePlayerScore?.Invoke((2));
            }
        }

        private void DecreasePlayerScore(GameObject gO)
        {
            var state = gO.GetComponent<CollectableManager>().Data;
            if (state == CollectableTypes.Money)
            {
                ScoreSignals.Instance.onIncreasePlayerScore?.Invoke(-1);
            }
            else if(state == CollectableTypes.Gold)
            {
                ScoreSignals.Instance.onIncreasePlayerScore?.Invoke(-2);
            }
            else
            {
                ScoreSignals.Instance.onIncreasePlayerScore?.Invoke(-3);
            }
        }

        private void IncreaseAtmScore(String meshGO)
        {
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
    }
}