using DG.Tweening;
using Managers;
using UnityEngine;

namespace Controllers
{
    public class MiniGamePhysicController : MonoBehaviour
    {
        #region Self Variables

        #endregion

        private void OnTriggerEnter(Collider other) 
        {
            if (other.CompareTag("Tower"))
            {
                var newPos = other.transform.localPosition.z;
                other.transform.DOLocalMoveZ(newPos - 6, .2f, false);
            }
            
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Tower"))
            {
                var newPos = other.transform.localPosition.z;
                other.transform.DOLocalMoveZ(newPos + 6 , .2f, false);
            }
            
        }
    }
}