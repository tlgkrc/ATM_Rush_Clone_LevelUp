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
        private Tween _tween;

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
            ScoreSignals.Instance.onIncreasePlayerScore += OnIncreasePlayerScore;
            CollectableSignals.Instance.onTouchedCollectedMoney += OnTouchedCollectedMoney;
            CollectableSignals.Instance.onTouchedObstacle += OnTouchedObstacle;
            CollectableSignals.Instance.onUpdatePosition += OnUpdatePosition;
        }

        private void UnsubscribeEvents()
        {
            CollectableSignals.Instance.onTouchedPlayer -= OnTakeCollectableToStack;
            ScoreSignals.Instance.onIncreasePlayerScore -= OnIncreasePlayerScore;
            CollectableSignals.Instance.onTouchedCollectedMoney -= OnTouchedCollectedMoney;
            CollectableSignals.Instance.onTouchedObstacle -= OnTouchedObstacle;
            CollectableSignals.Instance.onUpdatePosition -= OnUpdatePosition;
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
        }
        
        private void StackMoney(GameObject gO)
        {
            Debug.Log(_tween);
            AddCollectableToStackList(gO); 
            gO.transform.SetParent(transform); 
            gO.GetComponentInChildren<Collider>().tag = "Collected";
            gO.tag = "Collected";
            
            if (_stackMembers.Count ==0)
            {
                _stackMembers[0].transform.localPosition = Vector3.zero;
            }
            for (int i = 1; i <= _stackMembers.Count - 1; i++)
            {
                _stackMembers[i].transform.localPosition =
                    _stackMembers[i - 1].transform.localPosition + Vector3.forward;
            }
            
            StartCoroutine(stackAnimationController.MoneyScale(_stackMembers,_tween));
        }
        
        private void AddCollectableToStackList(GameObject gO)
        {
            _stackMembers.Add(gO);
            _stackMembers.TrimExcess();
        }

        private void OnIncreasePlayerScore()
        {
            playerStackText.text = _stackMembers.Count.ToString();
        }

        private void OnTouchedCollectedMoney(GameObject gO)
        {
            StackMoney(gO);
            
        }

        private void OnTouchedObstacle(int siblingIndex)
        {
            Destroy(transform.GetChild(siblingIndex).gameObject);
            _stackMembers.TrimExcess();
        }

        private void OnUpdatePosition(int siblingIndex,Vector3 obstaclePos)
        {
            List<Vector3> updatedPosList = new List<Vector3>();
            var newPos = Vector3.zero;
            for (int i = siblingIndex ; i < _stackMembers.Count; i++)
            {
                while (newPos.x >-5 && newPos.x< 5)
                {
                    newPos = obstaclePos + new Vector3(Random.Range(-10,10),0f, Random.Range(5,10));
                    if (newPos.x > -5 && newPos.x <5 && !updatedPosList.Contains(newPos))
                    { 
                        Debug.Log(newPos);
                        updatedPosList.Add(newPos); 
                        break;
                    }
                }
                
                _stackMembers[i].tag = "Uncollected"; //not neccessary two changing on tag!!!
                _stackMembers[i].transform.GetChild(1).tag = "Uncollected";
                _stackMembers[i].transform.GetChild(1).GetComponent<Rigidbody>().isKinematic = false; 
                _stackMembers[i].transform.DOJump(newPos, 2f, 1, .5f, false);
                _stackMembers[i].transform.SetParent(_collectables.transform);
                _stackMembers.RemoveAt(i);
            }
            _stackMembers.TrimExcess();
        }
    }
}
