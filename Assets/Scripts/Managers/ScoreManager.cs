using System;
using System.Collections.Generic;
using Signals;
using TMPro;
using UnityEngine;

namespace Managers
{
    public class ScoreManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        // [SerializeField] private TextMeshPro textATMScore;
        [SerializeField] private List<TextMeshPro> textList = new List<TextMeshPro>();

        #endregion

        #region Private Variables

        private int _atmScore = 0;

        #endregion

        #endregion
        

        #region Subscription Events

        private void OnEnable()
        { 
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            ScoreSignals.Instance.onIncreaseATMScore += OnIncreaseATMScore;
            // ScoreSignals.Instance.onSetLevelScore += OnSetLevelScore;
        }

        private void UnsubscribeEvents()
        {
            ScoreSignals.Instance.onIncreaseATMScore -= OnIncreaseATMScore;
            // ScoreSignals.Instance.onSetLevelScore -= OnSetLevelScore;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion
        
        private void OnIncreaseATMScore(int score)
        {
            _atmScore += score;
            foreach (var textMeshPro in textList)
            {
                textMeshPro.text = _atmScore.ToString();
            }
        }
        
        
        // private int playerScore = 10;
        //
        // int totalCollectableCount = 20
        // private int maxPlayerScore = totalCollectableCount*3;
        //
        // private float multipleScore = (playerScore / maxPlayerScore ) + 1 // totalScoreOnData
        //
        // private float newPosYPlayerAnim = (playerScore / maxPlayerScore) * collectableScaleY * TotalCollectableCount; // gorsel show
    }
}