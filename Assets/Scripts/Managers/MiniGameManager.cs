using System;
using System.Collections.Generic;
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

        public Transform levelCollactableHolder; // Level

        #endregion

        #region Serialized Variables

        [SerializeField] private List<GameObject> cubeList = new List<GameObject>();

        [SerializeField] private int predictedCubeCount;


        #endregion

        #region Private Variables

        private MiniGameData data;

        private float colorValue;

        private int _indexMinFactor;

        private Vector3 forwardStack;

        private Vector3 upwardsStack;

        private int _levelScore;

        #endregion

        #endregion
        
        private int _levelCollactableCount;

        [SerializeField] private int mostValuableObjectValue = 3;
        [SerializeField] private GameObject fakePlayer;
        


        private void Awake()
        {
            data = GetLetterPathData();
            _levelCollactableCount = FindObjectsOfType<CollectableManager>().Length;

        }

        private void Start()
        {
            data.cubePrefab.transform.localScale = data.cubeScale;

            targetTransform.position = new Vector3(0, data.cubePrefab.transform.localScale.y / 2, targetTransform.position.z);

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
            MiniGameSignals.Instance.onSetLevelScoreToMiniGame += SetLevelScoreToMiniGame;
            MiniGameSignals.Instance.onStartMiniGame += OnStartMiniGame;
        }

        private void UnsubscribeEvents()
        {
            MiniGameSignals.Instance.onSetLevelScoreToMiniGame -= SetLevelScoreToMiniGame;
            MiniGameSignals.Instance.onStartMiniGame -= OnStartMiniGame;
        }

        #endregion

        private MiniGameData GetLetterPathData() => Resources.Load<CD_MiniGame>("Data/CD_MiniGame").miniGameData;

        public void SetAtmData(int atmData)
        {
            _levelScore = atmData;
        }

        private int SetPredictedCubeCount() // Set cube count base level
        {
            return predictedCubeCount = (_levelCollactableCount * mostValuableObjectValue);
        }

        private void SetCubesToScene(int cubeCount)
        {
            for (int i = 0; i < cubeCount; i++)
            {
                cubeList.Add(Instantiate(data.cubePrefab, targetTransform));
                SetColor(cubeList[i]);
            }
        }
        private void SetColor(GameObject gO)
        {
            colorValue += 0.05f;

            if (colorValue >= 0.9f)
            {
                colorValue = 0;
            }

            gO.GetComponent<Renderer>().material.color = Color.HSVToRGB(colorValue, 1, 1);
        }
        private void SetTowerCollider(MiniGameState _backgroundAxis, GameObject gO)
        {
            BoxCollider cubeCollider = gO.GetComponent<BoxCollider>();

            if (_backgroundAxis == MiniGameState.Vertical)
            {
                cubeCollider.center = new Vector3(0, 0, -data.colliderCenter);
                cubeCollider.size = new Vector3(1, 1, data.colliderSize);
            }
            else
            {
                cubeCollider.center = new Vector3(0, data.colliderCenter, 0);
                cubeCollider.size = new Vector3(1, data.colliderSize, 1);
            }
        }
        private void SetTextOnCubes(GameObject gO, MiniGameState _backgroundAxis)
        {
            if (_indexMinFactor > data.indexMaxFactor)
            {
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

        private void SetLevelScoreToMiniGame(int score)
        {
            _levelScore = score;
            Debug.Log(_levelScore);
            StartMiniGameAnim();
        }

        private void StartMiniGameAnim()
        {
            var position = targetTransform.position;
            Vector3 newPos = new Vector3(position.x, position.y , position.z-data.cubeScale.z);
            Debug.Log(newPos);
            Instantiate(fakePlayer);
            fakePlayer.transform.position = newPos;
            //MoveFakePlayerLastPos(fakePlayer);
        }

        private void MoveFakePlayerLastPos(GameObject fPlayer)
        {
            var fakePlayerPos = (_levelScore / data.maxMoneyValue) * data.cubeScale.y;
            Debug.Log(fakePlayerPos);
            fPlayer.transform.DOMoveY(fakePlayerPos, 5, false).SetEase(Ease.Linear);

        }

        private void OnStartMiniGame()
        {
            StartMiniGameAnim();
        }

    }

}
