using System;
using Controllers;
using Enums;
using Signals;
using UnityEngine;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private UIPanelController uiPanelController;

        #endregion

        #endregion
        

        #region Event Subscriptions

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            UISignals.Instance.onOpenPanel += OnOpenPanel;
            UISignals.Instance.onClosePanel += OnClosePanel;
            CoreGameSignals.Instance.onPlay += OnPlay;
            CoreGameSignals.Instance.onLevelSuccessful += OnLevelSuccessful;
            CoreGameSignals.Instance.onNextLevel += OnNextLevel;
            CoreGameSignals.Instance.onLevelInitialize += OnLevelInitialize;
            CoreGameSignals.Instance.onRestartLevel += OnRestartLevel;
        }

        private void UnsubscribeEvents()
        {
            UISignals.Instance.onOpenPanel -= OnOpenPanel;
            UISignals.Instance.onClosePanel -= OnClosePanel;
            CoreGameSignals.Instance.onPlay -= OnPlay;
            CoreGameSignals.Instance.onLevelSuccessful -= OnLevelSuccessful;
            CoreGameSignals.Instance.onNextLevel -= OnNextLevel;
            CoreGameSignals.Instance.onLevelInitialize -= OnLevelInitialize;
            CoreGameSignals.Instance.onRestartLevel -= OnRestartLevel;
        }
        

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion

        private void OnOpenPanel(UIPanels panelParam)
        {
            uiPanelController.OpenPanel(panelParam);
        }

        private void OnClosePanel(UIPanels panelParam)
        {
            uiPanelController.ClosePanel(panelParam);
        }
        
        private void OnLevelInitialize()
        {
            
        }

        private void OnPlay()
        {
            UISignals.Instance.onClosePanel?.Invoke(UIPanels.StartPanel);
            UISignals.Instance.onOpenPanel?.Invoke(UIPanels.LevelPanel);
        }
        
        public void Play()
        {
            CoreGameSignals.Instance.onPlay?.Invoke();
            CoreGameSignals.Instance.onSetCameraTarget.Invoke();
            CoreGameSignals.Instance.onSetCameraState?.Invoke(CameraTypes.MiniGameCam);
        }
        
        private void OnRestartLevel()
        {
            UISignals.Instance.onOpenPanel?.Invoke(UIPanels.StartPanel);
            UISignals.Instance.onClosePanel?.Invoke(UIPanels.LevelPanel);
        }

        public void Restart()
        {
            CoreGameSignals.Instance.onRestartLevel?.Invoke();
        }

        private void OnLevelSuccessful()
        {
            UISignals.Instance.onClosePanel?.Invoke(UIPanels.LevelPanel);
            UISignals.Instance.onOpenPanel?.Invoke(UIPanels.WinPanel);
        }

        

        private void OnNextLevel()
        {
            UISignals.Instance.onClosePanel?.Invoke(UIPanels.WinPanel);
            UISignals.Instance.onOpenPanel?.Invoke(UIPanels.LevelPanel);
        }

        public void Next()
        {
            CoreGameSignals.Instance.onNextLevel?.Invoke();
            CoreGameSignals.Instance.onSetCameraState?.Invoke(CameraTypes.MiniGameCam);
        }

        

        
    }
}