using System;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Art.Scripts
{
    public class MiniGameManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        #endregion

        #region Serialized Variables

        [SerializeField] private GameObject spawnPoint;
        [SerializeField] private int totalCubeCount;
        [SerializeField] private GameObject cubePrefab;
        [SerializeField] private Vector3 scaleFactor;


        #endregion

        #region Private Variables

        private int _totalObjectCount;
        private int _collectedScore;
        private int _maxScore;
        private TextMeshPro multipleText;
        private List<GameObject> cubeList = new List<GameObject>();

        #endregion

        #endregion


        private void Awake()
        {
            OptimizeParameters();
            SetPositionOfCubes();
        }

        private void OptimizeParameters()
        {
            SetScale();
            SetTMP();
        }
        

        private void SetScale()
        {
            cubePrefab.transform.localScale = scaleFactor;
        }

        private void SetTMP()
        {
            multipleText = cubePrefab.transform.GetChild(0).GetComponent<TextMeshPro>();
        }

        private void InitializeCubes()
        {
            for (int i = 0; i < totalCubeCount; i++)
            {
                Instantiate(cubePrefab,transform);
                cubeList.Add(cubePrefab);
            }
        }

        private void SetPositionOfCubes()
        {
            var posSpawn = spawnPoint.transform.position;
            InitializeCubes();
            for (int i = 0; i <= cubeList.Count-1; i++)
            {
                if (i == 0)
                {
                    cubeList[0].transform.position =
                        spawnPoint.transform.position + new Vector3(posSpawn.x, scaleFactor.y/2, posSpawn.z);
                }
                else
                {
                    cubeList[i].transform.position =
                        cubeList[i - 1].transform.position + new Vector3(0,scaleFactor.y,0);
                }
                Debug.Log(cubeList[0].transform.position);
            }
            
        }
    }
}