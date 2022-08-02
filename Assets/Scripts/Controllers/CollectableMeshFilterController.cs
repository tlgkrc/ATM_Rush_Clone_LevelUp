using System.Collections.Generic;
using Enums;
using Managers;
using Signals;
using UnityEngine;

namespace Controllers
{
    public class CollectableMeshFilterController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables
            
        [SerializeField] private CollectableManager collectableManager;
        [SerializeField] private List<MeshFilter> meshFilters = new List<MeshFilter>();

        #endregion

        #endregion
        

        public void UpdateMeshFilterCollectable(CollectableTypes colTypes,GameObject _gO)
        {
            if (collectableManager.gameObject == _gO)
            {
                if (colTypes == CollectableTypes.Money)
                {
                    collectableManager.Data = CollectableTypes.Gold;
                    gameObject.GetComponent<MeshFilter>().sharedMesh = meshFilters[1].sharedMesh;
                }
                else if (colTypes == CollectableTypes.Gold)
                {
                    collectableManager.Data = CollectableTypes.Diamond;
                    gameObject.GetComponent<MeshFilter>().sharedMesh = meshFilters[2].sharedMesh;
                }
                ScoreSignals.Instance.onIncreasePlayerScore?.Invoke(1);
            }
        }

        public void SetDefaultMesh()
        {
            this.GetComponent<MeshFilter>().sharedMesh = meshFilters[0].sharedMesh;
        }
    }
}