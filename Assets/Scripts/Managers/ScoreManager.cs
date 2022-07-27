﻿using Signals;
using TMPro;
using UnityEngine;

namespace Managers
{
    public class ScoreManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private TextMeshPro textAtmScore;

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
        }

        private void UnsubscribeEvents()
        {
            ScoreSignals.Instance.onIncreaseATMScore -= OnIncreaseATMScore;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion
        
        private void OnIncreaseATMScore(int score)
        {
            _atmScore += score;
            textAtmScore.text = _atmScore.ToString();
        }
    }
}