using System;
using DG.Tweening;
using Managers;
using UnityEngine;

namespace Controllers
{
    public class MiniGamePhysicController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private MiniGameManager manager;

        #endregion

        #endregion

        private void OnTriggerEnter(Collider other) //!!!!check with tag
        {
            var newPos = other.transform.localPosition.z;
            other.transform.DOLocalMoveZ(newPos - 6, .2f, false);
        }

        private void OnTriggerExit(Collider other)
        {
            var newPos = other.transform.localPosition.z;
            other.transform.DOLocalMoveZ(newPos + 6 , .2f, false);
        }
    }
}