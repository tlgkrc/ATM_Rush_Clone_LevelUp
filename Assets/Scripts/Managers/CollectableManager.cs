using System;
using Controllers;
using Data.UnityObject;
using Enums;
using Signals;
using UnityEngine;

namespace Managers
{
    public class CollectableManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        [Header("Data")] public CollectableTypes Data;
        
        #endregion

        #region Serialized Variables
        
        [SerializeField] private CollectableMeshFilterController meshFilterController;
        [SerializeField] private CollectablePhysicsController physicsController;
        [SerializeField] private CollectableAnimationController animationController;

        #endregion

        #region Private Variables

        #endregion

        #endregion

        private void Awake()
        {
            Data = GetCollectableData();
        }

        private void Start()
        {
            meshFilterController.SetDefaultMesh();
        }

        private CollectableTypes  GetCollectableData()
        {
            return Resources.Load<CD_Collectable>("Data/CD_Collectable").collectableData.collectableTypes;
        }

        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CollectableSignals.Instance.onTouchedGate += OnTouchGate;
            CollectableSignals.Instance.onTouchedWalkingPlatform += OnTouchedWalkingPlatform;
        }

        private void UnsubscribeEvents()
        {
            CollectableSignals.Instance.onTouchedGate -= OnTouchGate;
            CollectableSignals.Instance.onTouchedWalkingPlatform -= OnTouchedWalkingPlatform;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion

        private void OnTouchGate(int instanceId)
        {
            meshFilterController.UpdateMeshFilterCollectable(Data,instanceId);
        }

        private void OnTouchedWalkingPlatform(GameObject gO)
        {
            animationController.StartWalkingPlatformAnim(gO);
        }
    }
}