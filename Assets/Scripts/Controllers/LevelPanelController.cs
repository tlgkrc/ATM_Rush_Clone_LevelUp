using Managers;
using TMPro;
using UnityEngine;

namespace Controllers
{
    public class LevelPanelController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private UIManager manager;
        [SerializeField] private TextMeshProUGUI levelText;

        #endregion

        #endregion

        public void SetLevelText(int levelID)
        {
            levelText.text ="LEVEL " + levelID.ToString();
        }
    }
}