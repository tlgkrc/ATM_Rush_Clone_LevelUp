using System.Collections.Generic;
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
        [SerializeField] private int mostValuableObjectValue = 3;
        [SerializeField] private GameObject fakePlayer;
        [SerializeField] private MiniGameAnimationController miniGameAnimationController;
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

            SetCubesToScene(SetPredictedCubeCount());

            OnLoadTower(backgroundAxis); // Invoke
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
        
        private void OnLoadTower(MiniGameState _backgroundAxis)
        {
            if (_backgroundAxis == MiniGameState.Vertical)
            {
                SetBuild(_backgroundAxis);
            }
            else
            {
                SetBuild(_backgroundAxis);
            }
        }

        private void OnSetLevelScoreToMiniGame(int score)
        {
            _levelScore = score;
        }

        private void OnStartMiniGame()
        {
            miniGameAnimationController.StartAnim(targetTransform,_data,fakePlayer,_levelScore);
        }
        
        private MiniGameData GetLetterPathData() => Resources.Load<CD_MiniGame>("Data/CD_MiniGame").miniGameData;

        private int SetPredictedCubeCount() // Set cube count base level
        {
            return predictedCubeCount;
        }

        private void SetCubesToScene(int cubeCount)
        {
            for (int i = 0; i < cubeCount; i++)
            {
                cubeList.Add(Instantiate(_data.cubePrefab, targetTransform));
                SetColor(cubeList[i]);
            }
        }
        private void SetColor(GameObject gO)
        {
            _colorValue += 0.05f;

            if (_colorValue >= 0.9f)
            {
                _colorValue = 0;
            }

            gO.GetComponent<Renderer>().material.color = Color.HSVToRGB(_colorValue, 1, 1);
        }
        private void SetTowerCollider(MiniGameState _backgroundAxis, GameObject gO)
        {
            BoxCollider cubeCollider = gO.GetComponent<BoxCollider>();

            if (_backgroundAxis == MiniGameState.Vertical)
            {
                cubeCollider.center = new Vector3(0, 0, -_data.colliderCenter);
                cubeCollider.size = new Vector3(1, 1, _data.colliderSize);
            }
            else
            {
                cubeCollider.center = new Vector3(0, _data.colliderCenter, 0);
                cubeCollider.size = new Vector3(1, _data.colliderSize, 1);
            }
        }
        private void SetTextOnCubes(GameObject gO, MiniGameState _backgroundAxis)
        {
            if (_indexMinFactor >= _data.indexMaxFactor-1)
            {
                _indexMinFactor = 0;
                return;
            }

            var value = (float)_indexMinFactor / 10;

            if (_backgroundAxis == MiniGameState.Vertical)
            {
                gO.transform.GetChild(0).gameObject.SetActive(true);
                gO.transform.GetChild(0).GetComponentInChildren<TextMeshPro>().text =(value+1).ToString() + "x";
            }
            else
            {
                gO.transform.GetChild(1).gameObject.SetActive(true);

                gO.transform.GetChild(1).GetComponentInChildren<TextMeshPro>().text = (value + 1).ToString() + "x";
            }
            _indexMinFactor++;
        }
        private Vector3 SetStackDirection(MiniGameState _backgroundAxis, int index)
        {
            if (_backgroundAxis == MiniGameState.Vertical)
            {
                return forwardStack = cubeList[index].transform.localScale.y * Vector3.up;
            }
            else
            {
                return upwardsStack = cubeList[index].transform.localScale.z * Vector3.forward;
            }
        }
        private void SetBuild(MiniGameState _backgroundAxis)
        {
            for (int i = 0; i < cubeList.Count; i++)
            {
                SetTextOnCubes(cubeList[i].gameObject, _backgroundAxis);
                SetTowerCollider(_backgroundAxis, cubeList[i]);
                if (i == 0)
                {
                    cubeList[i].transform.position = targetTransform.position;
                }
                else
                {

                    cubeList[i].transform.position = cubeList[i - 1].transform.position + SetStackDirection(_backgroundAxis, i);
                }
            }
        }

        private void SetDefaultValueToMiniGame()
        {
            fakePlayer.transform.localPosition =new Vector3(0,-2,-13);
            fakePlayer.SetActive(false);
        }
    }
}
