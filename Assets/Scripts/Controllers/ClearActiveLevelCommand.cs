using UnityEngine;

namespace Controllers
{
    public class ClearActiveLevelCommand : MonoBehaviour
    {
        public void ClearActiveLevel(Transform levelHolder)
        {
            Destroy(levelHolder.GetChild(1).gameObject);
        }
    }
}