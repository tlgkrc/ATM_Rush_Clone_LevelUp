using UnityEngine;
using Sirenix.OdinInspector;
using Managers;
using Data.ValueObject;

namespace Controllers
{
    public class StackPhysicsController : MonoBehaviour
    {
        // #region Self Variables
        //
        // #region Serialized Variables
        //
        // [SerializeField]private StackManager manager;
        //
        // #endregion
        //
        // #region Private Variables
        //
        // [Header("Data")]
        // [ShowInInspector]
        // private StackData _stackData;
        //
        // #endregion
        //
        // #endregion
        // private void OnTriggerEnter(Collider other)
        // {
        //     if (other.CompareTag("Uncollected"))
        //     {
        //         if (!_stackData.Inventory.Contains(other.gameObject))
        //         {
        //             other.GetComponent<BoxCollider>().isTrigger = false;
        //             other.gameObject.tag = "Collected";
        //             other.gameObject.GetComponent<StackPhysicsController>().enabled = true;
        //             other.gameObject.AddComponent<Rigidbody>();
        //             other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        //
        //             //.StackMoney(other.gameObject, _stackData.Inventory.Count - 1);
        //         }
        //     }
        // }
        //
        // public void SetStackPhysicsData(StackData data)
        // {
        //     _stackData = data;
        // }
    }
}

