using System.Collections.Generic;
using Commands;
using UnityEngine;
using Controllers;
using Signals;
using Sirenix.OdinInspector;

namespace Managers
{
    public class StackManager : MonoBehaviour
    {

        #region Self Variables

        #region SerializeField Variables

        [Space][SerializeField] private StackMovementController stackMovementController;
        [SerializeField] private StackAnimationController stackAnimationController;
        
        [SerializeField] private StackCollideWPlatformCommand stackCollideWPlatformCommand;
        [SerializeField] private StackCollideAtmCommand stackCollideAtmCommand;
        [SerializeField] private StackCollideObstacleCommand stackCollideObstacleCommand;
        [SerializeField] private AddToStackCommand addToStackCommand;

        #endregion

        #region Private Variables

        [ShowInInspector] private List<GameObject> _stackMembers = new List<GameObject>();
        private GameObject _collectables;

        #endregion

        #endregion

        private void Awake()
        {
            _collectables = GameObject.Find("Collectables");
        }

        #region Subscribe Events

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CollectableSignals.Instance.onAddStackList += OnTakeCollectableToStack;
            CollectableSignals.Instance.onCollideObstacle += OnTouchedObstacle;
            CollectableSignals.Instance.onCollideATM += OnCollideATM;
            CollectableSignals.Instance.onCollideWalkingPlatform += OnCollideWalkingPlatform;
        }

        private void UnsubscribeEvents()
        {
            CollectableSignals.Instance.onAddStackList -= OnTakeCollectableToStack;
            CollectableSignals.Instance.onCollideObstacle -= OnTouchedObstacle;
            CollectableSignals.Instance.onCollideATM -= OnCollideATM;
            CollectableSignals.Instance.onCollideWalkingPlatform -= OnCollideWalkingPlatform;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        
        #endregion

        private void Update()
        {
            stackMovementController.Lerp(_stackMembers);   
        }

        private void OnTakeCollectableToStack(GameObject _gO)
        {
            addToStackCommand.CollectableAddToStack(_stackMembers,_gO,stackAnimationController);
        }

        private void OnTouchedObstacle(GameObject gO,Vector3 obsPos)
        {
            stackCollideObstacleCommand.StackCollideWithObstacle(gO,obsPos,_stackMembers,_collectables);
        }

        private void OnCollideATM(GameObject gO)
        {
            stackCollideAtmCommand.StackCollideWithAtm(gO,_stackMembers);
        }

        private void OnCollideWalkingPlatform(GameObject gO)
        { 
            stackCollideWPlatformCommand.StackCollideWPlatform(gO,_stackMembers);
        }
    }
}