using System.Collections.Generic;
using Data.ValueObject;
using Enums;
using TMPro;
using UnityEngine;

namespace Commands
{
    public class MiniGameSetTowerCommand : MonoBehaviour
    {
        public void SetTowerOnScene(MiniGameData data,MiniGameState state,int cubeCount,List<GameObject> cubeList,Transform targetTransform)
        {
            float colorValue = 0;
            for (int i = 0; i < cubeCount; i++)
            {
                cubeList.Add(Instantiate(data.cubePrefab, targetTransform));

                
                colorValue += 0.05f;

                if (colorValue >= 0.9f)
                {
                    colorValue = 0;
                }

                cubeList[i].GetComponent<Renderer>().material.color = Color.HSVToRGB(colorValue, 1, 1);
            }

            int indexMinFactor = 0;
            for (int i = 0; i < cubeList.Count; i++)
            { 
                if (indexMinFactor >= data.indexMaxFactor-1)
                {
                    indexMinFactor = 0;
                    return;
                }
                
                SetTextOnCubes(cubeList[i].gameObject, state, data,indexMinFactor);
                SetTowerCollider(state, cubeList[i],data);
                if (i == 0)
                {
                    cubeList[i].transform.position = targetTransform.position;
                }
                else
                {

                    cubeList[i].transform.position = cubeList[i - 1].transform.position + SetStackDirection(state, cubeList[i]);
                }

                indexMinFactor++;
            }
        }
        
        private void SetTextOnCubes(GameObject gO, MiniGameState _backgroundAxis,MiniGameData data,int indexMinFactor)
        {
            var value = (float)indexMinFactor / 10;

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
        }
        private void SetTowerCollider(MiniGameState state, GameObject gO,MiniGameData data)
        {
            BoxCollider cubeCollider = gO.GetComponent<BoxCollider>();

            if (state == MiniGameState.Vertical)
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
        
        private Vector3 SetStackDirection(MiniGameState state, GameObject gO)
        {
            Vector3 forwardStack;
            Vector3 upwardsStack;
            if (state == MiniGameState.Vertical)
            {
                return forwardStack = gO.transform.localScale.y * Vector3.up;
            }
            else
            {
                return upwardsStack = gO.transform.localScale.z * Vector3.forward;
            }
        }
    }
}