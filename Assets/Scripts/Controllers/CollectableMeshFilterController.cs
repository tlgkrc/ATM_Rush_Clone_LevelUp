using System.Collections.Generic;
using Enums;
using Managers;
using UnityEngine;

namespace Controllers
{
    public class CollectableMeshFilterController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        #endregion

        #region Serialized Variables
            
        [SerializeField] private CollectableManager collectableManager;
        [SerializeField] private CollectablePhysicsController collectablePhysicsController;
        [SerializeField] private List<MeshFilter> meshFilters = new List<MeshFilter>();

        #endregion

        #region Private Variables

        #endregion

        #endregion
        

        public void UpdateMeshFilterCollectable(CollectableTypes colTypes,int id)
        {
            if (transform.parent.gameObject.GetInstanceID() == id)
            {
                int indexOfMesh =(int)colTypes;
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
            }
        }

        public void SetDefaultMesh()
        {
            this.GetComponent<MeshFilter>().sharedMesh = meshFilters[0].sharedMesh;
        }
    }
}