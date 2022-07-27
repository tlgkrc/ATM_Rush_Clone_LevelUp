using System;
using Cinemachine;
using Signals;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Managers
{
    public class CameraManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private CinemachineVirtualCamera cmVirtualCamera;

        #endregion

        #region Private Variables

        [ShowInInspector] private Vector3 _initialPosition;

        #endregion

        #endregion

        private void Awake()
        {
            cmVirtualCamera = GetComponent<CinemachineVirtualCamera>();
            GetInitialPosition();
        }

        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay += SetCameraTarget;
            CoreGameSignals.Instance.onSetCameraTarget += OnSetCameraTarget;
            CoreGameSignals.Instance.onReset += OnReset;
        }

        private void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay -= SetCameraTarget;
            CoreGameSignals.Instance.onSetCameraTarget -= OnSetCameraTarget;
            CoreGameSignals.Instance.onReset -= OnReset;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion

        private void GetInitialPosition()
        {
            _initialPosition = transform.localPosition;
        }

        private void OnMoveToInitialPosition()
        {
            transform.localPosition = _initialPosition;
        }

        private void SetCameraTarget()
        {
            CoreGameSignals.Instance.onSetCameraTarget?.Invoke();
        }

        private void OnSetCameraTarget()
        {       
            var playerManager = FindObjectOfType<PlayerManager>().transform;
            cmVirtualCamera.Follow = playerManager;
        }

        private void OnReset()
        {
            cmVirtualCamera.LookAt = null;
            cmVirtualCamera.Follow = null;
            OnMoveToInitialPosition();
        }
    }
}