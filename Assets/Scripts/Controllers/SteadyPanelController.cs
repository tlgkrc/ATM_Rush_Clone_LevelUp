using TMPro;
using UnityEngine;

namespace Controllers
{
    public class SteadyPanelController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables
        
        [SerializeField] private TextMeshProUGUI moneyText;

        #endregion

        #endregion
        public void SetMoneyText(int money)
        {
            moneyText.text = money.ToString();
        }
    }
}