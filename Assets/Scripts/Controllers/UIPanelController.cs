using System.Collections.Generic;
using Enums;
using Keys;
using TMPro;
using UnityEngine;

namespace Controllers
{
    public class UIPanelController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private List<GameObject> panels;

        #endregion

        #endregion

        public void OpenPanel(UIPanels panelParam)
        {
            panels[(int) panelParam].SetActive(true);
        }

        public void ClosePanel(UIPanels panelParam)
        {
            panels[(int) panelParam].SetActive(false);
        }

        public void SetMoneyTextToPanel(UIPanels panelParam)
        {
            for (int i = 0; i < panels.Count; i++)
            {
                var totalMoney = panels[i].transform.GetComponentInChildren<TextMeshPro>().text;
                //totalMoney = ES3.Load<int>("TotalMoney",(SaveGameDataParams.TotalMoney).ToString());
            }
        }
    }
}