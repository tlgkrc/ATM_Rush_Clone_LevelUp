using System;
using Cinemachine;
using Enums;
using Signals;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Managers
{
    public class CameraManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        public CinemachineVirtualCamera cmVirtualCamera;
        

        #endregion

        #region Private Variables

        [ShowInInspector] private Vector3 _initialPosition;
        private CameraTypes _cameraTypes = CameraTypes.InitializeCam;
        private Animator _camAnimator;

        #endregion

        #endregion

        private void Awake()
        {
            _camAnimator = GetComponent<Animator>();
            GetInitialPosition();
            SetCameraState(_cameraTypes);// send with signals,scriptable doesnt affect camera driven state
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

        private void SetCameraState(CameraTypes cameraTypes)
        {
            if (cameraTypes == CameraTypes.InitializeCam)
            {
                _camAnimator.Play("RunnerCam");
                cameraTypes = CameraTypes.RunnerCam;
            }
            else if(cameraTypes == CameraTypes.RunnerCam)
            {
                _camAnimator.Play("MiniGameCam");
                cameraTypes = CameraTypes.MiniGameCam;
            }
        }
    }
}