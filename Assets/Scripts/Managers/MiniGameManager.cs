using System.Collections.Generic;
using Commands;
using Controllers;
using TMPro;
using UnityEngine;
using Enums;
using Data.UnityObject;
using Data.ValueObject;
using DG.Tweening;
using Signals;

namespace Managers
{
    public class MiniGameManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public MiniGameState backgroundAxis = MiniGameState.Vertical;
        public Transform targetTransform;

        #endregion

        #region Serialized Variables

        [SerializeField] private List<GameObject> cubeList = new List<GameObject>();
        [SerializeField] private int predictedCubeCount;
        [SerializeField] private GameObject fakePlayer;
        [SerializeField] private MiniGameAnimationController miniGameAnimationController;
        [SerializeField] private MiniGameSetTowerCommand miniGameSetTowerCommand;
        #endregion

        #region Private Variables

        private MiniGameData _data;
        private float _colorValue;
        private int _indexMinFactor;
        private Vector3 forwardStack;
        private Vector3 upwardsStack;
        private int _levelCollactableCount;
        private int _levelScore;
        
        #endregion

        #endregion

        private void Awake()
        {
            _data = GetLetterPathData();
            _levelCollactableCount = FindObjectsOfType<CollectableManager>().Length;
        }

        private void Start()
        {
            _data.cubePrefab.transform.localScale = _data.cubeScale;
            targetTransform.position = new Vector3(0, _data.cubePrefab.transform.localScale.y / 2, targetTransform.position.z);
            OnLoadTower(backgroundAxis); 
        }

        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        private void SubscribeEvents()
        {
            MiniGameSignals.Instance.onSetLevelScoreToMiniGame += OnSetLevelScoreToMiniGame;
            MiniGameSignals.Instance.onStartMiniGame += OnStartMiniGame;
            CoreGameSignals.Instance.onNextLevel += OnNextLevel;
            CoreGameSignals.Instance.onReset += OnReset;
        }

        private void UnsubscribeEvents()
        {
            MiniGameSignals.Instance.onSetLevelScoreToMiniGame -= OnSetLevelScoreToMiniGame;
            MiniGameSignals.Instance.onStartMiniGame -= OnStartMiniGame;
            CoreGameSignals.Instance.onNextLevel -= OnNextLevel;
            CoreGameSignals.Instance.onReset -= OnReset;
        }

        #endregion

        #region Event Methods
        private void OnNextLevel()
        {
            SetDefaultValueToMiniGame();   
            OnLoadTower(backgroundAxis);
        }

        private void OnReset()
        {
            SetDefaultValueToMiniGame();
            OnLoadTower(backgroundAxis);
        }
        
        private void OnLoadTower(MiniGameState state)
        {
            miniGameSetTowerCommand.SetTowerOnScene(_data,state,predictedCubeCount,cubeList,targetTransform);
        }

        private void OnSetLevelScoreToMiniGame(int score)
        {
            _levelScore = score;
        }

        private void OnStartMiniGame()
        {
            miniGameAnimationController.StartAnim(targetTransform,_data,fakePlayer,_levelScore);
        }

        #endregion
        
        private MiniGameData GetLetterPathData() => Resources.Load<CD_MiniGame>("Data/CD_MiniGame").miniGameData;

        private void SetDefaultValueToMiniGame()
        {
            fakePlayer.transform.localPosition =new Vector3(0,-2,-13);
            fakePlayer.SetActive(false);
        }
    }
}
