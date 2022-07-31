using System.Collections.Generic;
using UnityEngine;
using Controllers;
using DG.Tweening;
using Signals;
using Sirenix.OdinInspector;
using TMPro;

namespace Managers
{
    public class StackManager : MonoBehaviour
    {

        #region Self Variables

        #region Public Variables

        #endregion

        #region SerializeField Variables

        [Space][SerializeField] private StackMovementController stackMovementController;
        [SerializeField] private StackPhysicsController stackPhysicsController;
        [SerializeField] private StackAnimationController stackAnimationController;
        [SerializeField] private TextMeshPro playerStackText;
        [SerializeField] private PlayerManager playerManager;

        #endregion

        #region Private Variables

        [ShowInInspector] private List<GameObject> _stackMembers = new List<GameObject>();
        private GameObject _collectables;
        private bool _isSeperatedFromPlayer = false;

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
            CollectableSignals.Instance.onTouchedPlayer += OnTakeCollectableToStack;
            // ScoreSignals.Instance.onIncreasePlayerScore += OnIncreasePlayerScore;
            // ScoreSignals.Instance.onDecreasePlayerScore += OnDecreasePlayerScore;
            CollectableSignals.Instance.onTouchedCollectedMoney += OnTouchedCollectedMoney;
            CollectableSignals.Instance.onTouchedObstacle += OnTouchedObstacle;
            CollectableSignals.Instance.onTouchedATM += OnTouchedATM;
            CollectableSignals.Instance.onTouchedWalkingPlatform += OnTouchedWalkingPlatform;
        }

        private void UnsubscribeEvents()
        {
            CollectableSignals.Instance.onTouchedPlayer -= OnTakeCollectableToStack;
            // ScoreSignals.Instance.onIncreasePlayerScore -= OnIncreasePlayerScore;
            // ScoreSignals.Instance.onDecreasePlayerScore += OnDecreasePlayerScore;
            CollectableSignals.Instance.onTouchedCollectedMoney -= OnTouchedCollectedMoney;
            CollectableSignals.Instance.onTouchedObstacle -= OnTouchedObstacle;
            CollectableSignals.Instance.onTouchedATM -= OnTouchedATM;
            CollectableSignals.Instance.onTouchedWalkingPlatform -= OnTouchedWalkingPlatform;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        
        #endregion

        private void Update()
        {
            stackMovementController.LerpMoney(_stackMembers);
        }

        private void OnTakeCollectableToStack(GameObject _gO)
        {
            StackMoney(_gO);
            RefreshStackList();
        }
        
        private void StackMoney(GameObject gO)
        {
            _stackMembers.Add(gO);
            gO.transform.SetParent(transform); 
            gO.GetComponentInChildren<Collider>().tag = "Collected";
            RefreshStackList();
            StartCoroutine(stackAnimationController.MoneyScale(_stackMembers));
        }

        private void RefreshStackList()
        {
            if (_stackMembers.Count ==0)
            {
                _stackMembers[0].transform.localPosition = Vector3.zero;
            }
            for (int i = 1; i <= _stackMembers.Count - 1; i++)
            {
                _stackMembers[i].transform.localPosition =
                    _stackMembers[i - 1].transform.localPosition + Vector3.forward;
            }
        }

        // private void OnIncreasePlayerScore()
        // {
        //     playerStackText.text = _stackMembers.Count.ToString();
        // }
        //
        // private void OnDecreasePlayerScore()
        // {
        //     playerStackText.text = _stackMembers.Count.ToString();
        // }

        private void OnTouchedCollectedMoney(GameObject gO)
        {
            StackMoney(gO);
        }

        private void OnTouchedObstacle(GameObject gO,Vector3 obsPos)
        {
            var siblingIndex = gO.transform.GetSiblingIndex();
            Destroy(gO);
            _stackMembers.Remove(gO);
            _stackMembers.TrimExcess();
            RefreshStackList();
            UpdateTailCondition(siblingIndex,obsPos);
            // ScoreSignals.Instance.onDecreasePlayerScore?.Invoke();
        }

        private void UpdateTailCondition(int siblingIndex,Vector3 obstaclePos)
        {
            for (int i = siblingIndex ; i < _stackMembers.Count-1; i++)
            {
                var newPos = new Vector3(Random.Range(-5f, 5f), 0.5f, obstaclePos.z + Random.Range(5f, 20f));
                
                _stackMembers[i].transform.GetChild(1).tag = "Uncollected";
                _stackMembers[i].transform.GetChild(1).GetComponent<Rigidbody>().isKinematic = true; 
                _stackMembers[i].transform.SetParent(_collectables.transform);
                _stackMembers[i].transform.DOJump(newPos, 2f, 1, .2f, false);
                _stackMembers.RemoveAt(i);
                _stackMembers.TrimExcess();
                // ScoreSignals.Instance.onDecreasePlayerScore?.Invoke();
            }
        }

        private void OnTouchedATM(GameObject gO)
        {
            var siblingIndex = gO.transform.GetSiblingIndex();
            Destroy(gO);
            _stackMembers.Remove(gO);
            _stackMembers.TrimExcess();
            if (_stackMembers.Count>=1)
            {
                RefreshStackList();
            }
        }

        private void OnTouchedWalkingPlatform(GameObject gO)
        {
            _stackMembers.Remove(gO);
            _stackMembers.TrimExcess();
            if (_stackMembers.Count==0)
            {
                ScoreSignals.Instance.onSetLevelScore?.Invoke();
            }
        }
    }
}
