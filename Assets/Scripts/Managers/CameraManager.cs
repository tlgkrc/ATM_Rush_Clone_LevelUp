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

        public CinemachineStateDrivenCamera cmStateDrivenCamera;
        

        #endregion

        #region Private Variables

        // [ShowInInspector] private Vector3 _initialPosition;
        // private CameraTypes _cameraTypes = CameraTypes.InitializeCam;
        // private Animator _camAnimator;
        private GameObject pGameObject;

        #endregion

        #endregion

        private void Awake()
        {
            pGameObject = GameObject.Find("PlayerManager");
            // SetCameraTarget();
            // _camAnimator = GetComponent<Animator>();
            // GetInitialPosition();
            // SetCameraState(CameraTypes.InitializeCam);// send with signals,scriptable doesnt affect camera driven state
        }

        private void Start()
        {
            //SetPlayerAnimator();
        }
        //
        // #region Event Subscription
        //
        // private void OnEnable()
        // {
        //     SubscribeEvents();
        // }
        //
        // private void SubscribeEvents()
        // {
        //     CoreGameSignals.Instance.onPlay += OnPlay;
        //     CoreGameSignals.Instance.onSetCameraTarget += OnSetCameraTarget;
        //     CoreGameSignals.Instance.onReset += OnReset;
        // }
        //
        // private void UnsubscribeEvents()
        // {
        //     CoreGameSignals.Instance.onPlay -= OnPlay;
        //     CoreGameSignals.Instance.onSetCameraTarget -= OnSetCameraTarget;
        //     CoreGameSignals.Instance.onReset -= OnReset;
        // }
        //
        // private void OnDisable()
        // {
        //     UnsubscribeEvents();
        // }
        //
        // #endregion
        //
        // private void GetInitialPosition()
        // {
        //     _initialPosition = transform.localPosition;
        // }
        //
        // private void OnMoveToInitialPosition()
        // {
        //     transform.localPosition = _initialPosition;
        // }
        //
        //
        // private void OnSetCameraTarget()
        // {       
        //     SetCameraTarget();
        // }
        //
        // private void OnReset()
        // {
        //     cmStateDrivenCamera.LookAt = null;
        //     cmStateDrivenCamera.Follow = null;
        //     OnMoveToInitialPosition();
        //     SetCameraState(CameraTypes.InitializeCam);
        // }
        //
        // private void OnPlay()
        // {
        //     SetCameraState(CameraTypes.RunnerCam);
        // }
        //
        // private void SetCameraState(CameraTypes cameraTypes)
        // {
        //     if (cameraTypes == CameraTypes.InitializeCam)
        //     {
        //         _camAnimator.Play("InitializeCam");
        //         cameraTypes = CameraTypes.InitializeCam;
        //     }
        //     else if(cameraTypes == CameraTypes.RunnerCam)
        //     {
        //         _camAnimator.Play("RunnerCam");
        //         cameraTypes = CameraTypes.RunnerCam;
        //     }
        //     else
        //     {
        //         _camAnimator.Play("MiniGameCam");
        //         cameraTypes = CameraTypes.MiniGameCam;
        //     }
        // }
        //
        // private void SetCameraTarget()
        // {
        //     var playerManager = FindObjectOfType<PlayerManager>().transform;
        //     cmStateDrivenCamera.Follow = playerManager;
        // }

        // private void SetPlayerAnimator()
        // {
        //     var pAnimator = pGameObject.GetComponentInChildren<Animator>();
        // }

        
    }
}